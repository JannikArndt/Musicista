using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class distance
    {
        private string typeField;

        private decimal valueField;


        [XmlAttribute(DataType = "token")]
        public string type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlText]
        public decimal Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}