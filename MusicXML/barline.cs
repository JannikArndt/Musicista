using MusicXML.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class barline
    {
        public barline()
        {
            location = rightleftmiddle.right;
        }


        [XmlElement("bar-style")]
        public barstylecolor barstyle { get; set; }


        public formattedtext footnote { get; set; }


        public level level { get; set; }


        [XmlElement("wavy-line")]
        public wavyline wavyline { get; set; }


        public emptyprintstylealign segno { get; set; }


        public emptyprintstylealign coda { get; set; }


        [XmlElement("fermata")]
        public fermata[] fermata { get; set; }


        public ending ending { get; set; }


        public repeat repeat { get; set; }


        [XmlAttribute, DefaultValue(rightleftmiddle.right)]
        public rightleftmiddle location { get; set; }


        [XmlAttribute("segno", DataType = "token")]
        public string segno1 { get; set; }


        [XmlAttribute("coda", DataType = "token")]
        public string coda1 { get; set; }


        [XmlAttribute]
        public decimal divisions { get; set; }


        [XmlIgnore]
        public bool divisionsSpecified { get; set; }
    }
}