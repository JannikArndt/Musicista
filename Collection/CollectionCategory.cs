
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Collection
{
    public class CollectionCategory
    {
        [XmlAttribute("Name")]
        public string CategoryName { get; set; }
        [XmlElement("Work")]
        public List<CategoryWork> Works { get; set; }
    }
}
