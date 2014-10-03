using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "typed-text")]
    public class Typedtext
    {
        [XmlAttribute("type", DataType = "token")]
        public string Type { get; set; }


        [XmlText]
        public string Value { get; set; }

        public Typedtext(String type, String value)
        {
            Type = type;
            Value = value;
        }

        public Typedtext() { }
    }
}