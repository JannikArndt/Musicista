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
    public class lyric
    {
        [XmlElement("text")]
        public textelementdata Text { get; set; }




        [XmlElement("elision", typeof(textfontcolor)), XmlElement("extend", typeof(extend)), XmlElement("humming", typeof(empty)), XmlElement("laughing", typeof(empty)), XmlElement("syllabic", typeof(syllabic)), XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items { get; set; }


        [XmlElement("ItemsElementName"), XmlIgnore]
        public ItemsChoiceType6[] ItemsElementName { get; set; }


        [XmlElement("end-line")]
        public empty Endline { get; set; }


        [XmlElement("end-paragraph")]
        public empty endparagraph { get; set; }


        public formattedtext footnote { get; set; }


        public level level { get; set; }


        [XmlAttribute(DataType = "NMTOKEN")]
        public string number { get; set; }


        [XmlAttribute(DataType = "token")]
        public string name { get; set; }


        [XmlAttribute]
        public leftcenterright justify { get; set; }


        [XmlIgnore]
        public bool justifySpecified { get; set; }


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


        [XmlAttribute]
        public abovebelow placement { get; set; }


        [XmlIgnore]
        public bool placementSpecified { get; set; }


        [XmlAttribute(DataType = "token")]
        public string color { get; set; }


        [XmlAttribute("print-object")]
        public yesno printobject { get; set; }


        [XmlIgnore]
        public bool printobjectSpecified { get; set; }
    }
}