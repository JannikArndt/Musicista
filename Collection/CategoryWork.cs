using Model;
using System.Xml.Serialization;

namespace Collection
{
    /// <summary>
    /// A container for a works name, opus, filepath and meta data
    /// </summary>
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
