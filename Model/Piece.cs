using Model.Instruments;
using Model.Meta;
using Model.Sections;
using Model.Sections.Attributes;
using Model.Sections.Notes;
using Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Model
{
    public class Piece
    {
        [XmlAttribute("Version")]
        public string Version = "1.0";

        [XmlElement("Meta")]
        public MetaData Meta { get; set; }

        [XmlArray("Instruments")]
        public List<InstrumentGroup> InstrumentGroups { get; set; }

        [XmlIgnore]
        public List<Instrument> Instruments
        {
            get { return InstrumentGroups.SelectMany(item => item.Instruments).ToList(); }
        }
        [XmlIgnore]
        public List<Staff> Staves
        {
            get { return InstrumentGroups.SelectMany(item => item.Instruments).SelectMany(instrument => instrument.Staves).ToList(); }
        }

        [XmlArray("Score")]
        public List<Section> Sections { get; set; }

        [XmlIgnore]
        public List<Movement> Movements { get { return Sections.SelectMany(section => section.Movements).ToList(); } }
        [XmlIgnore]
        public List<Segment> Segments { get { return Movements.SelectMany(movement => movement.Segments).ToList(); } }
        [XmlIgnore]
        public List<Passage> Passages { get { return Segments.SelectMany(segment => segment.Passages).ToList(); } }
        [XmlIgnore]
        public List<MeasureGroup> MeasureGroups { get { return Passages.SelectMany(passage => passage.MeasureGroups).ToList(); } }
        [XmlIgnore]
        public List<Measure> Measures { get { return MeasureGroups.SelectMany(measureGroup => measureGroup.Measures).ToList(); } }
        [XmlArray("Parts")]
        public List<Part> Parts { get; set; }
        [XmlArray("Comments")]
        public List<Comment> Comments { get; set; }

        [XmlElement("Style")]
        public Style Style { get; set; }

        public Piece()
        {
            Meta = new MetaData();
            InstrumentGroups = new List<InstrumentGroup>();
            Parts = new List<Part>();
            Style = new Style();
            Sections = new List<Section> 
                { new Section
                {Movements = new List<Movement>
                    {new Movement
                        {Segments = new List<Segment>
                            {new Segment
                                {Passages = new List<Passage>
                                    {new Passage{MeasureGroups = new List<MeasureGroup>()}}
                                }
                            }
                        }
                    }
                } 
                };
            CorrectParentConnections();
        }

        public Piece(bool initialize = true, string username = "")
        {
            if (initialize)
            {
                Meta = new MetaData
                {
                    Dates = new Dates { Engraving = new Engraving { Date = DateTime.Now, Typesetter = username } }
                };
                var inst1 = new Instrument
                {
                    Name = "Instrument 1",
                    Staves = new List<Staff> { new Staff { ID = 0 } }
                };
                InstrumentGroups = new List<InstrumentGroup>
                {
                    new InstrumentGroup{Instruments = new List<Instrument>{inst1}}
                };
                Parts = new List<Part>();
                Style = new Style();

                var restMeasure = new MeasureGroup
                {
                    KeySignature = new MusicalKey(Step.C, Gender.Major),
                    TimeSignature = new TimeSignature(4, 4),
                    MeasureNumber = 1,
                    Measures = new List<Measure>
                    {
                        new Measure
                        {
                            Clef = Clef.Treble,
                            Instrument = inst1,
                            Staff = inst1.Staves[0],
                            Symbols = new List<Symbol> {new Rest {Duration = Duration.Whole, Beat = 1.0}}
                        }
                    }
                };


                Sections = new List<Section> 
                { new Section
                {Movements = new List<Movement>
                    {new Movement
                        {Segments = new List<Segment>
                            {new Segment
                                {Passages = new List<Passage>
                                    {new Passage{MeasureGroups = new List<MeasureGroup>
                                    {
                                        restMeasure
                                    }}}
                                }
                            }
                        }
                    }
                } 
                };
                CorrectParentConnections();
            }
        }

        public void CorrectParentConnections()
        {
            foreach (var section in Sections)
            {
                section.ParentPiece = this;
                foreach (var movement in section.Movements)
                {
                    movement.ParentSection = section;
                    foreach (var segment in movement.Segments)
                    {
                        segment.ParentMovement = movement;
                        foreach (var passage in segment.Passages)
                        {
                            passage.ParentSegment = segment;
                            foreach (var measureGroup in passage.MeasureGroups)
                            {
                                measureGroup.ParentPassage = passage;
                                foreach (var measure in measureGroup.Measures)
                                {
                                    measure.ParentMeasureGroup = measureGroup;
                                    measure.Instrument = Instruments.FirstOrDefault(inst => inst.ID == measure.InstrumentID);
                                    foreach (var symbol in measure.Symbols)
                                        symbol.ParentMeasure = measure;
                                }
                            }
                        }
                    }
                }
            }
            // same for the Parts
            foreach (var part in Parts.Where(part => part.Passage != null))
            {
                part.BelongsToMovement = Movements.FirstOrDefault(movement => movement.Number == part.MovementID);
                foreach (var measureGroup in part.Passage.MeasureGroups)
                {
                    measureGroup.ParentPassage = part.Passage;
                    foreach (var measure in measureGroup.Measures)
                    {
                        measure.ParentMeasureGroup = measureGroup;
                        foreach (var symbol in measure.Symbols)
                            symbol.ParentMeasure = measure;
                    }
                }
            }
        }
    }
}
