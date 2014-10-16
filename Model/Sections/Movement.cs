using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Model.Sections
{
    /// <summary>
    /// Represents a movement of a piece. This can also be used for numbers in an opera.
    /// </summary>
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

        [XmlElement("Segment")]
        public List<Segment> Segments { get; set; } // Andante, Presto, Trio

        [XmlIgnore]
        public List<MeasureGroup> MeasureGroups { get { return Segments.SelectMany(i => i.Passages).SelectMany(j => j.MeasureGroups).ToList(); } }

        [XmlIgnore]
        public Section ParentSection { get; set; }

        public Movement()
        {
        }
    }
}
