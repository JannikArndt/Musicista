
using System.Xml.Serialization;

namespace Model
{
    public class Instrument
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlText]
        public string Name { get; set; }

        public Instrument() { }
        public Instrument(string name = "", int id = 0)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return ID + ": " + Name;
        }
    }
}
