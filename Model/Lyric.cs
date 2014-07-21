using System.Xml.Serialization;

namespace Model
{
    public class Lyric
    {
        [XmlText]
        public string Text { get; set; }
        [XmlAttribute("Syllabic")]
        public Syllabic Syllabic { get; set; }
    }
}
