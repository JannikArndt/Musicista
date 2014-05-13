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
    public class work
    {
        [XmlElement("work-number")]
        public string WorkNumber { get; set; }

        [XmlElement("work-title")]
        public string WorkTitle { get; set; }
        [XmlElement("opus")]
        public opus Opus { get; set; }
    }
}