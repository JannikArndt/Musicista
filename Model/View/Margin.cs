
using System.Xml.Serialization;

namespace Model.View
{
    public class Margin
    {
        [XmlAttribute]
        public double Left { get; set; }

        [XmlAttribute]
        public double Top { get; set; }

        [XmlAttribute]
        public double Right { get; set; }

        [XmlAttribute]
        public double Bottom { get; set; }

        [XmlAttribute]
        public double BelowTitle { get; set; }
    }
}
