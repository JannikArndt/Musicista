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
    [XmlType(AnonymousType = true)]
    [XmlRoot("score-timewise", Namespace = "", IsNullable = false)]
    public class ScoreTimewise
    {
        public ScoreTimewise()
        {
            Version = "2.0";
        }

        [XmlElement("work")]
        public work Work { get; set; }

        [XmlElement("movement-number")]
        public string MovementNumber { get; set; }

        [XmlElement("movement-title")]
        public string MovementTitle { get; set; }

        [XmlElement("identification")]
        public identification Identification { get; set; }

        [XmlElement("defaults")]
        public defaults Defaults { get; set; }

        [XmlElement("credit")]
        public credit[] Credit { get; set; }

        [XmlElement("part-list")]
        public partlist PartList { get; set; }

        [XmlElement("measure")]
        public scoretimewiseMeasure[] Measure { get; set; }

        [XmlAttribute("version", DataType = "token"), DefaultValue("1.0")]
        public string Version { get; set; }
    }
}