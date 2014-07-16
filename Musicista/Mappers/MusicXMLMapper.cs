using Model;
using Model.Meta;
using MuseScoreAPI.RESTObjects;
using MusicXML;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Clef = Model.Clef;
using Note = MusicXML.Note;

namespace Musicista.Mappers
{
    public static class MusicXMLMapper
    {
        public static Piece MapMusicXMLToMusicista(ScorePartwise mxml, String filename, Score scoreInfo = null)
        {
            var piece = Mapper.CreateEmptyPiece();

            // Map work information
            if (!string.IsNullOrEmpty(mxml.Work.WorkTitle))
                piece.Title = mxml.Work.WorkTitle;
            else if (scoreInfo != null)
                piece.Title = scoreInfo.Title;
            else
                piece.Title = filename;

            piece.Notes += "Work Number: " + mxml.Work.WorkNumber;

            // Map Identification information
            if (mxml.Identification != null && mxml.Identification.Encoding != null)
            {
                if (mxml.Identification.Encoding.EncodingDate != null)
                    piece.DateOfTypesetting = DateTime.Parse(mxml.Identification.Encoding.EncodingDate.Value);
                if (mxml.Identification.Encoding.Encoder != null)
                    piece.TypeSetter = mxml.Identification.Encoding.Encoder.Value;
                if (mxml.Identification.Encoding.Software != null)
                    piece.Software = mxml.Identification.Encoding.Software.Value;
                if (mxml.Identification.Rights != null)
                    piece.Copyright = String.Join(", ", mxml.Identification.Rights.Select(item => item.Value));
            }
            // Map composers and other people
            if (mxml.Identification != null && mxml.Identification.Creator != null)
                foreach (var creator in mxml.Identification.Creator)
                    switch (creator.Type)
                    {
                        case "composer":
                            piece.ListOfComposers.Add(new Composer { FullName = creator.Value });
                            break;
                        case "lyricist":
                            piece.ListOfLyricists.Add(new Person { FullName = creator.Value });
                            break;
                        case "arranger":
                            piece.ListOfArrangers.Add(new Person { FullName = creator.Value });
                            break;
                        default:
                            piece.ListOfOtherPersons.Add(new Person { FullName = creator.Value });
                            break;
                    }

            // Map the instruments
            if (mxml.PartList.ScoreParts != null)
                foreach (var scorepart in mxml.PartList.ScoreParts)
                    piece.ListOfInstruments.Add(new Instrument(scorepart.Partname, int.Parse(Regex.Match(scorepart.id, @"\d+").Value)));

            // Map movement information
            if (mxml.MovementNumber != null)
                piece.ListOfAllMovements.First().Number = int.Parse(mxml.MovementNumber);
            if (mxml.MovementTitle != null)
                piece.ListOfAllMovements.First().Name = mxml.MovementTitle;

            // Map the music
            MapPartwiseMeasuresToPiece(mxml, piece);

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
            var lastTime = new TimeSignature(4, 4);
            var durationDivision = 960; // = one quarter

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

                // Division (what int corresponds to a quarter?)
                if (measure.Attributes != null && measure.Attributes.Divisions != 0.0M)
                    durationDivision = (int)measure.Attributes.Divisions;

                // KeySignature
                if (measure.Attributes != null && measure.Attributes.key != null && measure.Attributes.key.First() != null)
                    lastKey = GetKeyFromMXMLKey(measure.Attributes.key.First());
                measureGroup.KeySignature = lastKey;

                // TimeSignature
                if (measure.Attributes != null && measure.Attributes.time != null && measure.Attributes.time.First() != null)
                    if (measure.Attributes.time[0].symbolSpecified)
                        switch (measure.Attributes.time[0].symbol)
                        {
                            case timesymbol.common:
                                lastTime = new TimeSignature(isCommon: true);
                                break;
                            case timesymbol.cut:
                                lastTime = new TimeSignature(isCutCommon: true);
                                break;
                        }
                    else
                        lastTime = new TimeSignature(measure.Attributes.time[0].Beats, measure.Attributes.time[0].BeatType);
                measureGroup.TimeSignature = lastTime;


                // 2. Go through all <Part>s, 
                for (var partNumber = 0; partNumber < mxml.Part.Length; partNumber++)
                {
                    var currentMeasure = mxml.Part[partNumber].Measure[measureNumber];
                    var items = mxml.Part[partNumber].Measure[measureNumber].Items;

                    // crazy multiple staves-madness, part 1
                    if (currentMeasure.Attributes != null && currentMeasure.Attributes.staves != null && int.Parse(currentMeasure.Attributes.staves) > 1)
                        listOfAdditionalStaves.Add(partNumber, new List<Measure>());
                    if (listOfAdditionalStaves.ContainsKey(partNumber))
                    {
                        if (currentMeasure.Attributes != null)
                            lastClefAdditionalStaves[partNumber] = GetClefFromAttributes(currentMeasure.Attributes, true) ?? lastClefAdditionalStaves[partNumber];
                        listOfAdditionalStaves[partNumber].Add(new Measure
                        {
                            Instrument = piece.ListOfInstruments[partNumber],
                            ParentMeasureGroup = measureGroup,
                            Clef = lastClefAdditionalStaves[partNumber]

                        });
                    }

                    // get correct clef
                    if (currentMeasure.Attributes != null)
                        lastClef[partNumber] = GetClefFromAttributes(currentMeasure.Attributes) ?? lastClef[partNumber];

                    // 3. create a new measure for each part
                    var newMeasure = new Measure
                    {
                        Instrument = piece.ListOfInstruments[partNumber],
                        ParentMeasureGroup = measureGroup,
                        Clef = lastClef[partNumber]
                    };

                    // 4a. Split voices (crazy multiple staves-madness, part 2)
                    var voices = items.Aggregate(new List<List<Note>> { new List<Note>() },
                                   (list, value) =>
                                   {
                                       if (value.GetType() == typeof(Note)) list.Last().Add((Note)value);
                                       if (value.GetType() == typeof(backup)) list.Add(new List<Note>());
                                       return list;
                                   });

                    // 4b. and add the Notes and Rests of each Measure
                    for (var voice = 0; voice < voices.Count; voice++)
                    {
                        double beat = 960;
                        double advanceBeat = 0;
                        foreach (var mxmlNote in voices[voice])
                        {
                            if (!mxmlNote.IsChord) // advance beat-counter only if <chord>-Tag is not present
                                beat += advanceBeat;

                            var newNote = CreateNoteFromMXMLNote(mxmlNote, beat / 960, durationDivision);
                            newNote.Voice = voice;

                            advanceBeat = (int)newNote.Duration; // IF the next note advances the beat counter, it should be by this amount

                            if (mxmlNote.staff == null || mxmlNote.staff == "1")
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
                    var instrument = new Instrument(piece.ListOfInstruments[additionalStaff.Key].Name);
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

        public static Symbol CreateNoteFromMXMLNote(Note mxmlNote, double beat = 1.0, int durationDivision = 256)
        {
            if (mxmlNote == null) return null;

            // Division
            var duration = int.Parse(mxmlNote.Duration.ToString(CultureInfo.InvariantCulture));
            if (durationDivision != 960)
                duration = (int)((double)duration / durationDivision * 960);
            // Rests
            if (mxmlNote.IsRest)
            {
                var newRest = new Rest
                {
                    Beat = beat,
                    Duration = (Duration)duration
                };
                if (!string.IsNullOrEmpty(mxmlNote.voice))
                    newRest.Voice = int.Parse(Regex.Match(mxmlNote.voice, @"\d+").Value);
                return newRest;
            }

            // Notes
            var newNote = new Model.Note
            {
                Beat = beat,
                Velocity = 0,
                Voice = 1,
                Duration = (Duration)duration,
                Octave = int.Parse(mxmlNote.Pitch.octave)
            };

            if (!Enum.IsDefined(typeof(Duration), newNote.Duration))
            {
                for (int tolerance = -12; tolerance <= 12; tolerance++)
                {
                    if (Enum.IsDefined(typeof(Duration), newNote.Duration - tolerance))
                        newNote.Duration -= tolerance;
                }

                if (!Enum.IsDefined(typeof(Duration), newNote.Duration))
                    Console.WriteLine(@"Error parsing duration " + mxmlNote.Duration);
            }

            newNote.Step = GetPitchFromMXMLNote(mxmlNote);

            if (mxmlNote.lyric != null && mxmlNote.lyric[0] != null && mxmlNote.lyric[0].Text != null)
                newNote.Text = mxmlNote.lyric[0].Text.Value;

            if (!string.IsNullOrEmpty(mxmlNote.voice))
                newNote.Voice = int.Parse(Regex.Match(mxmlNote.voice, @"\d+").Value);
            return newNote;
        }

        public static Pitch GetPitchFromMXMLNote(Note mxmlNote)
        {
            switch ((int)mxmlNote.Pitch.alter)
            {
                case 0:
                    switch (mxmlNote.Pitch.step)
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
                    break;
                case 1:
                    switch (mxmlNote.Pitch.step)
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
                    break;
                case -1:
                    switch (mxmlNote.Pitch.step)
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
                    break;
            }
            return Pitch.Unknown;
        }

        public static MusicalKey GetKeyFromMXMLKey(key key)
        {
            var fifths = int.Parse(key.Fifths);
            var mode = key.Mode;

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