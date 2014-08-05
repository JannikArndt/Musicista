using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class instrument
    {
        [XmlAttribute(DataType = "IDREF")]
        public string id { get; set; }
    }
}