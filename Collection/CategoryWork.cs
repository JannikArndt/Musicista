using Model;
using System.Xml.Serialization;

namespace Collection
{
    public class CategoryWork
    {
        [XmlAttribute("Name")]
        public string WorkName { get; set; }
        [XmlAttribute("Filepath")]
        public string Filepath { get; set; }
        [XmlElement("Meta")]
        public MetaData MetaData { get; set; }
        [XmlIgnore]
        public string OpusString { get { return MetaData != null && MetaData.Opus != null ? MetaData.Opus.OpusString : ""; } }
    }
}
