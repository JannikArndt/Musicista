using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Collection
{
    /// <summary>
    /// Represents a composer in a collection. A composer has works in various categories.
    /// </summary>
    public class CollectionComposer
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Born")]
        public int Born { get; set; }
        [XmlAttribute("Died")]
        public int Died { get; set; }
        [XmlAttribute("Image")]
        public string Image { get; set; }
        [XmlIgnore]
        public int CountWorks { get { return Categories.Sum(collectionCategory => collectionCategory.Works.Count); } }
        [XmlIgnore]
        public string Dates { get { return "(" + Born + "-" + Died + ")"; } }
        [XmlElement("Category")]
        public List<CollectionCategory> Categories { get; set; }
    }
}
