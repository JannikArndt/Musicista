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
    [XmlType(TypeName = "typed-text")]
    public class Typedtext
    {
        [XmlAttribute("type", DataType = "token")]
        public string Type { get; set; }


        [XmlText]
        public string Value { get; set; }
    }
}