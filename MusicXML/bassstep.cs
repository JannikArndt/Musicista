using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "bass-step")]
    public class bassstep
    {
        private string textField;

        private Step valueField;


        [XmlAttribute(DataType = "token")]
        public string text
        {
            get { return textField; }
            set { textField = value; }
        }


        [XmlText]
        public Step Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}