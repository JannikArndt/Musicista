using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class metronome
    {
        private object[] itemsField;

        private leftcenterright justifyField;

        private bool justifyFieldSpecified;

        private yesno parenthesesField;

        private bool parenthesesFieldSpecified;


        [XmlElement("beat-unit", typeof (notetypevalue))]
        [XmlElement("beat-unit-dot", typeof (empty))]
        [XmlElement("metronome-note", typeof (metronomenote))]
        [XmlElement("metronome-relation", typeof (string))]
        [XmlElement("per-minute", typeof (perminute))]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlAttribute]
        public leftcenterright justify
        {
            get { return justifyField; }
            set { justifyField = value; }
        }


        [XmlIgnore]
        public bool justifySpecified
        {
            get { return justifyFieldSpecified; }
            set { justifyFieldSpecified = value; }
        }


        [XmlAttribute]
        public yesno parentheses
        {
            get { return parenthesesField; }
            set { parenthesesField = value; }
        }


        [XmlIgnore]
        public bool parenthesesSpecified
        {
            get { return parenthesesFieldSpecified; }
            set { parenthesesFieldSpecified = value; }
        }
    }
}