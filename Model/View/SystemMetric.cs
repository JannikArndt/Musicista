using System.Xml.Serialization;

namespace Model.View
{
    public class SystemMetric
    {
        [XmlAttribute]
        public double Spacing { get; set; }
    }
}
