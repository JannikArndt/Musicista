namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class attributes
    {

        private formattedtext footnoteField;

        private level levelField;

        private decimal divisionsField;

        private bool divisionsFieldSpecified;

        private key[] keyField;

        private time[] timeField;

        private string stavesField;

        private partsymbol partsymbolField;

        private string instrumentsField;

        private clef[] clefField;

        private staffdetails[] staffdetailsField;

        private transpose[] transposeField;

        private attributesDirective[] directiveField;

        private measurestyle[] measurestyleField;


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


        public decimal divisions
        {
            get
            {
                return this.divisionsField;
            }
            set
            {
                this.divisionsField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool divisionsSpecified
        {
            get
            {
                return this.divisionsFieldSpecified;
            }
            set
            {
                this.divisionsFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("key")]
        public key[] key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("time")]
        public time[] time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string staves
        {
            get
            {
                return this.stavesField;
            }
            set
            {
                this.stavesField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("part-symbol")]
        public partsymbol partsymbol
        {
            get
            {
                return this.partsymbolField;
            }
            set
            {
                this.partsymbolField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string instruments
        {
            get
            {
                return this.instrumentsField;
            }
            set
            {
                this.instrumentsField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("clef")]
        public clef[] clef
        {
            get
            {
                return this.clefField;
            }
            set
            {
                this.clefField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("staff-details")]
        public staffdetails[] staffdetails
        {
            get
            {
                return this.staffdetailsField;
            }
            set
            {
                this.staffdetailsField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("transpose")]
        public transpose[] transpose
        {
            get
            {
                return this.transposeField;
            }
            set
            {
                this.transposeField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("directive")]
        public attributesDirective[] directive
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


        [System.Xml.Serialization.XmlElementAttribute("measure-style")]
        public measurestyle[] measurestyle
        {
            get
            {
                return this.measurestyleField;
            }
            set
            {
                this.measurestyleField = value;
            }
        }
    }
}