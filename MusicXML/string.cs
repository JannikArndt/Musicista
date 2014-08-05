using MusicXML.Enums;
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
    public class @string
    {
        private abovebelow placementField;

        private bool placementFieldSpecified;

        private string valueField;


        [XmlAttribute]
        public abovebelow placement
        {
            get { return placementField; }
            set { placementField = value; }
        }


        [XmlIgnore]
        public bool placementSpecified
        {
            get { return placementFieldSpecified; }
            set { placementFieldSpecified = value; }
        }


        [XmlText(DataType = "positiveInteger")]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}