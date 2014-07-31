using System;
using System.Xml.Serialization;

namespace Model
{
    public class DateEvent
    {
        [XmlAttribute("Date")]
        public DateTime Date { get; set; }
        [XmlAttribute("Place")]
        public string Place { get; set; }
        [XmlText]
        public string Notes { get; set; }

        public DateEvent(int year, int month, int day, string place, string notes = "")
        {
            Date = new DateTime(year, month, day);
            Place = place;
            Notes = notes;
        }

        public DateEvent() { }
    }
}
