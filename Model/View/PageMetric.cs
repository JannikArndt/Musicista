using System.Xml.Serialization;

namespace Model.View
{
    public class PageMetric
    {
        [XmlAttribute]
        public double Width { get; set; }

        [XmlAttribute]
        public double Height { get; set; }
    }
}
