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
    public class attributes
    {
        public formattedtext footnote { get; set; }


        public level level { get; set; }

        [XmlElement("divisions")]
        public decimal Divisions { get; set; }


        [XmlIgnore]
        public bool divisionsSpecified { get; set; }


        [XmlElement("key")]
        public key[] key { get; set; }


        [XmlElement("time")]
        public time[] time { get; set; }


        [XmlElement(DataType = "nonNegativeInteger")]
        public string staves { get; set; }


        [XmlElement("part-symbol")]
        public partsymbol partsymbol { get; set; }


        [XmlElement(DataType = "nonNegativeInteger")]
        public string instruments { get; set; }


        [XmlElement("clef")]
        public Clef[] clef { get; set; }


        [XmlElement("staff-details")]
        public staffdetails[] staffdetails { get; set; }


        [XmlElement("transpose")]
        public transpose[] transpose { get; set; }


        [XmlElement("directive")]
        public attributesDirective[] directive { get; set; }


        [XmlElement("measure-style")]
        public measurestyle[] measurestyle { get; set; }
    }
}