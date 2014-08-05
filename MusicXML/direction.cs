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
    public class Direction
    {
        [XmlElement("direction-type")]
        public DirectionType[] DirectionType { get; set; }


        public offset offset { get; set; }


        public formattedtext footnote { get; set; }


        public level level { get; set; }


        public string voice { get; set; }


        [XmlElement(DataType = "positiveInteger")]
        public string staff { get; set; }


        public sound sound { get; set; }


        [XmlAttribute]
        public abovebelow placement { get; set; }


        [XmlIgnore]
        public bool placementSpecified { get; set; }


        [XmlAttribute]
        public yesno directive { get; set; }


        [XmlIgnore]
        public bool directiveSpecified { get; set; }
    }
}