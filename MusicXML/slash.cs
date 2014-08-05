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
    public class slash
    {
        private empty[] slashdotField;
        private notetypevalue slashtypeField;

        private startstop typeField;

        private yesno usedotsField;

        private bool usedotsFieldSpecified;

        private yesno usestemsField;

        private bool usestemsFieldSpecified;


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


        [XmlAttribute("use-stems")]
        public yesno usestems
        {
            get { return usestemsField; }
            set { usestemsField = value; }
        }


        [XmlIgnore]
        public bool usestemsSpecified
        {
            get { return usestemsFieldSpecified; }
            set { usestemsFieldSpecified = value; }
        }
    }
}