using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Model.Instruments
{
    /// <summary>
    /// Represents a group of Instruments, i.e. woodwinds or strings.
    /// </summary>
    public class InstrumentGroup : INotifyPropertyChanged
    {
        private string _name;

        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }

        [XmlAttribute("BraceType")]
        public BraceType BraceType { get; set; }

        [XmlElement("Instrument")]
        public List<Instrument> Instruments { get; set; }

        public InstrumentGroup()
        {
            Instruments = new List<Instrument>();
            Name = "";
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name))
                return Name;
            return string.Join(", ", Instruments);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
