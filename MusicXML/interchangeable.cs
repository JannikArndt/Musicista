namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class interchangeable
    {

        private timerelation timerelationField;

        private bool timerelationFieldSpecified;

        private string[] beatsField;

        private string[] beattypeField;

        private timesymbol symbolField;

        private bool symbolFieldSpecified;

        private timeseparator separatorField;

        private bool separatorFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("time-relation")]
        public timerelation timerelation
        {
            get
            {
                return this.timerelationField;
            }
            set
            {
                this.timerelationField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool timerelationSpecified
        {
            get
            {
                return this.timerelationFieldSpecified;
            }
            set
            {
                this.timerelationFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("beats")]
        public string[] beats
        {
            get
            {
                return this.beatsField;
            }
            set
            {
                this.beatsField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("beat-type")]
        public string[] beattype
        {
            get
            {
                return this.beattypeField;
            }
            set
            {
                this.beattypeField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public timesymbol symbol
        {
            get
            {
                return this.symbolField;
            }
            set
            {
                this.symbolField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool symbolSpecified
        {
            get
            {
                return this.symbolFieldSpecified;
            }
            set
            {
                this.symbolFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public timeseparator separator
        {
            get
            {
                return this.separatorField;
            }
            set
            {
                this.separatorField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool separatorSpecified
        {
            get
            {
                return this.separatorFieldSpecified;
            }
            set
            {
                this.separatorFieldSpecified = value;
            }
        }
    }
}