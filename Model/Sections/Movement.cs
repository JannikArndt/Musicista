using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model.Sections
{
    public class Movement
    {
        [XmlAttribute("Name")]
        public string Name { get; set; } // Mahler 2, IV: "Urlicht"
        [XmlAttribute("Number")]
        public int Number { get; set; }
        [XmlAttribute("Tempo")]
        public string Tempo { get; set; } // Adagio
        [XmlAttribute("BeatsPerMinute")]
        public int BeatsPerMinute { get; set; } // see Beethovens symphonies
        [XmlElement("Segments")]
        public List<Segment> Segments { get; set; } // Andante, Presto, Trio
        [XmlIgnore]
        public Section ParentSection { get; set; }
        public Movement()
        {
        }
    }
}
