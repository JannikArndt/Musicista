namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "empty-font")]
    public partial class emptyfont
    {

        private string fontfamilyField;

        private fontstyle fontstyleField;

        private bool fontstyleFieldSpecified;

        private string fontsizeField;

        private fontweight fontweightField;

        private bool fontweightFieldSpecified;


        [System.Xml.Serialization.XmlAttributeAttribute("font-family", DataType = "token")]
        public string fontfamily
        {
            get
            {
                return this.fontfamilyField;
            }
            set
            {
                this.fontfamilyField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("font-style")]
        public fontstyle fontstyle
        {
            get
            {
                return this.fontstyleField;
            }
            set
            {
                this.fontstyleField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fontstyleSpecified
        {
            get
            {
                return this.fontstyleFieldSpecified;
            }
            set
            {
                this.fontstyleFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("font-size")]
        public string fontsize
        {
            get
            {
                return this.fontsizeField;
            }
            set
            {
                this.fontsizeField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("font-weight")]
        public fontweight fontweight
        {
            get
            {
                return this.fontweightField;
            }
            set
            {
                this.fontweightField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fontweightSpecified
        {
            get
            {
                return this.fontweightFieldSpecified;
            }
            set
            {
                this.fontweightFieldSpecified = value;
            }
        }
    }
}