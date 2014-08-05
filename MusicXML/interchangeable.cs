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
    public class interchangeable
    {
        private string[] beatsField;

        private string[] beattypeField;

        private timeseparator separatorField;

        private bool separatorFieldSpecified;
        private timesymbol symbolField;

        private bool symbolFieldSpecified;
        private timerelation timerelationField;

        private bool timerelationFieldSpecified;


        [XmlElement("time-relation")]
        public timerelation timerelation
        {
            get { return timerelationField; }
            set { timerelationField = value; }
        }


        [XmlIgnore]
        public bool timerelationSpecified
        {
            get { return timerelationFieldSpecified; }
            set { timerelationFieldSpecified = value; }
        }


        [XmlElement("beats")]
        public string[] beats
        {
            get { return beatsField; }
            set { beatsField = value; }
        }


        [XmlElement("beat-type")]
        public string[] beattype
        {
            get { return beattypeField; }
            set { beattypeField = value; }
        }


        [XmlAttribute]
        public timesymbol symbol
        {
            get { return symbolField; }
            set { symbolField = value; }
        }


        [XmlIgnore]
        public bool symbolSpecified
        {
            get { return symbolFieldSpecified; }
            set { symbolFieldSpecified = value; }
        }


        [XmlAttribute]
        public timeseparator separator
        {
            get { return separatorField; }
            set { separatorField = value; }
        }


        [XmlIgnore]
        public bool separatorSpecified
        {
            get { return separatorFieldSpecified; }
            set { separatorFieldSpecified = value; }
        }
    }
}