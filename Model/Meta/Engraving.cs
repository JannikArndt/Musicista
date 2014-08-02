using System.Xml.Serialization;

namespace Model.Meta
{
    public class Engraving : DateEvent
    {
        [XmlAttribute("Typesetter")]
        public string Typesetter { get; set; }

        public Engraving(string typesetter, int year, int month, int day, string place, string notes = "")
            : base(year, month, day, place, notes)
        {
            Typesetter = typesetter;
        }

        public Engraving() { }
    }
}
