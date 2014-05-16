using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MusicXML
{
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "text-element-data")]
    public class textelementdata
    {
        private string colorField;
        private textdirection dirField;

        private bool dirFieldSpecified;
        private string fontfamilyField;
        private string fontsizeField;

        private fontstyle fontstyleField;

        private bool fontstyleFieldSpecified;

        private fontweight fontweightField;

        private bool fontweightFieldSpecified;
        private string langField;
        private string letterspacingField;

        private string linethroughField;
        private string overlineField;

        private decimal rotationField;

        private bool rotationFieldSpecified;
        private string underlineField;

        private string valueField;


        [XmlAttribute("font-family", DataType = "token")]
        public string fontfamily
        {
            get { return fontfamilyField; }
            set { fontfamilyField = value; }
        }


        [XmlAttribute("font-style")]
        public fontstyle fontstyle
        {
            get { return fontstyleField; }
            set { fontstyleField = value; }
        }


        [XmlIgnore]
        public bool fontstyleSpecified
        {
            get { return fontstyleFieldSpecified; }
            set { fontstyleFieldSpecified = value; }
        }


        [XmlAttribute("font-size")]
        public string fontsize
        {
            get { return fontsizeField; }
            set { fontsizeField = value; }
        }


        [XmlAttribute("font-weight")]
        public fontweight fontweight
        {
            get { return fontweightField; }
            set { fontweightField = value; }
        }


        [XmlIgnore]
        public bool fontweightSpecified
        {
            get { return fontweightFieldSpecified; }
            set { fontweightFieldSpecified = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }


        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string underline
        {
            get { return underlineField; }
            set { underlineField = value; }
        }


        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string overline
        {
            get { return overlineField; }
            set { overlineField = value; }
        }


        [XmlAttribute("line-through", DataType = "nonNegativeInteger")]
        public string linethrough
        {
            get { return linethroughField; }
            set { linethroughField = value; }
        }


        [XmlAttribute]
        public decimal rotation
        {
            get { return rotationField; }
            set { rotationField = value; }
        }


        [XmlIgnore]
        public bool rotationSpecified
        {
            get { return rotationFieldSpecified; }
            set { rotationFieldSpecified = value; }
        }


        [XmlAttribute("letter-spacing")]
        public string letterspacing
        {
            get { return letterspacingField; }
            set { letterspacingField = value; }
        }


        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get { return langField; }
            set { langField = value; }
        }


        [XmlAttribute]
        public textdirection dir
        {
            get { return dirField; }
            set { dirField = value; }
        }


        [XmlIgnore]
        public bool dirSpecified
        {
            get { return dirFieldSpecified; }
            set { dirFieldSpecified = value; }
        }


        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}