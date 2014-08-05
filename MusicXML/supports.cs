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
    public class supports
    {
        private string attributeField;
        private string elementField;
        private yesno typeField;

        private string valueField;


        [XmlAttribute]
        public yesno type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute(DataType = "NMTOKEN")]
        public string element
        {
            get { return elementField; }
            set { elementField = value; }
        }


        [XmlAttribute(DataType = "NMTOKEN")]
        public string attribute
        {
            get { return attributeField; }
            set { attributeField = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}