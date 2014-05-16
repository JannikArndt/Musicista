using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [GeneratedCode("xsd", "4.0.30319.33440")]
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