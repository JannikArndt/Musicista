using System.ComponentModel;
using System.Xml.Serialization;

namespace MusicXML
{
    public abstract class MusicXMLScore
    {
        [XmlElement("work")]
        public work Work { get; set; }

        [XmlElement("movement-number")]
        public string MovementNumber { get; set; }

        [XmlElement("movement-title")]
        public string MovementTitle { get; set; }

        [XmlElement("identification")]
        public Identification Identification { get; set; }

        [XmlElement("defaults")]
        public defaults Defaults { get; set; }

        [XmlElement("credit")]
        public credit[] Credit { get; set; }

        [XmlElement("part-list")]
        public Partlist PartList { get; set; }

        [XmlAttribute("version", DataType = "token"), DefaultValue("2.0")]
        public string Version { get; set; }
    }
}
