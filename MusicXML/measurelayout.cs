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
    [XmlType(TypeName = "measure-layout")]
    public class measurelayout
    {
        private decimal measuredistanceField;

        private bool measuredistanceFieldSpecified;


        [XmlElement("measure-distance")]
        public decimal measuredistance
        {
            get { return measuredistanceField; }
            set { measuredistanceField = value; }
        }


        [XmlIgnore]
        public bool measuredistanceSpecified
        {
            get { return measuredistanceFieldSpecified; }
            set { measuredistanceFieldSpecified = value; }
        }
    }
}