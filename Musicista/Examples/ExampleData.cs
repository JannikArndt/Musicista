using Model;
using Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicista.Examples
{
    public static class ExampleData
    {
        public static Piece GetBeethoven7()
        {
            Instrument Flute = new Instrument("Flute");
            Instrument Oboe = new Instrument("Oboe");

            var Piece = new Piece
            {
                Title = "Siebte Sinfonie",
                ListOfComposers = new List<Model.Composer> { new Composer { FirstName = "Ludwig", LastName = "van Beethoven" } },
                Opus = new OpusNumber(90),
                Epoch = Epoch.Classical,
                Form = Form.Symphony,
                DateOfComposition = new DateTime(1812),
                Dedication = "Dem Reichsgrafen Moritz von Fries gewidmet",
                Key = new MusicalKey(Pitch.A, Gender.Major),
                ListOfSections = new List<Model.Section>
                {
                    new Model.Section {
                        ListOfMovements = new List<Movement>{
                            new Movement {
                                Number = 1,
                                Name = "Poco sostenuto",
                                Tempo = "Poco sostenuto",
                                BeatsPerMinute = 69,
                                ListOfSegments = new List<Segment>{
                                    new Segment {
                                        Title = "Poco sostenuto",
                                        ListOfPassages = new List<Passage>
                                        {
                                            new Passage 
                                            {
                                                Title = "Beginning",
                                                ListOfMeasures = new List<Measure>
                                                {
                                                    new Measure
                                                    {
                                                        MeasureNumber = 1,
                                                        TimeSignature = new TimeSignature(isCommon: true),
                                                        KeySignature = new MusicalKey(Pitch.A, Gender.Major),
                                                        Parts = new List<Part>
                                                        {
                                                            new Part 
                                                            {
                                                                Instrument = Flute,
                                                                ListOfSymbols = new List<Symbol>
                                                                {
                                                                    new Note { Beat = 1, Voice = 1, Step = Pitch.CSharp, Octave = 6, Duration = Model.Duration.quarter },
                                                                    new Note { Beat = 1, Voice = 2, Step = Pitch.A,      Octave = 6, Duration = Model.Duration.quarter },
                                                                    new Rest { Beat = 2, Voice = 1, Duration = Model.Duration.quarter},
                                                                    new Rest { Beat = 3, Voice = 2, Duration = Model.Duration.half}
                                                                }
                                                            },
                                                            new Part 
                                                            {
                                                                Instrument = Oboe,
                                                                ListOfSymbols = new List<Symbol>
                                                                {
                                                                    new Note { Beat = 1, Voice = 1, Step = Pitch.A,      Octave = 5, Duration = Model.Duration.half },
                                                                    new Note { Beat = 1, Voice = 2, Step = Pitch.CSharp, Octave = 5, Duration = Model.Duration.quarter },
                                                                    new Rest { Beat = 2, Voice = 2, Duration = Model.Duration.quarter},
                                                                    new Note { Beat = 3, Voice = 1, Step = Pitch.E,      Octave = 5, Duration = Model.Duration.half },
                                                                    new Rest { Beat = 3, Voice = 2, Duration = Model.Duration.half}
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    new Segment 
                                    {
                                        Title = "Vivace"
                                    }
                                }
                            }
                        }
                    }
                }

            };

            return Piece;
        }
    }
}
