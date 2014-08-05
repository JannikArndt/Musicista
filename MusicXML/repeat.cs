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
    public class repeat
    {
        private backwardforward directionField;

        private string timesField;

        private winged wingedField;

        private bool wingedFieldSpecified;

    
        [XmlAttribute]
        public backwardforward direction
        {
            get { return directionField; }
            set { directionField = value; }
        }

    
        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string times
        {
            get { return timesField; }
            set { timesField = value; }
        }

    
        [XmlAttribute]
        public winged winged
        {
            get { return wingedField; }
            set { wingedField = value; }
        }

    
        [XmlIgnore]
        public bool wingedSpecified
        {
            get { return wingedFieldSpecified; }
            set { wingedFieldSpecified = value; }
        }
    }
}