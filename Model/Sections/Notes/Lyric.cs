using System.Xml.Serialization;

namespace Model.Sections.Notes
{
    /// <summary>
    /// Represents a lyric, which consists of text, line and a Syllabic to connect it to other lyrics
    /// </summary>
    public class Lyric
    {
        [XmlText]
        public string Text { get; set; }
        [XmlAttribute("Line")]
        public int Line { get; set; }
        [XmlAttribute("Syllabic")]
        public Syllabic Syllabic { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
