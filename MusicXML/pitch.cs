using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class pitch
    {
        public step step { get; set; }


        public decimal alter { get; set; }


        [XmlIgnore]
        public bool alterSpecified { get; set; }


        [XmlElement(DataType = "integer")]
        public string octave { get; set; }
    }
}