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
    [XmlType(TypeName = "degree-type")]
    public class degreetype
    {
        private string textField;

        private degreetypevalue valueField;


        [XmlAttribute(DataType = "token")]
        public string text
        {
            get { return textField; }
            set { textField = value; }
        }


        [XmlText]
        public degreetypevalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}