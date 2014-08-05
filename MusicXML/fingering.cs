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
    public class fingering
    {
        private yesno alternateField;

        private bool alternateFieldSpecified;

        private abovebelow placementField;

        private bool placementFieldSpecified;
        private yesno substitutionField;

        private bool substitutionFieldSpecified;

        private string valueField;


        [XmlAttribute]
        public yesno substitution
        {
            get { return substitutionField; }
            set { substitutionField = value; }
        }


        [XmlIgnore]
        public bool substitutionSpecified
        {
            get { return substitutionFieldSpecified; }
            set { substitutionFieldSpecified = value; }
        }


        [XmlAttribute]
        public yesno alternate
        {
            get { return alternateField; }
            set { alternateField = value; }
        }


        [XmlIgnore]
        public bool alternateSpecified
        {
            get { return alternateFieldSpecified; }
            set { alternateFieldSpecified = value; }
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


        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}