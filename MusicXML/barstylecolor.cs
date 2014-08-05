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
    [XmlType(TypeName = "bar-style-color")]
    public class barstylecolor
    {
        private string colorField;

        private barstyle valueField;


        [XmlAttribute(DataType = "token")]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }


        [XmlText]
        public barstyle Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}