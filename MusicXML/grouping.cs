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
    public class grouping
    {
        private feature[] featureField;

        private string memberofField;
        private string numberField;
        private startstopsingle typeField;

        public grouping()
        {
            numberField = "1";
        }

    
        [XmlElement("feature")]
        public feature[] feature
        {
            get { return featureField; }
            set { featureField = value; }
        }

    
        [XmlAttribute]
        public startstopsingle type
        {
            get { return typeField; }
            set { typeField = value; }
        }

    
        [XmlAttribute(DataType = "token")]
        [DefaultValue("1")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }

    
        [XmlAttribute("member-of", DataType = "token")]
        public string memberof
        {
            get { return memberofField; }
            set { memberofField = value; }
        }
    }
}