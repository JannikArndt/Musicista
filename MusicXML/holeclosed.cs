using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "hole-closed")]
    public class holeclosed
    {
        private holeclosedlocation locationField;

        private bool locationFieldSpecified;

        private holeclosedvalue valueField;


        [XmlAttribute]
        public holeclosedlocation location
        {
            get { return locationField; }
            set { locationField = value; }
        }


        [XmlIgnore]
        public bool locationSpecified
        {
            get { return locationFieldSpecified; }
            set { locationFieldSpecified = value; }
        }


        [XmlText]
        public holeclosedvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}