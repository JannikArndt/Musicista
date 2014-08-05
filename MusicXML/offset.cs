using MusicXML.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class offset
    {
        private yesno soundField;

        private bool soundFieldSpecified;

        private decimal valueField;


        [XmlAttribute]
        public yesno sound
        {
            get { return soundField; }
            set { soundField = value; }
        }


        [XmlIgnore]
        public bool soundSpecified
        {
            get { return soundFieldSpecified; }
            set { soundFieldSpecified = value; }
        }


        [XmlText]
        public decimal Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}