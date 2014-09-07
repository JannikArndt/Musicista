using System.Xml.Serialization;

namespace Model.Sections.Notes
{
    public class Lyric
    {
        [XmlText]
        public string Text { get; set; }
        [XmlAttribute("Line")]
        public int Line { get; set; }
        [XmlAttribute("Syllabic")]
        public Syllabic Syllabic { get; set; }
    }
}
