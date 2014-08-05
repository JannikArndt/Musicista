using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;
using MusicXML.Note;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class key
    {
        [XmlElement("fifths", DataType = "integer")]
        public string Fifths { get; set; }

        [XmlElement("mode", typeof (string))]
        public string Mode { get; set; }


        [XmlElement("cancel", typeof (cancel))]
        [XmlElement("key-accidental", typeof (accidentalvalue))]
        [XmlElement("key-alter", typeof (decimal))]
        [XmlElement("key-step", typeof (Step))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items { get; set; }


        [XmlElement("ItemsElementName")]
        [XmlIgnore]
        public ItemsChoiceType8[] ItemsElementName { get; set; }

        [XmlElement("key-octave")]
        public keyoctave[] Keyoctave { get; set; }


        [XmlAttribute(DataType = "positiveInteger")]
        public string number { get; set; }


        [XmlAttribute("print-object")]
        public yesno Printobject { get; set; }


        [XmlIgnore]
        public bool printobjectSpecified { get; set; }
    }
}