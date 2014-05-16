namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "staff-details")]
    public partial class staffdetails
    {

        private stafftype stafftypeField;

        private bool stafftypeFieldSpecified;

        private string stafflinesField;

        private stafftuning[] stafftuningField;

        private string capoField;

        private decimal staffsizeField;

        private bool staffsizeFieldSpecified;

        private string numberField;

        private showfrets showfretsField;

        private bool showfretsFieldSpecified;

        private yesno printobjectField;

        private bool printobjectFieldSpecified;

        private yesno printspacingField;

        private bool printspacingFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("staff-type")]
        public stafftype stafftype
        {
            get
            {
                return this.stafftypeField;
            }
            set
            {
                this.stafftypeField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool stafftypeSpecified
        {
            get
            {
                return this.stafftypeFieldSpecified;
            }
            set
            {
                this.stafftypeFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("staff-lines", DataType = "nonNegativeInteger")]
        public string stafflines
        {
            get
            {
                return this.stafflinesField;
            }
            set
            {
                this.stafflinesField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("staff-tuning")]
        public stafftuning[] stafftuning
        {
            get
            {
                return this.stafftuningField;
            }
            set
            {
                this.stafftuningField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string capo
        {
            get
            {
                return this.capoField;
            }
            set
            {
                this.capoField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("staff-size")]
        public decimal staffsize
        {
            get
            {
                return this.staffsizeField;
            }
            set
            {
                this.staffsizeField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool staffsizeSpecified
        {
            get
            {
                return this.staffsizeFieldSpecified;
            }
            set
            {
                this.staffsizeFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
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


        [System.Xml.Serialization.XmlAttributeAttribute("show-frets")]
        public showfrets showfrets
        {
            get
            {
                return this.showfretsField;
            }
            set
            {
                this.showfretsField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool showfretsSpecified
        {
            get
            {
                return this.showfretsFieldSpecified;
            }
            set
            {
                this.showfretsFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("print-object")]
        public yesno printobject
        {
            get
            {
                return this.printobjectField;
            }
            set
            {
                this.printobjectField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool printobjectSpecified
        {
            get
            {
                return this.printobjectFieldSpecified;
            }
            set
            {
                this.printobjectFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("print-spacing")]
        public yesno printspacing
        {
            get
            {
                return this.printspacingField;
            }
            set
            {
                this.printspacingField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool printspacingSpecified
        {
            get
            {
                return this.printspacingFieldSpecified;
            }
            set
            {
                this.printspacingFieldSpecified = value;
            }
        }
    }
}