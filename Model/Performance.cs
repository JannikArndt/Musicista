using System.Xml.Serialization;

namespace Model
{
    public class Performance : DateEvent
    {
        [XmlAttribute("IsFirst")]
        public bool IsFirstPerformance { get; set; }
    }
}
