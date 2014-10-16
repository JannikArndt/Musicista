
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Collection
{
    /// <summary>
    /// Represents a category of works, i.e. a Symphony, Sonata, Opera, ...
    /// </summary>
    public class CollectionCategory
    {
        [XmlAttribute("Name")]
        public string CategoryName { get; set; }
        [XmlElement("Work")]
        public List<CategoryWork> Works { get; set; }
    }
}
