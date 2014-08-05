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
    public class hole
    {
        private holeclosed holeclosedField;

        private string holeshapeField;
        private string holetypeField;

        private abovebelow placementField;

        private bool placementFieldSpecified;


        [XmlElement("hole-type")]
        public string holetype
        {
            get { return holetypeField; }
            set { holetypeField = value; }
        }


        [XmlElement("hole-closed")]
        public holeclosed holeclosed
        {
            get { return holeclosedField; }
            set { holeclosedField = value; }
        }


        [XmlElement("hole-shape")]
        public string holeshape
        {
            get { return holeshapeField; }
            set { holeshapeField = value; }
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
    }
}