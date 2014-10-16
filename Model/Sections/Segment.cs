using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model.Sections
{
    /// <summary>
    /// Represents the largest logical unit in a Movement, i.e. Exposition, Development, Reprise, Coda or Andante, Presto, Trio, ... or an aria or tutti segment
    /// </summary>
    public class Segment
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }
        [XmlElement("Passage")]
        public List<Passage> Passages { get; set; }
        [XmlIgnore]
        public Movement ParentMovement { get; set; }

        public Segment()
        {
        }
    }
}
