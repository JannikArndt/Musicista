using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "score-part")]
    public class ScorePart
    {
        [XmlElement("identification")]
        public Identification Identification { get; set; }


        [XmlElement("part-name")]
        public string Partname { get; set; }


        [XmlElement("part-name-display")]
        public namedisplay Partnamedisplay { get; set; }


        [XmlElement("part-abbreviation")]
        public string Partabbreviation { get; set; }


        [XmlElement("part-abbreviation-display")]
        public namedisplay Partabbreviationdisplay { get; set; }


        [XmlElement("group")]
        public string[] Group { get; set; }


        [XmlElement("score-instrument")]
        public scoreinstrument[] Scoreinstrument { get; set; }


        [XmlElement("midi-device")]
        public mididevice[] Mididevice { get; set; }


        [XmlElement("midi-instrument")]
        public midiinstrument[] Midiinstrument { get; set; }


        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }

        public override string ToString()
        {
            return Partname;
        }
    }
}