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
    public class arrow
    {
        private object[] itemsField;

        private abovebelow placementField;

        private bool placementFieldSpecified;


        [XmlElement("arrow-direction", typeof (arrowdirection))]
        [XmlElement("arrow-style", typeof (arrowstyle))]
        [XmlElement("circular-arrow", typeof (circulararrow))]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
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