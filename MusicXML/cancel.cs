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
    public class cancel
    {
        private cancellocation locationField;

        private bool locationFieldSpecified;

        private string valueField;


        [XmlAttribute]
        public cancellocation location
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


        [XmlText(DataType = "integer")]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}