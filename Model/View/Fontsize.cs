using System.Xml.Serialization;

namespace Model.View
{
    public class Fontsize
    {
        [XmlAttribute("Title")]
        public double Title { get; set; }

        [XmlAttribute("Movement")]
        public double Movement { get; set; }

        [XmlAttribute("Composer")]
        public double Composer { get; set; }
    }
}
