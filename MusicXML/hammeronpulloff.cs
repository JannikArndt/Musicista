namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "hammer-on-pull-off")]
    public partial class hammeronpulloff
    {

        private startstop typeField;

        private string numberField;

        private abovebelow placementField;

        private bool placementFieldSpecified;

        private string valueField;

        public hammeronpulloff()
        {
            this.numberField = "1";
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public startstop type
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


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        [System.ComponentModel.DefaultValueAttribute("1")]
        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public abovebelow placement
        {
            get
            {
                return this.placementField;
            }
            set
            {
                this.placementField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool placementSpecified
        {
            get
            {
                return this.placementFieldSpecified;
            }
            set
            {
                this.placementFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}