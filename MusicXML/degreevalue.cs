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
    [XmlType(TypeName = "degree-value")]
    public class degreevalue
    {
        private degreesymbolvalue symbolField;

        private bool symbolFieldSpecified;

        private string textField;

        private string valueField;


        [XmlAttribute]
        public degreesymbolvalue symbol
        {
            get { return symbolField; }
            set { symbolField = value; }
        }


        [XmlIgnore]
        public bool symbolSpecified
        {
            get { return symbolFieldSpecified; }
            set { symbolFieldSpecified = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string text
        {
            get { return textField; }
            set { textField = value; }
        }


        [XmlText(DataType = "positiveInteger")]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}