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
    public class note
    {
        [XmlElement("chord", typeof(empty)), XmlElement("cue", typeof(empty)), XmlElement("duration", typeof(decimal)), XmlElement("grace", typeof(grace)), XmlElement("pitch", typeof(pitch)), XmlElement("rest", typeof(rest)), XmlElement("tie", typeof(tie)), XmlElement("unpitched", typeof(unpitched)), XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items { get; set; }


        [XmlElement("ItemsElementName"), XmlIgnore]
        public ItemsChoiceType1[] ItemsElementName { get; set; }


        public instrument instrument { get; set; }


        public formattedtext footnote { get; set; }


        public level level { get; set; }


        public string voice { get; set; }


        public notetype type { get; set; }


        [XmlElement("dot")]
        public emptyplacement[] dot { get; set; }


        public accidental accidental { get; set; }


        [XmlElement("time-modification")]
        public timemodification timemodification { get; set; }


        public stem stem { get; set; }


        public notehead notehead { get; set; }


        [XmlElement("notehead-text")]
        public noteheadtext noteheadtext { get; set; }


        [XmlElement(DataType = "positiveInteger")]
        public string staff { get; set; }


        [XmlElement("beam")]
        public beam[] beam { get; set; }


        [XmlElement("notations")]
        public notations[] notations { get; set; }


        [XmlElement("lyric")]
        public lyric[] lyric { get; set; }


        public play play { get; set; }


        [XmlAttribute("default-x")]
        public decimal defaultx { get; set; }


        [XmlIgnore]
        public bool defaultxSpecified { get; set; }


        [XmlAttribute("default-y")]
        public decimal defaulty { get; set; }


        [XmlIgnore]
        public bool defaultySpecified { get; set; }


        [XmlAttribute("relative-x")]
        public decimal relativex { get; set; }


        [XmlIgnore]
        public bool relativexSpecified { get; set; }


        [XmlAttribute("relative-y")]
        public decimal relativey { get; set; }


        [XmlIgnore]
        public bool relativeySpecified { get; set; }


        [XmlAttribute("font-family", DataType = "token")]
        public string fontfamily { get; set; }


        [XmlAttribute("font-style")]
        public fontstyle fontstyle { get; set; }


        [XmlIgnore]
        public bool fontstyleSpecified { get; set; }


        [XmlAttribute("font-size")]
        public string fontsize { get; set; }


        [XmlAttribute("font-weight")]
        public fontweight fontweight { get; set; }


        [XmlIgnore]
        public bool fontweightSpecified { get; set; }


        [XmlAttribute(DataType = "token")]
        public string color { get; set; }


        [XmlAttribute("print-dot")]
        public yesno printdot { get; set; }


        [XmlIgnore]
        public bool printdotSpecified { get; set; }


        [XmlAttribute("print-lyric")]
        public yesno printlyric { get; set; }


        [XmlIgnore]
        public bool printlyricSpecified { get; set; }


        [XmlAttribute]
        public decimal dynamics { get; set; }


        [XmlIgnore]
        public bool dynamicsSpecified { get; set; }


        [XmlAttribute("end-dynamics")]
        public decimal enddynamics { get; set; }


        [XmlIgnore]
        public bool enddynamicsSpecified { get; set; }


        [XmlAttribute]
        public decimal attack { get; set; }


        [XmlIgnore]
        public bool attackSpecified { get; set; }


        [XmlAttribute]
        public decimal release { get; set; }


        [XmlIgnore]
        public bool releaseSpecified { get; set; }


        [XmlAttribute("time-only", DataType = "token")]
        public string timeonly { get; set; }


        [XmlAttribute]
        public yesno pizzicato { get; set; }


        [XmlIgnore]
        public bool pizzicatoSpecified { get; set; }
    }
}