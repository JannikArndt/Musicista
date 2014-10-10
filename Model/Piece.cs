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
    /// <summary>
    /// The root element for every piece. 
    /// </summary>
    public class Piece
    {
        [XmlAttribute("Version")]
        public string Version = "1.0";

        /// <summary>
        /// Contains the title, composer, etc.
        /// </summary>
        [XmlElement("Meta")]
        public MetaData Meta { get; set; }

        /// <summary>
        /// InstrumentGroups like woodwind, brass, percussion, strings, ...
        /// </summary>
        [XmlArray("Instruments")]
        public List<InstrumentGroup> InstrumentGroups { get; set; }

        /// <summary>
        /// A shortcut directly to all instruments. Also see InstrumentGroups
        /// </summary>
        [XmlIgnore]
        public List<Instrument> Instruments
        {
            get { return InstrumentGroups.SelectMany(item => item.Instruments).ToList(); }
        }

        /// <summary>
        /// An InstrumentGroup has several Instruments which can have several staves (e.g. for the piano). These are all staves.
        /// </summary>
        [XmlIgnore]
        public List<Staff> Staves
        {
            get { return InstrumentGroups.SelectMany(item => item.Instruments).SelectMany(instrument => instrument.Staves).ToList(); }
        }

        /// <summary>
        /// The topmost musical elements
        /// </summary>
        [XmlArray("Score")]
        public List<Section> Sections { get; set; }

        /// <summary>
        ///  Shortcut to Sections > Movements
        /// </summary>
        [XmlIgnore]
        public List<Movement> Movements { get { return Sections.SelectMany(section => section.Movements).ToList(); } }

        /// <summary>
        /// Shortcut to Sections > Movements > Segments
        /// </summary>
        [XmlIgnore]
        public List<Segment> Segments { get { return Movements.SelectMany(movement => movement.Segments).ToList(); } }

        /// <summary>
        /// Shortcut to Sections > Movements > Segments > Passages
        /// </summary>
        [XmlIgnore]
        public List<Passage> Passages { get { return Segments.SelectMany(segment => segment.Passages).ToList(); } }

        /// <summary>
        /// Shortcut to Sections > Movements > Segments > Passages > MeasureGroups
        /// </summary>
        [XmlIgnore]
        public List<MeasureGroup> MeasureGroups { get { return Passages.SelectMany(passage => passage.MeasureGroups).ToList(); } }

        /// <summary>
        /// Shortcut to Sections > Movements > Segments > Passages > MeasureGroups > Measures
        /// </summary>
        [XmlIgnore]
        public List<Measure> Measures { get { return MeasureGroups.SelectMany(measureGroup => measureGroup.Measures).ToList(); } }

        /// <summary>
        /// Stores references to the actual music, for example for themes.
        /// </summary>
        [XmlArray("Parts")]
        public List<Part> Parts { get; set; }

        /// <summary>
        /// Stores text with a reference to the music
        /// </summary>
        [XmlArray("Comments")]
        public List<Comment> Comments { get; set; }

        /// <summary>
        /// Stores style information
        /// </summary>
        [XmlElement("Style")]
        public Style Style { get; set; }

        /// <summary>
        /// Empty contructor for Deserialization
        /// </summary>
        public Piece()
        {
            Meta = new MetaData();
            InstrumentGroups = new List<InstrumentGroup>();
            Parts = new List<Part>();
            Style = new Style();
            Sections = new List<Section>();
            CorrectParentConnections();
        }

        /// <summary>
        /// Contructor for normal initialization. Use initialize-parameter to initialize EVERY object and list and avoid null-pointer-exceptions.
        /// </summary>
        /// <param name="initialize">Wheter all objects and lists should be initialized</param>
        /// <param name="username">What the Typesetter is set to</param>
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

        /// <summary>
        /// Go through the hierarchy and set the parent-reference for every element.
        /// </summary>
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
