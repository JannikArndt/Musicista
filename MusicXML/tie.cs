using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class Tie
    {
        [XmlAttribute("type")]
        public startstop Type { get; set; }


        [XmlAttribute("time-only", DataType = "token")]
        public string Timeonly { get; set; }
    }
}