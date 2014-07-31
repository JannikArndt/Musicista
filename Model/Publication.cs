using System.Xml.Serialization;

namespace Model
{
    public class Publication : DateEvent
    {
        [XmlAttribute("IsFirst")]
        public bool IsFirstPublication { get; set; }
        [XmlAttribute("Publisher")]
        public string Publisher { get; set; }

        public Publication(string publisher, int year, int month, int day, string place, string notes = "", bool isFirst = false)
            : base(year, month, day, place, notes)
        {
            Publisher = publisher;
            IsFirstPublication = isFirst;
        }

        public Publication() { }
    }
}
