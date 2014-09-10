using System.Xml.Serialization;

namespace Model.Instruments
{
    public class MidiSettings
    {
        [XmlAttribute("Channel")]
        public int Channel { get; set; }

        [XmlAttribute("Program")]
        public int Program { get; set; }

        [XmlAttribute("Volume")]
        public int Volume { get; set; }

        [XmlAttribute("Pan")]
        public int Pan { get; set; }

        [XmlAttribute("Library")]
        public string Library { get; set; }

        [XmlAttribute("LibraryInstrument")]
        public string LibraryInstrument { get; set; }
    }
}
