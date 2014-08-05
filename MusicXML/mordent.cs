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
    public class mordent : emptytrillsound
    {
        private abovebelow approachField;

        private bool approachFieldSpecified;

        private abovebelow departureField;

        private bool departureFieldSpecified;
        private yesno longField;

        private bool longFieldSpecified;


        [XmlAttribute]
        public yesno @long
        {
            get { return longField; }
            set { longField = value; }
        }


        [XmlIgnore]
        public bool longSpecified
        {
            get { return longFieldSpecified; }
            set { longFieldSpecified = value; }
        }


        [XmlAttribute]
        public abovebelow approach
        {
            get { return approachField; }
            set { approachField = value; }
        }


        [XmlIgnore]
        public bool approachSpecified
        {
            get { return approachFieldSpecified; }
            set { approachFieldSpecified = value; }
        }


        [XmlAttribute]
        public abovebelow departure
        {
            get { return departureField; }
            set { departureField = value; }
        }


        [XmlIgnore]
        public bool departureSpecified
        {
            get { return departureFieldSpecified; }
            set { departureFieldSpecified = value; }
        }
    }
}