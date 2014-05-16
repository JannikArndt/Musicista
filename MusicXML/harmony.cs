namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class harmony
    {

        private object[] itemsField;

        private kind[] kindField;

        private inversion[] inversionField;

        private bass[] bassField;

        private degree[] degreeField;

        private frame frameField;

        private offset offsetField;

        private formattedtext footnoteField;

        private level levelField;

        private string staffField;

        private harmonytype typeField;

        private bool typeFieldSpecified;

        private yesno printobjectField;

        private bool printobjectFieldSpecified;

        private yesno printframeField;

        private bool printframeFieldSpecified;

        private abovebelow placementField;

        private bool placementFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("function", typeof(styletext))]
        [System.Xml.Serialization.XmlElementAttribute("root", typeof(root))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("kind")]
        public kind[] kind
        {
            get
            {
                return this.kindField;
            }
            set
            {
                this.kindField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("inversion")]
        public inversion[] inversion
        {
            get
            {
                return this.inversionField;
            }
            set
            {
                this.inversionField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("bass")]
        public bass[] bass
        {
            get
            {
                return this.bassField;
            }
            set
            {
                this.bassField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("degree")]
        public degree[] degree
        {
            get
            {
                return this.degreeField;
            }
            set
            {
                this.degreeField = value;
            }
        }


        public frame frame
        {
            get
            {
                return this.frameField;
            }
            set
            {
                this.frameField = value;
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


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public harmonytype type
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


        [System.Xml.Serialization.XmlAttributeAttribute("print-frame")]
        public yesno printframe
        {
            get
            {
                return this.printframeField;
            }
            set
            {
                this.printframeField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool printframeSpecified
        {
            get
            {
                return this.printframeFieldSpecified;
            }
            set
            {
                this.printframeFieldSpecified = value;
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
    }
}