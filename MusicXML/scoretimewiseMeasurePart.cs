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
    public class ScoretimewiseMeasurePart
    {
        [XmlElement("attributes", typeof(attributes)), XmlElement("backup", typeof(backup)), XmlElement("barline", typeof(barline)),
         XmlElement("bookmark", typeof(bookmark)), XmlElement("direction", typeof(direction)), XmlElement("figured-bass", typeof(figuredbass)),
         XmlElement("forward", typeof(forward)), XmlElement("grouping", typeof(grouping)), XmlElement("harmony", typeof(harmony)),
         XmlElement("link", typeof(link)), XmlElement("note", typeof(Note.Note)), XmlElement("print", typeof(print)), XmlElement("sound", typeof(sound))]
        public object[] Items { get; set; }


        [XmlAttribute(DataType = "IDREF")]
        public string id { get; set; }
    }
}