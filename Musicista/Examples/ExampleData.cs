using Model;
using Model.Meta;
using System;
using System.Collections.Generic;

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
                ListOfComposers = new List<Composer> { new Composer { FirstName = "Ludwig", LastName = "van Beethoven" } },
                Opus = new OpusNumber(90),
                Epoch = Epoch.Classical,
                Form = Form.Symphony,
                DateOfComposition = new DateTime(1812),
                Dedication = "Dem Reichsgrafen Moritz von Fries gewidmet",
                Key = new MusicalKey(Pitch.A, Gender.Major),
                ListOfSections = new List<Section>
                {
                    new Section {
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
                                                ListOfMeasures = new List<MeasureGroup>
                                                {
                                                    new MeasureGroup
                                                    {
                                                        MeasureNumber = 1,
                                                        TimeSignature = new TimeSignature(isCommon: true),
                                                        KeySignature = new MusicalKey(Pitch.A, Gender.Major),
                                                        Measures = new List<Measure>
                                                        {
                                                            new Measure 
                                                            {
                                                                Instrument = Flute,
                                                                ListOfSymbols = new List<Symbol>
                                                                {
                                                                    new Note { Beat = 1, Voice = 1, Step = Pitch.CSharp, Octave = 6, Duration = Duration.quarter },
                                                                    new Note { Beat = 1, Voice = 2, Step = Pitch.A,      Octave = 6, Duration = Duration.quarter },
                                                                    new Rest { Beat = 2, Voice = 1, Duration = Duration.quarter},
                                                                    new Rest { Beat = 3, Voice = 2, Duration = Duration.half}
                                                                }
                                                            },
                                                            new Measure 
                                                            {
                                                                Instrument = Oboe,
                                                                ListOfSymbols = new List<Symbol>
                                                                {
                                                                    new Note { Beat = 1, Voice = 1, Step = Pitch.A,      Octave = 5, Duration = Duration.half },
                                                                    new Note { Beat = 1, Voice = 2, Step = Pitch.CSharp, Octave = 5, Duration = Duration.quarter },
                                                                    new Rest { Beat = 2, Voice = 2, Duration = Duration.quarter},
                                                                    new Note { Beat = 3, Voice = 1, Step = Pitch.E,      Octave = 5, Duration = Duration.half },
                                                                    new Rest { Beat = 3, Voice = 2, Duration = Duration.half}
                                                                }
                                                            }
                                                        }
                                                    },
                                                    new MeasureGroup
                                                    {
                                                        MeasureNumber = 2,
                                                        TimeSignature = new TimeSignature(isCommon: true),
                                                        KeySignature = new MusicalKey(Pitch.A, Gender.Major),
                                                        Measures = new List<Measure>
                                                        {
                                                            new Measure 
                                                            {
                                                                Instrument = Flute,
                                                                ListOfSymbols = new List<Symbol>
                                                                {
                                                                    new Rest { Beat = 1, Voice = 1, Duration = Duration.whole},
                                                                    new Rest { Beat = 1, Voice = 2, Duration = Duration.whole}
                                                                }
                                                            },
                                                            new Measure 
                                                            {
                                                                Instrument = Oboe,
                                                                ListOfSymbols = new List<Symbol>
                                                                {
                                                                    new Note { Beat = 1, Voice = 1, Step = Pitch.CSharp,      Octave = 5, Duration = Duration.half },
                                                                    new Note { Beat = 3, Voice = 1, Step = Pitch.FSharp,      Octave = 5, Duration = Duration.half },
                                                                    new Rest { Beat = 1, Voice = 2, Duration = Duration.whole}
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

        public static void More()
        {
            var m1 = new MeasureGroup
            {
                TimeSignature = new TimeSignature(4, 4),
                Measures = new List<Measure>
                {
                    new Measure
                    {
                        ListOfSymbols = new List<Symbol>
                        {
                            new Note {Beat = 1, Step = Pitch.C, Octave = 4, Duration = Duration.quarter},
                            new Note {Beat = 2, Step = Pitch.C, Octave = 4, Duration = Duration.quarter},
                            new Note {Beat = 3, Step = Pitch.C, Octave = 4, Duration = Duration.quarter},
                            new Note {Beat = 4, Step = Pitch.C, Octave = 4, Duration = Duration.quarter}
                        }
                    }
                }
            };
            var m2 = new MeasureGroup
            {
                TimeSignature = new TimeSignature(4, 4),
                Measures = new List<Measure>
                {
                    new Measure
                    {
                        ListOfSymbols = new List<Symbol>
                        {
                            new Note {Beat = 1, Step = Pitch.D, Octave = 4, Duration = Duration.eigth},
                            new Note {Beat = 1.25, Step = Pitch.D, Octave = 4, Duration = Duration.eigth},
                            new Note {Beat = 1.5, Step = Pitch.D, Octave = 4, Duration = Duration.eigth},
                            new Note {Beat = 1.75, Step = Pitch.D, Octave = 4, Duration = Duration.eigth},
                            new Rest {Beat = 2, Duration = Duration.quarter},
                            new Rest {Beat = 2, Duration = Duration.half}
                        }
                    }
                }
            };
            var m3 = new MeasureGroup
            {
                TimeSignature = new TimeSignature(4, 4),
                Measures = new List<Measure>
                {
                    new Measure
                    {
                        ListOfSymbols = new List<Symbol>
                        {
                            new Rest {Beat = 1, Duration = Duration.whole}
                        }
                    }
                }
            };

            var note1 = new Note { Beat = 1.00, Step = Pitch.D, Octave = 4, Duration = Duration.sixteenth };
            var note2 = new Note { Beat = 1.25, Step = Pitch.DSharp, Octave = 4, Duration = Duration.sixteenth };
            var note3 = new Note { Beat = 1.50, Step = Pitch.E, Octave = 4, Duration = Duration.sixteenth };
            var note4 = new Note { Beat = 1.75, Step = Pitch.F, Octave = 4, Duration = Duration.sixteenth };
            var note5 = new Note { Beat = 2.00, Step = Pitch.G, Octave = 4, Duration = Duration.sixteenth };
            var note6 = new Note { Beat = 2.25, Step = Pitch.A, Octave = 4, Duration = Duration.sixteenth };
            var note7 = new Note { Beat = 2.50, Step = Pitch.ASharp, Octave = 4, Duration = Duration.sixteenth };
            var note8 = new Note { Beat = 2.75, Step = Pitch.BFlat, Octave = 4, Duration = Duration.sixteenth };
            var note9 = new Note { Beat = 3.00, Step = Pitch.B, Octave = 4, Duration = Duration.sixteenth };
            var note10 = new Note { Beat = 3.25, Step = Pitch.G, Octave = 5, Duration = Duration.sixteenth };
            var note11 = new Note { Beat = 3.50, Step = Pitch.A, Octave = 5, Duration = Duration.sixteenth };
            var note12 = new Note { Beat = 3.75, Step = Pitch.B, Octave = 5, Duration = Duration.sixteenth };
            var note13 = new Note { Beat = 4.00, Step = Pitch.C, Octave = 6, Duration = Duration.sixteenth };
            var note14 = new Note { Beat = 4.25, Step = Pitch.D, Octave = 6, Duration = Duration.sixteenth };
            var note15 = new Note { Beat = 4.50, Step = Pitch.E, Octave = 6, Duration = Duration.sixteenth };
            var note16 = new Note { Beat = 4.75, Step = Pitch.F, Octave = 6, Duration = Duration.sixteenth };

            var note20 = new Note { Beat = 1.00, Step = Pitch.C, Octave = 4, Duration = Duration.eigth };
            var note21 = new Note { Beat = 1.50, Step = Pitch.D, Octave = 3, Duration = Duration.eigth };
            var note22 = new Note { Beat = 2.00, Step = Pitch.E, Octave = 5, Duration = Duration.eigth };
            var note23 = new Note { Beat = 2.50, Step = Pitch.F, Octave = 2, Duration = Duration.eigth };
            var note24 = new Note { Beat = 3.00, Step = Pitch.FSharp, Octave = 4, Duration = Duration.eigth };
            var note25 = new Note { Beat = 3.50, Step = Pitch.GFlat, Octave = 4, Duration = Duration.eigth };
            var note26 = new Note { Beat = 4.00, Step = Pitch.A, Octave = 6, Duration = Duration.eigth };
            var note27 = new Note { Beat = 4.50, Step = Pitch.B, Octave = 7, Duration = Duration.eigth };

            var note30 = new Note { Beat = 1, Step = Pitch.C, Octave = 5, Duration = Duration.quarter };
            var note31 = new Note { Beat = 2, Step = Pitch.D, Octave = 5, Duration = Duration.quarter };
            var note32 = new Note { Beat = 3, Step = Pitch.FSharp, Octave = 4, Duration = Duration.quarter };
            var note33 = new Note { Beat = 4, Step = Pitch.B, Octave = 5, Duration = Duration.quarter };

            var note40 = new Note { Beat = 1, Step = Pitch.D, Octave = 4, Duration = Duration.half };
            var note41 = new Note { Beat = 3, Step = Pitch.D, Octave = 5, Duration = Duration.half };

            var note50 = new Note { Beat = 1, Step = Pitch.D, Octave = 4, Duration = Duration.whole };

        }
    }
}
