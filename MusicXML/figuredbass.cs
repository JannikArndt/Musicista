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
    [XmlType(TypeName = "figured-bass")]
    public class figuredbass
    {
        private decimal durationField;
        private figure[] figureField;

        private formattedtext footnoteField;

        private level levelField;
        private yesno parenthesesField;

        private bool parenthesesFieldSpecified;

        private yesno printdotField;

        private bool printdotFieldSpecified;

        private yesno printlyricField;

        private bool printlyricFieldSpecified;


        [XmlElement("figure")]
        public figure[] figure
        {
            get { return figureField; }
            set { figureField = value; }
        }


        public decimal duration
        {
            get { return durationField; }
            set { durationField = value; }
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


        [XmlAttribute("print-dot")]
        public yesno printdot
        {
            get { return printdotField; }
            set { printdotField = value; }
        }


        [XmlIgnore]
        public bool printdotSpecified
        {
            get { return printdotFieldSpecified; }
            set { printdotFieldSpecified = value; }
        }


        [XmlAttribute("print-lyric")]
        public yesno printlyric
        {
            get { return printlyricField; }
            set { printlyricField = value; }
        }


        [XmlIgnore]
        public bool printlyricSpecified
        {
            get { return printlyricFieldSpecified; }
            set { printlyricFieldSpecified = value; }
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