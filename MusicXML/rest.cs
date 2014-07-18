using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class rest
    {
        [XmlElement("display-step")]
        public Step Displaystep { get; set; }


        [XmlElement("display-octave", DataType = "integer")]
        public string Displayoctave { get; set; }


        [XmlAttribute("measure")]
        public yesno Measure { get; set; }


        [XmlIgnore]
        public bool MeasureSpecified { get; set; }
    }
}