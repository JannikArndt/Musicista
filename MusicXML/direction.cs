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
    public class direction
    {
        private directiontype[] directiontypeField;
        private yesno directiveField;

        private bool directiveFieldSpecified;

        private formattedtext footnoteField;

        private level levelField;
        private offset offsetField;

        private abovebelow placementField;

        private bool placementFieldSpecified;
        private sound soundField;
        private string staffField;
        private string voiceField;


        [XmlElement("direction-type")]
        public directiontype[] directiontype
        {
            get { return directiontypeField; }
            set { directiontypeField = value; }
        }


        public offset offset
        {
            get { return offsetField; }
            set { offsetField = value; }
        }


        public formattedtext footnote
        {
            get { return footnoteField; }
            set { footnoteField = value; }
        }


        public level level
        {
            get { return levelField; }
            set { levelField = value; }
        }


        public string voice
        {
            get { return voiceField; }
            set { voiceField = value; }
        }


        [XmlElement(DataType = "positiveInteger")]
        public string staff
        {
            get { return staffField; }
            set { staffField = value; }
        }


        public sound sound
        {
            get { return soundField; }
            set { soundField = value; }
        }


        [XmlAttribute]
        public abovebelow placement
        {
            get { return placementField; }
            set { placementField = value; }
        }


        [XmlIgnore]
        public bool placementSpecified
        {
            get { return placementFieldSpecified; }
            set { placementFieldSpecified = value; }
        }


        [XmlAttribute]
        public yesno directive
        {
            get { return directiveField; }
            set { directiveField = value; }
        }


        [XmlIgnore]
        public bool directiveSpecified
        {
            get { return directiveFieldSpecified; }
            set { directiveFieldSpecified = value; }
        }
    }
}