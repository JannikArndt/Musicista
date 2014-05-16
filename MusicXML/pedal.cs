namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class pedal
    {

        private startstopchangecontinue typeField;

        private yesno lineField;

        private bool lineFieldSpecified;

        private yesno signField;

        private bool signFieldSpecified;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public startstopchangecontinue type
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


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public yesno line
        {
            get
            {
                return this.lineField;
            }
            set
            {
                this.lineField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lineSpecified
        {
            get
            {
                return this.lineFieldSpecified;
            }
            set
            {
                this.lineFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public yesno sign
        {
            get
            {
                return this.signField;
            }
            set
            {
                this.signField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool signSpecified
        {
            get
            {
                return this.signFieldSpecified;
            }
            set
            {
                this.signFieldSpecified = value;
            }
        }
    }
}