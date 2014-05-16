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
    [XmlType(TypeName = "measure-numbering")]
    public class measurenumbering
    {
        private measurenumberingvalue valueField;


        [XmlText]
        public measurenumberingvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}