using Model.Sections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Model
{
    public class Piece
    {
        [XmlElement("Meta")]
        public MetaData Meta { get; set; }

        [XmlArray("Instruments")]
        public List<Instrument> Instruments { get; set; }

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

        public Piece() { }

        public Piece(bool initialize = true)
        {
            if (initialize)
            {
                Meta = new MetaData();
                Instruments = new List<Instrument>();
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
