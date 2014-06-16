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
    public class time
    {
        [XmlElement("beat-type")]
        public int BeatType { get; set; }

        [XmlElement("beats")]
        public int Beats { get; set; }

        [XmlElement("interchangeable")]
        public interchangeable Interchangeable { get; set; }

        [XmlElement("senza-misura")]
        public string SenzaMisura { get; set; }


        [XmlElement("ItemsElementName"), XmlIgnore]
        public ItemsChoiceType9[] ItemsElementName { get; set; }


        [XmlAttribute(DataType = "positiveInteger")]
        public string number { get; set; }


        [XmlAttribute]
        public timesymbol symbol { get; set; }


        [XmlIgnore]
        public bool symbolSpecified { get; set; }


        [XmlAttribute]
        public timeseparator separator { get; set; }


        [XmlIgnore]
        public bool separatorSpecified { get; set; }


        [XmlAttribute("print-object")]
        public yesno printobject { get; set; }


        [XmlIgnore]
        public bool printobjectSpecified { get; set; }
    }
}