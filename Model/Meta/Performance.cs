using System.Xml.Serialization;

namespace Model.Meta
{
    public class Performance : DateEvent
    {
        [XmlAttribute("IsFirst")]
        public bool IsFirstPerformance { get; set; }
    }
}
