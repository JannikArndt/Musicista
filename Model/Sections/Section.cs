using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model.Sections
{
    /// <summary>
    /// Represents the largest logic unit of a piece, i.e. an Act in an opera or an Abteilung in a symphony
    /// </summary>
    public class Section
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlElement("Movement")]
        public List<Movement> Movements { get; set; }
        [XmlIgnore]
        public Piece ParentPiece { get; set; }

        public Section()
        {
        }
    }
}
