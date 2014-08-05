using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML.Note.Articulation
{
    [XmlInclude(typeof(strongaccent))]
    [XmlInclude(typeof(heeltoe))]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "empty-placement")]
    public class Emptyplacement
    {
        [XmlAttribute]
        public abovebelow placement { get; set; }


        [XmlIgnore]
        public bool placementSpecified { get; set; }
    }
}