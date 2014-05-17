using Model;
using Model.Meta;
using MusicXML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Musicista.Mappers
{
    public static class MusicXMLMapper
    {
        public static Piece MacMusicXMLToMusicista(MusicXMLScore mxml)
        {
            var piece = Mapper.CreateEmptyPiece();

            piece.Title = mxml.Work.WorkTitle;

            if (mxml.Identification != null && mxml.Identification.creator != null)
                foreach (var creator in mxml.Identification.creator.Where(creator => creator.type == "composer"))
                    piece.ListOfComposers.Add(new Composer { FullName = creator.Value });

            // Partlist.scorepart = first <score-part/>, PartList.items except last one = other <score-parts/>
            piece.ListOfInstruments.Add(new Instrument(mxml.PartList.scorepart.partname.Value,
                int.Parse(Regex.Match(mxml.PartList.scorepart.id, @"\d+").Value)));
            foreach (scorepart scorepart in mxml.PartList.Items.Where(item => item.GetType() == typeof(scorepart)))
                piece.ListOfInstruments.Add(new Instrument(scorepart.partname.Value,
                    int.Parse(Regex.Match(scorepart.id, @"\d+").Value)));

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
            // take the first part, go through all measure, for each measure look up the other parts
            for (var measureNumber = 0; measureNumber < mxml.Part[0].Measure.Length; measureNumber++)
            {
                // 1. Create a parent MeasureGroup
                ScorePartwisePartMeasure measure = mxml.Part[0].Measure[measureNumber];
                var measureGroup = new MeasureGroup
                {
                    MeasureNumber = int.Parse(Regex.Match(measure.number, @"\d+").Value),
                    TimeSignature = null,
                    KeySignature = null,
                    Measures = new List<Measure>()
                };

                // 2. Go through all <Part>s, 
                for (var partNumber = 0; partNumber < mxml.Part.Length; partNumber++)
                {
                    // 3. create a new measure for each part
                    var newMeasure = new Measure
                    {
                        Instrument = piece.ListOfInstruments[partNumber],
                        ListOfSymbols = new List<Symbol>(),
                        ParentMeasureGroup = measureGroup
                    };
                    // 4. and add the Notes and Rests of each Measure
                    var notes = mxml.Part[partNumber].Measure[measureNumber].Items.Where(item => item.GetType() == typeof(note));

                    double beat = 256;

                    foreach (note mxmlNote in notes)
                    {
                        var newNote = CreateNoteFromMXMLNote(mxmlNote, beat / 256);
                        beat += (int)newNote.Duration;
                        newMeasure.ListOfSymbols.Add(newNote);
                    }

                    measureGroup.Measures.Add(newMeasure);
                }
                piece.ListOfSections[0].ListOfMovements[0].ListOfSegments[0].ListOfPassages[0].ListOfMeasureGroups.Add(measureGroup);
            }

            return piece;
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
            foreach (var measure in mxml.Measure)
            {
                var measureGroup = new MeasureGroup
                {
                    MeasureNumber = int.Parse(Regex.Match(measure.number, @"\d+").Value),
                    TimeSignature = null,
                    KeySignature = null,
                    Measures = new List<Measure>()
                };

                for (var partNumber = 0; partNumber < measure.part.Length; partNumber++)
                {
                    var newMeasure = new Measure
                    {
                        Instrument = piece.ListOfInstruments[partNumber],
                        ListOfSymbols = new List<Symbol>(),
                        ParentMeasureGroup = measureGroup
                    };

                    // Grab all Notes and Rests from the current <Part>
                    var notes = measure.part[partNumber].Items.Where(item => item.GetType() == typeof(note));

                    double beat = 256;

                    foreach (note mxmlNote in notes)
                    {
                        var newNote = CreateNoteFromMXMLNote(mxmlNote, beat / 256);
                        beat += (int)newNote.Duration;
                        newMeasure.ListOfSymbols.Add(newNote);
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
    }
}