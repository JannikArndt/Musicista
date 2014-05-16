namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "beat-repeat")]
    public partial class beatrepeat
    {

        private notetypevalue slashtypeField;

        private empty[] slashdotField;

        private startstop typeField;

        private string slashesField;

        private yesno usedotsField;

        private bool usedotsFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("slash-type")]
        public notetypevalue slashtype
        {
            get
            {
                return this.slashtypeField;
            }
            set
            {
                this.slashtypeField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("slash-dot")]
        public empty[] slashdot
        {
            get
            {
                return this.slashdotField;
            }
            set
            {
                this.slashdotField = value;
            }
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
        public string slashes
        {
            get
            {
                return this.slashesField;
            }
            set
            {
                this.slashesField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("use-dots")]
        public yesno usedots
        {
            get
            {
                return this.usedotsField;
            }
            set
            {
                this.usedotsField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool usedotsSpecified
        {
            get
            {
                return this.usedotsFieldSpecified;
            }
            set
            {
                this.usedotsFieldSpecified = value;
            }
        }
    }
}