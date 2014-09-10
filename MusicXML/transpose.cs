using System;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    public class transpose
    {
        [XmlElement(DataType = "integer")]
        public string diatonic { get; set; }


        public decimal chromatic { get; set; }


        [XmlElement("octave-change", DataType = "integer")]
        public string octavechange { get; set; }


        public empty @double { get; set; }


        [XmlAttribute(DataType = "positiveInteger")]
        public string number { get; set; }
    }
}