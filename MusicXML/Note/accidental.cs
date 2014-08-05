using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML.Note
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class Accidental
    {
        private accidentalvalue valueField;


        [XmlAttribute]
        public yesno cautionary { get; set; }


        [XmlIgnore]
        public bool cautionarySpecified { get; set; }


        [XmlAttribute]
        public yesno editorial { get; set; }


        [XmlIgnore]
        public bool editorialSpecified { get; set; }


        [XmlAttribute]
        public yesno parentheses { get; set; }


        [XmlIgnore]
        public bool parenthesesSpecified { get; set; }


        [XmlAttribute]
        public yesno bracket { get; set; }


        [XmlIgnore]
        public bool bracketSpecified { get; set; }


        [XmlAttribute]
        public symbolsize size { get; set; }


        [XmlIgnore]
        public bool sizeSpecified { get; set; }


        [XmlText]
        public accidentalvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}