using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML.Note.Articulation
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "breath-mark")]
    public class breathmark
    {
        private abovebelow placementField;

        private bool placementFieldSpecified;

        private breathmarkvalue valueField;


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
        public breathmarkvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}