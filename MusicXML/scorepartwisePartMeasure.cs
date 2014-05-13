using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class ScorePartwisePartMeasure
    {
        [XmlElement("attributes", typeof(attributes)),
        XmlElement("backup", typeof(backup)),
        XmlElement("barline", typeof(barline)),
        XmlElement("bookmark", typeof(bookmark)),
        XmlElement("direction", typeof(direction)),
        XmlElement("figured-bass", typeof(figuredbass)),
        XmlElement("forward", typeof(forward)),
        XmlElement("grouping", typeof(grouping)),
        XmlElement("harmony", typeof(harmony)),
        XmlElement("link", typeof(link)),
        XmlElement("note", typeof(note)),
        XmlElement("print", typeof(print)),
        XmlElement("sound", typeof(sound))]
        public object[] Items { get; set; }


        [XmlAttribute(DataType = "token")]
        public string number { get; set; }


        [XmlAttribute]
        public yesno @implicit { get; set; }


        [XmlIgnore]
        public bool implicitSpecified { get; set; }


        [XmlAttribute("non-controlling")]
        public yesno noncontrolling { get; set; }


        [XmlIgnore]
        public bool noncontrollingSpecified { get; set; }


        [XmlAttribute]
        public decimal width { get; set; }


        [XmlIgnore]
        public bool widthSpecified { get; set; }
    }
}