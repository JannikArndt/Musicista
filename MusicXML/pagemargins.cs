namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "page-margins")]
    public partial class pagemargins
    {

        private decimal leftmarginField;

        private decimal rightmarginField;

        private decimal topmarginField;

        private decimal bottommarginField;

        private margintype typeField;

        private bool typeFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("left-margin")]
        public decimal leftmargin
        {
            get
            {
                return this.leftmarginField;
            }
            set
            {
                this.leftmarginField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("right-margin")]
        public decimal rightmargin
        {
            get
            {
                return this.rightmarginField;
            }
            set
            {
                this.rightmarginField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("top-margin")]
        public decimal topmargin
        {
            get
            {
                return this.topmarginField;
            }
            set
            {
                this.topmarginField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("bottom-margin")]
        public decimal bottommargin
        {
            get
            {
                return this.bottommarginField;
            }
            set
            {
                this.bottommarginField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public margintype type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }
    }
}