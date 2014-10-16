
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Model.Instruments
{
    /// <summary>
    /// Represents one instrument, for example a flute, a violin or a piano. This is part of an InstrumentGroup (woodwind, strings, none) and can have multiple staves (for the piano). 
    /// Different voices have different instruments, i.e. Flute 1 and Flute 2 are different instruments, whereas all first Violins are one Instrument.
    /// </summary>
    public class Instrument : INotifyPropertyChanged
    {
        private string _name;

        [XmlAttribute("ID")]
        public int ID { get; set; }

        /// <summary>
        /// The full name, printed in front of the first system.
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// The name that is repeated in front of the second, third, ... system.
        /// </summary>
        [XmlAttribute("Shortname")]
        public string Shortname { get; set; }

        /// <summary>
        /// The half tones by which this instrument is transposed, i.e. a trumpet would be -2, a double bass -12.
        /// </summary>
        [XmlAttribute("Transposition")]
        public int Transposition { get; set; }

        /// <summary>
        /// Midi settings such as channel, instrument, volume, pan and library.
        /// </summary>
        [XmlElement("Midi")]
        public MidiSettings MidiSettings { get; set; }

        /// <summary>
        /// A list of staff objects. A normal instrument has just one, a piano for instance has two.
        /// </summary>
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
