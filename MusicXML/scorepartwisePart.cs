using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
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