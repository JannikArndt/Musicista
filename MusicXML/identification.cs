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
    public class identification
    {
        private typedtext[] creatorField;

        private encoding encodingField;

        private miscellaneousfield[] miscellaneousField;
        private typedtext[] relationField;
        private typedtext[] rightsField;
        private string sourceField;


        [XmlElement("creator")]
        public typedtext[] creator
        {
            get { return creatorField; }
            set { creatorField = value; }
        }


        [XmlElement("rights")]
        public typedtext[] rights
        {
            get { return rightsField; }
            set { rightsField = value; }
        }


        public encoding encoding
        {
            get { return encodingField; }
            set { encodingField = value; }
        }


        public string source
        {
            get { return sourceField; }
            set { sourceField = value; }
        }


        [XmlElement("relation")]
        public typedtext[] relation
        {
            get { return relationField; }
            set { relationField = value; }
        }


        [XmlArrayItem(IsNullable = false)]
        public miscellaneousfield[] miscellaneous
        {
            get { return miscellaneousField; }
            set { miscellaneousField = value; }
        }
    }
}