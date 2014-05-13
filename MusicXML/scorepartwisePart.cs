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
    [XmlType(AnonymousType = true)]
    public class ScorePartwisePart
    {
        [XmlElement("measure")]
        public ScorePartwisePartMeasure[] Measure { get; set; }

        [XmlAttribute(DataType = "IDREF")]
        public string id { get; set; }
    }
}