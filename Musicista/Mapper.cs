using Model;
using Model.Meta;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Musicista
{
    public static class Mapper
    {
        public static Piece MapMusicXMLPartwiseToMusicistaPiece(scorepartwise mxml)
        {
            var piece = new Piece
            {
                Title = mxml.work.worktitle,
                ListOfComposers = new List<Composer>(),
                ListOfInstruments = new List<Instrument>(),
                ListOfSections =
                    new List<Section>
                    {
                        new Section
                        {
                            ListOfMovements =
                                new List<Movement>
                                {
                                    new Movement
                                    {
                                        ListOfSegments =
                                            new List<Segment>
                                            {
                                                new Segment
                                                {
                                                    ListOfPassages =
                                                        new List<Passage>
                                                        {
                                                            new Passage {ListOfMeasures = new List<Measure>()}
                                                        }
                                                }
                                            }
                                    }
                                }
                        }
                    }
            };

            foreach (typedtext creator in mxml.identification.creator.Where(creator => creator.type == "composer"))
                piece.ListOfComposers.Add(new Composer { FullName = creator.Value });


            // Partlist.scorepart = first <score-part/>, partlist.items except last one = other <score-parts/>
            piece.ListOfInstruments.Add(new Instrument(mxml.partlist.scorepart.partname.Value,
                int.Parse(Regex.Match(mxml.partlist.scorepart.id, @"\d+").Value)));
            foreach (scorepart scorepart in mxml.partlist.Items.Where(item => item.GetType() == typeof(scorepart)))
                piece.ListOfInstruments.Add(new Instrument(scorepart.partname.Value,
                    int.Parse(Regex.Match(scorepart.id, @"\d+").Value)));

            // take the first part, go through all measure, for each measure look up the other parts
            for (int measureNumber = 0; measureNumber < mxml.part[0].measure.Length; measureNumber++)
            {
                scorepartwisePartMeasure measure = mxml.part[0].measure[measureNumber];
                var m = new Measure
                {
                    MeasureNumber = int.Parse(Regex.Match(measure.number, @"\d+").Value),
                    TimeSignature = null,
                    KeySignature = null,
                    Parts = new List<Part>()
                };

                for (int partNumber = 0; partNumber < mxml.part.Length; partNumber++)
                {
                    var part = new Part
                    {
                        Instrument = piece.ListOfInstruments[partNumber],
                        ListOfSymbols = new List<Symbol>()
                    };
                    var notes = mxml.part[partNumber].measure[measureNumber].Items.Where(item => item.GetType() == typeof(note));

                    double beat = 256;

                    foreach (note mxmlNote in notes)
                    {
                        var newNote = CreateNoteFromMXMLNote(mxmlNote, beat / 256);
                        beat += (int)newNote.Duration;
                        part.ListOfSymbols.Add(newNote);
                    }

                    m.Parts.Add(part);
                }
                piece.ListOfSections[0].ListOfMovements[0].ListOfSegments[0].ListOfPassages[0].ListOfMeasures.Add(m);
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
                string durationString = mxmlNote.Items.First(item => item is decimal).ToString();
                newNote.Duration = (Duration)int.Parse(durationString);

                newNote.Octave = int.Parse(((pitch)mxmlNote.Items.First(item => item is pitch)).octave);

                newNote.Step = (Pitch)((pitch)mxmlNote.Items.First(item => item is pitch)).step;
            }

            if (mxmlNote.Items.Any(item => item is textelementdata))
                newNote.Text =
                    ((textelementdata)mxmlNote.lyric[0].Items.First(item => item is textelementdata)).Value;

            if (!string.IsNullOrEmpty(mxmlNote.voice))
                newNote.Voice = int.Parse(Regex.Match(mxmlNote.voice, @"\d+").Value);
            return newNote;
        }
    }
}