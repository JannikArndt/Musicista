using MusicXML.Enums;
using MusicXML.Note.Articulation;
using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class Notations
    {
        public FormattedText Footnote { get; set; }


        public level Level { get; set; }

        [XmlElement("dynamics", typeof(dynamics))]
        public dynamics Dynamics { get; set; }


        [XmlElement("accidental-mark", typeof(accidentalmark))]
        public accidentalmark Accidentalmark { get; set; }


        [XmlElement("arpeggiate", typeof(arpeggiate))]
        public arpeggiate Arpeggiate { get; set; }


        [XmlElement("articulations", typeof(Articulations))]
        public Articulations Articulations { get; set; }



        [XmlElement("fermata", typeof(fermata))]
        public fermata Fermata { get; set; }


        [XmlElement("glissando", typeof(glissando))]
        public glissando Glissando { get; set; }


        [XmlElement("non-arpeggiate", typeof(nonarpeggiate))]
        public nonarpeggiate Nonarpeggiate { get; set; }


        [XmlElement("ornaments", typeof(Ornaments))]
        public Ornaments Ornaments { get; set; }


        [XmlElement("other-notation", typeof(othernotation))]
        public othernotation Othernotation { get; set; }


        [XmlElement("slide", typeof(slide))]
        public slide Slide { get; set; }


        [XmlElement("slur", typeof(slur))]
        public slur Slur { get; set; }


        [XmlElement("technical", typeof(Technical))]
        public Technical Technical { get; set; }


        [XmlElement("tied", typeof(tied))]
        public tied Tied { get; set; }


        [XmlElement("tuplet", typeof(tuplet))]
        public tuplet Tuplet { get; set; }



        [XmlAttribute("print-object")]
        public yesno printobject { get; set; }


        [XmlIgnore]
        public bool printobjectSpecified { get; set; }
    }
}