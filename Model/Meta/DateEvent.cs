using System;
using System.Xml.Serialization;

namespace Model.Meta
{
    public class DateEvent
    {
        [XmlIgnore]
        public DateTime Date { get; set; }
        [XmlAttribute("Date")]
        public string DateString
        {
            get { return Date.ToString("yyyy-MM-dd"); }
            set
            {
                DateTime date; DateTime.TryParse(value, out date); Date = date;
            }
        }
        public bool ShouldSerializeDateString() { return Date != new DateTime(); }


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
