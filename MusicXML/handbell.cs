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
    public class handbell
    {
        private abovebelow placementField;

        private bool placementFieldSpecified;

        private handbellvalue valueField;


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
        public handbellvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}