using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "first-fret")]
    public class firstfret
    {
        private leftright locationField;

        private bool locationFieldSpecified;
        private string textField;

        private string valueField;


        [XmlAttribute(DataType = "token")]
        public string text
        {
            get { return textField; }
            set { textField = value; }
        }


        [XmlAttribute]
        public leftright location
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


        [XmlText(DataType = "positiveInteger")]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}