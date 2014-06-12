using Model;
using Model.Meta;
using MusicXML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Clef = Model.Clef;

namespace Musicista.Mappers
{
    public static class MusicXMLMapper
    {
        public static Piece MapMusicXMLToMusicista(MusicXMLScore mxml)
        {
            var piece = Mapper.CreateEmptyPiece();

            piece.Title = mxml.Work.WorkTitle;

            if (mxml.Identification != null && mxml.Identification.creator != null)
                foreach (var creator in mxml.Identification.creator.Where(creator => creator.type == "composer"))
                    piece.ListOfComposers.Add(new Composer { FullName = creator.Value });

            // Partlist.scorepart = first <score-part/>, PartList.items except last one = other <score-parts/>
            piece.ListOfInstruments.Add(new Instrument(mxml.PartList.scorepart.partname.Value,
                int.Parse(Regex.Match(mxml.PartList.scorepart.id, @"\d+").Value)));
            if (mxml.PartList.Items != null)
                foreach (scorepart scorepart in mxml.PartList.Items.Where(item => item.GetType() == typeof(scorepart)))
                    piece.ListOfInstruments.Add(new Instrument(scorepart.partname.Value, int.Parse(Regex.Match(scorepart.id, @"\d+").Value)));

            if (mxml.GetType() == typeof(ScorePartwise))
                MapPartwiseMeasuresToPiece((ScorePartwise)mxml, piece);
            else if (mxml.GetType() == typeof(ScoreTimewise))
                MapTimewiseMeasuresToPiece((ScoreTimewise)mxml, piece);

            return piece;
        }
        /// <summary>
        /// Maps a partwise-MusicXML-Object to a Musicista Piece. The structure is 
        /// <score-partwise><part id="P1"><measure number="1"></measure><measure number="2"></measure>...</part><part id="P2">...</part></score-partwise>
        /// </summary>
        /// <param name="mxml">A ScorePartwise-object</param>
        /// <param name="piece">The Piece-object the measures will be added to</param>
        /// <returns>The given Piece with the measures in it.</returns>
        public static Piece MapPartwiseMeasuresToPiece(ScorePartwise mxml, Piece piece)
        {
            var lastClef = new List<Clef>();
            for (var i = 0; i < mxml.Part[0].Measure.Length; i++)
                lastClef.Add(Clef.Treble);

            var lastClefAdditionalStaves = new List<Clef>();
            for (var i = 0; i < mxml.Part[0].Measure.Length; i++)
                lastClefAdditionalStaves.Add(Clef.Treble);

            var listOfAdditionalStaves = new Dictionary<int, List<Measure>>();

            var lastKey = new MusicalKey(Pitch.C, Gender.Major);

            // take the first part, go through all measure, for each measure look up the other parts
            for (var measureNumber = 0; measureNumber < mxml.Part[0].Measure.Length; measureNumber++)
            {
                // 1. Create a parent MeasureGroup
                ScorePartwisePartMeasure measure = mxml.Part[0].Measure[measureNumber];
                var measureGroup = new MeasureGroup
                {
                    MeasureNumber = int.Parse(Regex.Match(measure.number, @"\d+").Value),
                    TimeSignature = null,
                    Measures = new List<Measure>(),
                    ParentPassage = piece.ListOfSections[0].ListOfMovements[0].ListOfSegments[0].ListOfPassages[0]
                };

                var measureAttributes = measure.Items.First(item => item.GetType() == typeof(attributes)) as attributes;
                if (measureAttributes != null && measureAttributes.key != null && measureAttributes.key.First() != null)
                    lastKey = GetKeyFromMXMLKey(measureAttributes.key.First());
                measureGroup.KeySignature = lastKey;


                // 2. Go through all <Part>s, 
                for (var partNumber = 0; partNumber < mxml.Part.Length; partNumber++)
                {
                    var items = mxml.Part[partNumber].Measure[measureNumber].Items;

                    // crazy multiple staves-madness, part 1
                    var attributes = items.First(item => item.GetType() == typeof(attributes)) as attributes;
                    if (attributes != null && attributes.staves != null && int.Parse(attributes.staves) > 1)
                        listOfAdditionalStaves.Add(partNumber, new List<Measure>());
                    if (listOfAdditionalStaves.ContainsKey(partNumber))
                    {
                        if (items.Any(item => item.GetType() == typeof(attributes)))
                            lastClefAdditionalStaves[partNumber] =
                                GetClefFromAttributes(items.First(item => item.GetType() == typeof(attributes)) as attributes, true) ?? lastClefAdditionalStaves[partNumber];
                        listOfAdditionalStaves[partNumber].Add(new Measure
                        {
                            Instrument = piece.ListOfInstruments[partNumber],
                            ParentMeasureGroup = measureGroup,
                            Clef = lastClefAdditionalStaves[partNumber]

                        });
                    }

                    // get correct clef
                    if (items.Any(item => item.GetType() == typeof(attributes)))
                        lastClef[partNumber] = GetClefFromAttributes(items.First(item => item.GetType() == typeof(attributes)) as attributes) ?? lastClef[partNumber];

                    // 3. create a new measure for each part
                    var newMeasure = new Measure
                    {
                        Instrument = piece.ListOfInstruments[partNumber],
                        ParentMeasureGroup = measureGroup,
                        Clef = lastClef[partNumber]
                    };

                    // 4a. Split voices (crazy multiple staves-madness, part 2)
                    var voices = items.Aggregate(new List<List<note>> { new List<note>() },
                                   (list, value) =>
                                   {
                                       if (value.GetType() == typeof(note)) list.Last().Add((note)value);
                                       if (value.GetType() == typeof(backup)) list.Add(new List<note>());
                                       return list;
                                   });

                    // 4b. and add the Notes and Rests of each Measure
                    for (var voice = 0; voice < voices.Count; voice++)
                    {
                        double beat = 256;
                        double advanceBeat = 0;
                        foreach (var mxmlNote in voices[voice])
                        {
                            if (mxmlNote.Items.All(item => item.GetType() != typeof(chord))) // advance beat-counter only if <chord>-Tag is not present
                                beat += advanceBeat;

                            var newNote = CreateNoteFromMXMLNote(mxmlNote, beat / 256);
                            newNote.Voice = voice;

                            advanceBeat = (int)newNote.Duration; // IF the next note advances the beat counter, it shloud be by this amout

                            if (mxmlNote.staff == "1")
                                newMeasure.AddSymbol(newNote);
                            else if (listOfAdditionalStaves.ContainsKey(partNumber)) //crazy multiple staves-madness, part 3
                                listOfAdditionalStaves[partNumber][measureNumber].AddSymbol(newNote);
                        }
                    }

                    measureGroup.Measures.Add(newMeasure);
                }
                piece.ListOfSections[0].ListOfMovements[0].ListOfSegments[0].ListOfPassages[0].ListOfMeasureGroups.Add(measureGroup);
            }
            //crazy multiple staves-madness, part 4
            if (listOfAdditionalStaves.Count > 0)
                foreach (var additionalStaff in listOfAdditionalStaves.Reverse())
                {
                    var instrument = new Instrument(piece.ListOfInstruments[additionalStaff.Key] + " 2");
                    piece.ListOfInstruments.Add(instrument);
                    foreach (var measure in additionalStaff.Value)
                    {
                        measure.Instrument = instrument;
                        measure.ParentMeasureGroup.Measures.Insert(additionalStaff.Key + 1, measure);
                    }
                }
            return piece;
        }

        private static Clef? GetClefFromAttributes(attributes attributes, bool takeLast = false)
        {
            if (attributes == null || attributes.clef == null || attributes.clef[0] == null)
                return null;

            var clef = takeLast ? attributes.clef.Last() : attributes.clef.First();

            if (clef.sign == clefsign.G && clef.line == "2")
                return Clef.Treble;
            if (clef.sign == clefsign.C && clef.line == "3")
                return Clef.Alto;
            if (clef.sign == clefsign.C && clef.line == "4")
                return Clef.Tenor;
            if (clef.sign == clefsign.F && clef.line == "4")
                return Clef.Bass;
            return null;
        }

        /// <summary>
        /// Maps a timewise-MusicXML-Object to a Musicista Piece. The structure is 
        /// <score-timewise><measure number="1"><part id="P1"><note></note>...</part><part id="P2">...</part></measure></score-timewise>
        /// </summary>
        /// <param name="mxml">A ScoreTimewise-object</param>
        /// <param name="piece">The Piece-object the measures will be added to</param>
        /// <returns>The given Piece with the measures in it.</returns>
        public static Piece MapTimewiseMeasuresToPiece(ScoreTimewise mxml, Piece piece)
        {
            var lastClef = new List<Clef>();
            for (var i = 0; i < mxml.Measure[0].part.Length; i++)
                lastClef.Add(Clef.Treble);

            foreach (var measure in mxml.Measure)
            {
                var measureGroup = new MeasureGroup
                {
                    MeasureNumber = int.Parse(Regex.Match(measure.number, @"\d+").Value),
                    TimeSignature = null,
                    KeySignature = null,
                    Measures = new List<Measure>(),
                    ParentPassage = piece.ListOfSections[0].ListOfMovements[0].ListOfSegments[0].ListOfPassages[0]
                };

                for (var partNumber = 0; partNumber < measure.part.Length; partNumber++)
                {
                    if (measure.part[partNumber].Items.Any(item => item.GetType() == typeof(attributes)))
                        lastClef[partNumber] = GetClefFromAttributes(measure.part[partNumber].Items.First(item => item.GetType() == typeof(attributes)) as attributes) ?? lastClef[partNumber];

                    var newMeasure = new Measure
                    {
                        Instrument = piece.ListOfInstruments[partNumber],
                        ParentMeasureGroup = measureGroup,
                        Clef = lastClef[partNumber]
                    };

                    // Grab all Notes and Rests from the current <Part>
                    var notes = measure.part[partNumber].Items.Where(item => item.GetType() == typeof(note));

                    double beat = 256;

                    foreach (note mxmlNote in notes)
                    {
                        var newNote = CreateNoteFromMXMLNote(mxmlNote, beat / 256);
                        beat += (int)newNote.Duration;
                        newMeasure.AddSymbol(newNote);
                    }

                    measureGroup.Measures.Add(newMeasure);
                }
                piece.ListOfSections[0].ListOfMovements[0].ListOfSegments[0].ListOfPassages[0].ListOfMeasureGroups.Add(measureGroup);
            }

            return piece;
        }

        public static Symbol CreateNoteFromMXMLNote(note mxmlNote, double beat = 1.0)
        {
            if (mxmlNote == null || mxmlNote.Items == null || !mxmlNote.Items.Any())
                return null;

            // Rests
            if (mxmlNote.Items.Any(item => item is rest))
            {
                var newRest = new Rest
                {
                    Beat = beat
                };
                if (mxmlNote.Items.Any(item => item is decimal))
                {
                    string durationString = mxmlNote.Items.First(item => item is decimal).ToString();
                    newRest.Duration = (Duration)int.Parse(durationString);
                }
                if (!string.IsNullOrEmpty(mxmlNote.voice))
                    newRest.Voice = int.Parse(Regex.Match(mxmlNote.voice, @"\d+").Value);
                return newRest;
            }

            // Notes
            var newNote = new Note
            {
                Beat = beat,
                Velocity = 0,
                Voice = 1
            };

            if (mxmlNote.Items.Any(item => item is decimal) && mxmlNote.Items.Any(item => item is pitch))
            {
                var durationString = mxmlNote.Items.First(item => item is decimal).ToString();
                newNote.Duration = (Duration)int.Parse(durationString);
                if (!Enum.IsDefined(typeof(Duration), newNote.Duration))
                    Console.WriteLine(@"Error parsing duration " + durationString);
                newNote.Octave = int.Parse(((pitch)mxmlNote.Items.First(item => item is pitch)).octave);

                newNote.Step = GetPitchFromMXMLNote(mxmlNote);
            }

            if (mxmlNote.Items.Any(item => item is textelementdata))
                newNote.Text =
                    ((textelementdata)mxmlNote.lyric[0].Items.First(item => item is textelementdata)).Value;

            if (!string.IsNullOrEmpty(mxmlNote.voice))
                newNote.Voice = int.Parse(Regex.Match(mxmlNote.voice, @"\d+").Value);
            return newNote;
        }

        public static Pitch GetPitchFromMXMLNote(note mxmlNote)
        {
            step step = ((pitch)mxmlNote.Items.First(item => item is pitch)).step;
            decimal alter = ((pitch)mxmlNote.Items.First(item => item is pitch)).alter;

            if (alter == 0)
                switch (step)
                {
                    case step.A:
                        return Pitch.A;
                    case step.B:
                        return Pitch.B;
                    case step.C:
                        return Pitch.C;
                    case step.D:
                        return Pitch.D;
                    case step.E:
                        return Pitch.E;
                    case step.F:
                        return Pitch.F;
                    case step.G:
                        return Pitch.G;
                }

            if (alter == 1)
                switch (step)
                {
                    case step.A:
                        return Pitch.ASharp;
                    case step.B:
                        return Pitch.BSharp;
                    case step.C:
                        return Pitch.CSharp;
                    case step.D:
                        return Pitch.DSharp;
                    case step.E:
                        return Pitch.ESharp;
                    case step.F:
                        return Pitch.FSharp;
                    case step.G:
                        return Pitch.GSharp;
                }

            if (alter == -1)
                switch (step)
                {
                    case step.A:
                        return Pitch.AFlat;
                    case step.B:
                        return Pitch.BFlat;
                    case step.C:
                        return Pitch.CFlat;
                    case step.D:
                        return Pitch.DFlat;
                    case step.E:
                        return Pitch.EFlat;
                    case step.F:
                        return Pitch.FFlat;
                    case step.G:
                        return Pitch.GFlat;
                }

            return Pitch.Unknown;
        }

        public static MusicalKey GetKeyFromMXMLKey(key key)
        {
            var fifths = int.Parse(key.Items.First(item => item is string).ToString());
            var mode = key.Items.Last(item => item is string).ToString();

            switch (mode)
            {
                case "major":
                    switch (fifths)
                    {
                        case 0:
                            return new MusicalKey(Pitch.C, Gender.Major);
                        case 1:
                            return new MusicalKey(Pitch.G, Gender.Major);
                        case 2:
                            return new MusicalKey(Pitch.D, Gender.Major);
                        case 3:
                            return new MusicalKey(Pitch.A, Gender.Major);
                        case 4:
                            return new MusicalKey(Pitch.E, Gender.Major);
                        case 5:
                            return new MusicalKey(Pitch.B, Gender.Major);
                        case 6:
                            return new MusicalKey(Pitch.FSharp, Gender.Major);
                        case 7:
                            return new MusicalKey(Pitch.CSharp, Gender.Major);
                        case -1:
                            return new MusicalKey(Pitch.F, Gender.Major);
                        case -2:
                            return new MusicalKey(Pitch.BFlat, Gender.Major);
                        case -3:
                            return new MusicalKey(Pitch.EFlat, Gender.Major);
                        case -4:
                            return new MusicalKey(Pitch.AFlat, Gender.Major);
                        case -5:
                            return new MusicalKey(Pitch.DFlat, Gender.Major);
                        case -6:
                            return new MusicalKey(Pitch.GFlat, Gender.Major);
                        case -7:
                            return new MusicalKey(Pitch.CFlat, Gender.Major);
                    }
                    break;
                case "minor":
                    switch (fifths)
                    {
                        case 0:
                            return new MusicalKey(Pitch.A, Gender.Minor);
                        case 1:
                            return new MusicalKey(Pitch.E, Gender.Minor);
                        case 2:
                            return new MusicalKey(Pitch.B, Gender.Minor);
                        case 3:
                            return new MusicalKey(Pitch.FSharp, Gender.Minor);
                        case 4:
                            return new MusicalKey(Pitch.CSharp, Gender.Minor);
                        case 5:
                            return new MusicalKey(Pitch.GSharp, Gender.Minor);
                        case 6:
                            return new MusicalKey(Pitch.DSharp, Gender.Minor);
                        case 7:
                            return new MusicalKey(Pitch.ASharp, Gender.Minor);
                        case -1:
                            return new MusicalKey(Pitch.D, Gender.Minor);
                        case -2:
                            return new MusicalKey(Pitch.G, Gender.Minor);
                        case -3:
                            return new MusicalKey(Pitch.C, Gender.Minor);
                        case -4:
                            return new MusicalKey(Pitch.F, Gender.Minor);
                        case -5:
                            return new MusicalKey(Pitch.BFlat, Gender.Minor);
                        case -6:
                            return new MusicalKey(Pitch.EFlat, Gender.Minor);
                        case -7:
                            return new MusicalKey(Pitch.AFlat, Gender.Minor);
                    }
                    break;
            }
            return new MusicalKey(Pitch.C, Gender.Major);
        }
    }
}