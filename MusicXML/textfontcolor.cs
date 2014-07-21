using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "text-font-color")]
    public class textfontcolor
    {
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


        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string underline { get; set; }


        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string overline { get; set; }


        [XmlAttribute("line-through", DataType = "nonNegativeInteger")]
        public string linethrough { get; set; }


        [XmlAttribute]
        public decimal rotation { get; set; }


        [XmlIgnore]
        public bool rotationSpecified { get; set; }


        [XmlAttribute("letter-spacing")]
        public string letterspacing { get; set; }


        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang { get; set; }


        [XmlAttribute]
        public textdirection dir { get; set; }


        [XmlIgnore]
        public bool dirSpecified { get; set; }


        [XmlText]
        public string Value { get; set; }
    }
}