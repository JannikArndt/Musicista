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
    public class level
    {
        private yesno bracketField;

        private bool bracketFieldSpecified;
        private yesno parenthesesField;

        private bool parenthesesFieldSpecified;
        private yesno referenceField;

        private bool referenceFieldSpecified;

        private symbolsize sizeField;

        private bool sizeFieldSpecified;

        private string valueField;

    
        [XmlAttribute]
        public yesno reference
        {
            get { return referenceField; }
            set { referenceField = value; }
        }

    
        [XmlIgnore]
        public bool referenceSpecified
        {
            get { return referenceFieldSpecified; }
            set { referenceFieldSpecified = value; }
        }

    
        [XmlAttribute]
        public yesno parentheses
        {
            get { return parenthesesField; }
            set { parenthesesField = value; }
        }

    
        [XmlIgnore]
        public bool parenthesesSpecified
        {
            get { return parenthesesFieldSpecified; }
            set { parenthesesFieldSpecified = value; }
        }

    
        [XmlAttribute]
        public yesno bracket
        {
            get { return bracketField; }
            set { bracketField = value; }
        }

    
        [XmlIgnore]
        public bool bracketSpecified
        {
            get { return bracketFieldSpecified; }
            set { bracketFieldSpecified = value; }
        }

    
        [XmlAttribute]
        public symbolsize size
        {
            get { return sizeField; }
            set { sizeField = value; }
        }

    
        [XmlIgnore]
        public bool sizeSpecified
        {
            get { return sizeFieldSpecified; }
            set { sizeFieldSpecified = value; }
        }

    
        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}