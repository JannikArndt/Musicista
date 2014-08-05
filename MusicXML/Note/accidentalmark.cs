using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML.Note
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "accidental-mark")]
    public class accidentalmark
    {
        private abovebelow placementField;

        private bool placementFieldSpecified;

        private accidentalvalue valueField;


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
        public accidentalvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}