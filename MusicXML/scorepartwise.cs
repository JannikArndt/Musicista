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
    [XmlRoot("score-partwise", Namespace = "", IsNullable = false)]
    public class ScorePartwise : MusicXMLScore
    {
        public ScorePartwise()
        {
            Version = "2.0";
        }

        [XmlElement("part")]
        public ScorePartwisePart[] Part { get; set; }
    }
}