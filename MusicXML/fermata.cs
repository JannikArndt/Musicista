using MusicXML.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class Fermata
    {
        [XmlAttribute]
        public uprightinverted Type { get; set; }


        [XmlIgnore]
        public bool TypeSpecified { get; set; }


        [XmlText]
        public fermatashape Value { get; set; }
    }
}