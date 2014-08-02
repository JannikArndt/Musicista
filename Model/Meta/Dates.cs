using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model.Meta
{
    public class Dates
    {
        [XmlElement("Composition")]
        public DateEvent DateOfComposition { get; set; }
        [XmlElement("Performances")]
        public List<Performance> Performances { get; set; }
        [XmlElement("Publications")]
        public List<Publication> Publications { get; set; }
        [XmlElement("Engraving")]
        public Engraving Engraving { get; set; }

        [XmlElement("Other")]
        public List<DateEvent> Other { get; set; }

        public Dates()
        {
            Performances = new List<Performance>();
            Publications = new List<Publication>();
            Other = new List<DateEvent>();
            Engraving = new Engraving();
        }
    }
}
