﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model.Instruments
{
    public class InstrumentGroup
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("BraceType")]
        public BraceType BraceType { get; set; }

        [XmlElement("Instruments")]
        public List<Instrument> Instruments { get; set; }

        public InstrumentGroup()
        {
            Instruments = new List<Instrument>();
            Name = "";
        }

        public override string ToString()
        {
            return string.Join(", ", Instruments);
        }
    }
}
