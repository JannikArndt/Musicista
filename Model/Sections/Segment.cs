using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model.Sections
{
    /// <summary>
    /// Andante, Presto, Trio, ...
    /// </summary>
    public class Segment
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }
        [XmlElement("Passages")]
        public List<Passage> Passages { get; set; }
        [XmlIgnore]
        public Movement ParentMovement { get; set; }

        public Segment()
        {
            Passages = new List<Passage> { new Passage { ParentSegment = this } };
        }
    }
}
