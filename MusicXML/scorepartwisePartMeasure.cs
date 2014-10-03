using MusicXML.Enums;
using MusicXML.Note;
using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class ScorePartwisePartMeasure
    {
        [XmlElement("attributes")]
        public attributes Attributes { get; set; }


        [XmlElement("backup", typeof(backup)),
        XmlElement("barline", typeof(barline)),
        XmlElement("bookmark", typeof(bookmark)),
        XmlElement("direction", typeof(Direction)),
        XmlElement("figured-bass", typeof(figuredbass)),
        XmlElement("forward", typeof(forward)),
        XmlElement("grouping", typeof(grouping)),
        XmlElement("harmony", typeof(harmony)),
        XmlElement("link", typeof(link)),
        XmlElement("note", typeof(Note.Note)),
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