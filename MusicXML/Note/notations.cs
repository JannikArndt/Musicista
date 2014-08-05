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
    public class notations
    {
        private formattedtext footnoteField;

        private object[] itemsField;
        private level levelField;

        private yesno printobjectField;

        private bool printobjectFieldSpecified;


        public formattedtext footnote
        {
            get { return footnoteField; }
            set { footnoteField = value; }
        }


        public level level
        {
            get { return levelField; }
            set { levelField = value; }
        }

        [XmlElement("dynamics", typeof(dynamics))]
        public dynamics Dynamics { get; set; }


        [XmlElement("accidental-mark", typeof(accidentalmark))]
        [XmlElement("arpeggiate", typeof(arpeggiate))]
        [XmlElement("articulations", typeof(Articulations))]

        [XmlElement("fermata", typeof(fermata))]
        [XmlElement("glissando", typeof(glissando))]
        [XmlElement("non-arpeggiate", typeof(nonarpeggiate))]
        [XmlElement("ornaments", typeof(ornaments))]
        [XmlElement("other-notation", typeof(othernotation))]
        [XmlElement("slide", typeof(slide))]
        [XmlElement("slur", typeof(slur))]
        [XmlElement("technical", typeof(technical))]
        [XmlElement("tied", typeof(tied))]
        [XmlElement("tuplet", typeof(tuplet))]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlAttribute("print-object")]
        public yesno printobject
        {
            get { return printobjectField; }
            set { printobjectField = value; }
        }


        [XmlIgnore]
        public bool printobjectSpecified
        {
            get { return printobjectFieldSpecified; }
            set { printobjectFieldSpecified = value; }
        }
    }
}