namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "figured-bass")]
    public partial class figuredbass
    {

        private figure[] figureField;

        private decimal durationField;

        private formattedtext footnoteField;

        private level levelField;

        private yesno printdotField;

        private bool printdotFieldSpecified;

        private yesno printlyricField;

        private bool printlyricFieldSpecified;

        private yesno parenthesesField;

        private bool parenthesesFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("figure")]
        public figure[] figure
        {
            get
            {
                return this.figureField;
            }
            set
            {
                this.figureField = value;
            }
        }


        public decimal duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }


        public formattedtext footnote
        {
            get
            {
                return this.footnoteField;
            }
            set
            {
                this.footnoteField = value;
            }
        }


        public level level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("print-dot")]
        public yesno printdot
        {
            get
            {
                return this.printdotField;
            }
            set
            {
                this.printdotField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool printdotSpecified
        {
            get
            {
                return this.printdotFieldSpecified;
            }
            set
            {
                this.printdotFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("print-lyric")]
        public yesno printlyric
        {
            get
            {
                return this.printlyricField;
            }
            set
            {
                this.printlyricField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool printlyricSpecified
        {
            get
            {
                return this.printlyricFieldSpecified;
            }
            set
            {
                this.printlyricFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public yesno parentheses
        {
            get
            {
                return this.parenthesesField;
            }
            set
            {
                this.parenthesesField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool parenthesesSpecified
        {
            get
            {
                return this.parenthesesFieldSpecified;
            }
            set
            {
                this.parenthesesFieldSpecified = value;
            }
        }
    }
}