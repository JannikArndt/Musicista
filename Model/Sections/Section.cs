using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model.Sections
{
    public class Section
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlElement("Movements")]
        public List<Movement> Movements { get; set; }
        [XmlIgnore]
        public Piece ParentPiece { get; set; }

        public Section()
        {
        }
    }
}
