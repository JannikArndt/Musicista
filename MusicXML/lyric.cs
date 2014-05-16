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
    public class lyric
    {
        private string colorField;
        private decimal defaultxField;

        private bool defaultxFieldSpecified;

        private decimal defaultyField;

        private bool defaultyFieldSpecified;
        private empty endlineField;

        private empty endparagraphField;

        private formattedtext footnoteField;
        private ItemsChoiceType6[] itemsElementNameField;
        private object[] itemsField;

        private leftcenterright justifyField;

        private bool justifyFieldSpecified;
        private level levelField;
        private string nameField;
        private string numberField;

        private abovebelow placementField;

        private bool placementFieldSpecified;

        private yesno printobjectField;

        private bool printobjectFieldSpecified;
        private decimal relativexField;

        private bool relativexFieldSpecified;

        private decimal relativeyField;

        private bool relativeyFieldSpecified;


        [XmlElement("elision", typeof(textfontcolor))]
        [XmlElement("extend", typeof(extend))]
        [XmlElement("humming", typeof(empty))]
        [XmlElement("laughing", typeof(empty))]
        [XmlElement("syllabic", typeof(syllabic))]
        [XmlElement("text", typeof(textelementdata))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlElement("ItemsElementName")]
        [XmlIgnore]
        public ItemsChoiceType6[] ItemsElementName
        {
            get { return itemsElementNameField; }
            set { itemsElementNameField = value; }
        }


        [XmlElement("end-line")]
        public empty endline
        {
            get { return endlineField; }
            set { endlineField = value; }
        }


        [XmlElement("end-paragraph")]
        public empty endparagraph
        {
            get { return endparagraphField; }
            set { endparagraphField = value; }
        }


        public formattedtext footnote
        {
            get { return footnoteField; }
            set { footnoteField = value; }
        }


        public level level
        {
            get { return levelField; }
            set { levelField = value; }
        }


        [XmlAttribute(DataType = "NMTOKEN")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string name
        {
            get { return nameField; }
            set { nameField = value; }
        }


        [XmlAttribute]
        public leftcenterright justify
        {
            get { return justifyField; }
            set { justifyField = value; }
        }


        [XmlIgnore]
        public bool justifySpecified
        {
            get { return justifyFieldSpecified; }
            set { justifyFieldSpecified = value; }
        }


        [XmlAttribute("default-x")]
        public decimal defaultx
        {
            get { return defaultxField; }
            set { defaultxField = value; }
        }


        [XmlIgnore]
        public bool defaultxSpecified
        {
            get { return defaultxFieldSpecified; }
            set { defaultxFieldSpecified = value; }
        }


        [XmlAttribute("default-y")]
        public decimal defaulty
        {
            get { return defaultyField; }
            set { defaultyField = value; }
        }


        [XmlIgnore]
        public bool defaultySpecified
        {
            get { return defaultyFieldSpecified; }
            set { defaultyFieldSpecified = value; }
        }


        [XmlAttribute("relative-x")]
        public decimal relativex
        {
            get { return relativexField; }
            set { relativexField = value; }
        }


        [XmlIgnore]
        public bool relativexSpecified
        {
            get { return relativexFieldSpecified; }
            set { relativexFieldSpecified = value; }
        }


        [XmlAttribute("relative-y")]
        public decimal relativey
        {
            get { return relativeyField; }
            set { relativeyField = value; }
        }


        [XmlIgnore]
        public bool relativeySpecified
        {
            get { return relativeyFieldSpecified; }
            set { relativeyFieldSpecified = value; }
        }


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


        [XmlAttribute(DataType = "token")]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }


        [XmlAttribute("print-object")]
        public yesno printobject
        {
            get { return printobjectField; }
            set { printobjectField = value; }
        }


        [XmlIgnore]
        public bool printobjectSpecified
        {
            get { return printobjectFieldSpecified; }
            set { printobjectFieldSpecified = value; }
        }
    }
}