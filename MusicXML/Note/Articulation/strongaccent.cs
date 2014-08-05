using MusicXML.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note.Articulation
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "strong-accent")]
    public class strongaccent : Emptyplacement
    {
        public strongaccent()
        {
            type = updown.up;
        }


        [XmlAttribute, DefaultValue(updown.up)]
        public updown type { get; set; }
    }
}