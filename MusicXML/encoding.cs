using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "encoding")]
    public class Encoding
    {
        [XmlElement("encoder")] public Typedtext Encoder;
        [XmlElement("encoding-date")] public Typedtext EncodingDate;
        [XmlElement("encoding-description")] public Typedtext EncodingDescription;
        [XmlElement("software")] public Typedtext Software;
        [XmlElement("supports")] public Typedtext Supports;
    }
}