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
    public class pedal
    {
        private yesno lineField;

        private bool lineFieldSpecified;

        private yesno signField;

        private bool signFieldSpecified;
        private startstopchangecontinue typeField;


        [XmlAttribute]
        public startstopchangecontinue type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute]
        public yesno line
        {
            get { return lineField; }
            set { lineField = value; }
        }


        [XmlIgnore]
        public bool lineSpecified
        {
            get { return lineFieldSpecified; }
            set { lineFieldSpecified = value; }
        }


        [XmlAttribute]
        public yesno sign
        {
            get { return signField; }
            set { signField = value; }
        }


        [XmlIgnore]
        public bool signSpecified
        {
            get { return signFieldSpecified; }
            set { signFieldSpecified = value; }
        }
    }
}