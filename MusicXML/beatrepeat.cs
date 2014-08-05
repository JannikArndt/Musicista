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
    [XmlType(TypeName = "beat-repeat")]
    public class beatrepeat
    {
        private empty[] slashdotField;

        private string slashesField;
        private notetypevalue slashtypeField;
        private startstop typeField;

        private yesno usedotsField;

        private bool usedotsFieldSpecified;


        [XmlElement("slash-type")]
        public notetypevalue slashtype
        {
            get { return slashtypeField; }
            set { slashtypeField = value; }
        }


        [XmlElement("slash-dot")]
        public empty[] slashdot
        {
            get { return slashdotField; }
            set { slashdotField = value; }
        }


        [XmlAttribute]
        public startstop type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        public string slashes
        {
            get { return slashesField; }
            set { slashesField = value; }
        }


        [XmlAttribute("use-dots")]
        public yesno usedots
        {
            get { return usedotsField; }
            set { usedotsField = value; }
        }


        [XmlIgnore]
        public bool usedotsSpecified
        {
            get { return usedotsFieldSpecified; }
            set { usedotsFieldSpecified = value; }
        }
    }
}