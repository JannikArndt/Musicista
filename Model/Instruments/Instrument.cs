
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model.Instruments
{
    public class Instrument
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Shortname")]
        public string Shortname { get; set; }

        [XmlAttribute("Transposition")]
        public int Transposition { get; set; }


        [XmlElement("Midi")]
        public MidiSettings MidiSettings { get; set; }

        [XmlElement("Staff")]
        public List<Staff> Staves { get; set; }

        public bool ShouldSerializeMidiSettings()
        {
            return MidiSettings != null && (MidiSettings.Channel != 0 || MidiSettings.Program != 0
                || MidiSettings.Volume != 0 || MidiSettings.Pan != 0
                || !string.IsNullOrEmpty(MidiSettings.Library)
                || !string.IsNullOrEmpty(MidiSettings.LibraryInstrument));
        }

        public Instrument()
        {
            MidiSettings = new MidiSettings();
            Staves = new List<Staff>();
        }
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
