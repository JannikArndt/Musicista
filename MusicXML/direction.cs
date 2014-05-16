namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class direction
    {

        private directiontype[] directiontypeField;

        private offset offsetField;

        private formattedtext footnoteField;

        private level levelField;

        private string voiceField;

        private string staffField;

        private sound soundField;

        private abovebelow placementField;

        private bool placementFieldSpecified;

        private yesno directiveField;

        private bool directiveFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("direction-type")]
        public directiontype[] directiontype
        {
            get
            {
                return this.directiontypeField;
            }
            set
            {
                this.directiontypeField = value;
            }
        }


        public offset offset
        {
            get
            {
                return this.offsetField;
            }
            set
            {
                this.offsetField = value;
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


        public string voice
        {
            get
            {
                return this.voiceField;
            }
            set
            {
                this.voiceField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
        public string staff
        {
            get
            {
                return this.staffField;
            }
            set
            {
                this.staffField = value;
            }
        }


        public sound sound
        {
            get
            {
                return this.soundField;
            }
            set
            {
                this.soundField = value;
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


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public yesno directive
        {
            get
            {
                return this.directiveField;
            }
            set
            {
                this.directiveField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool directiveSpecified
        {
            get
            {
                return this.directiveFieldSpecified;
            }
            set
            {
                this.directiveFieldSpecified = value;
            }
        }
    }
}