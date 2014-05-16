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
    public class fermata
    {
        private uprightinverted typeField;

        private bool typeFieldSpecified;

        private fermatashape valueField;


        [XmlAttribute]
        public uprightinverted type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlIgnore]
        public bool typeSpecified
        {
            get { return typeFieldSpecified; }
            set { typeFieldSpecified = value; }
        }


        [XmlText]
        public fermatashape Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}