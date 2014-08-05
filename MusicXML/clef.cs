using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class Clef
    {
        public clefsign sign { get; set; }


        [XmlElement(DataType = "integer")]
        public string line { get; set; }


        [XmlElement("clef-octave-change", DataType = "integer")]
        public string clefoctavechange { get; set; }


        [XmlAttribute(DataType = "positiveInteger")]
        public string number { get; set; }


        [XmlAttribute]
        public yesno additional { get; set; }


        [XmlIgnore]
        public bool additionalSpecified { get; set; }


        [XmlAttribute]
        public symbolsize size { get; set; }


        [XmlIgnore]
        public bool sizeSpecified { get; set; }


        [XmlAttribute("after-barline")]
        public yesno afterbarline { get; set; }


        [XmlIgnore]
        public bool afterbarlineSpecified { get; set; }


        [XmlAttribute("print-object")]
        public yesno printobject { get; set; }


        [XmlIgnore]
        public bool printobjectSpecified { get; set; }
    }
}