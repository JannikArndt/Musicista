using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "identification")]
    public class Identification
    {
        [XmlElement("creator")]
        public Typedtext[] Creator { get; set; }


        [XmlElement("rights")]
        public Typedtext[] Rights { get; set; }

        [XmlElement("encoding")]
        public Encoding Encoding { get; set; }

        [XmlElement("source")]
        public string Source { get; set; }


        [XmlElement("relation")]
        public Typedtext[] Relation { get; set; }


        [XmlArrayItem(IsNullable = false)]
        public miscellaneousfield[] miscellaneous { get; set; }
    }
}