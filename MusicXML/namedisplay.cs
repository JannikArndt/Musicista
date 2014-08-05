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
    [XmlType(TypeName = "name-display")]
    public class namedisplay
    {
        private object[] itemsField;

        private yesno printobjectField;

        private bool printobjectFieldSpecified;


        [XmlElement("accidental-text", typeof (accidentaltext))]
        [XmlElement("display-text", typeof (FormattedText))]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlAttribute("print-object")]
        public yesno printobject
        {
            get { return printobjectField; }
            set { printobjectField = value; }
        }


        [XmlIgnore]
        public bool printobjectSpecified
        {
            get { return printobjectFieldSpecified; }
            set { printobjectFieldSpecified = value; }
        }
    }
}