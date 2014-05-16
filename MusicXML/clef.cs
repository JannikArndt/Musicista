namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class clef
    {

        private clefsign signField;

        private string lineField;

        private string clefoctavechangeField;

        private string numberField;

        private yesno additionalField;

        private bool additionalFieldSpecified;

        private symbolsize sizeField;

        private bool sizeFieldSpecified;

        private yesno afterbarlineField;

        private bool afterbarlineFieldSpecified;

        private yesno printobjectField;

        private bool printobjectFieldSpecified;


        public clefsign sign
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


        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string line
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


        [System.Xml.Serialization.XmlElementAttribute("clef-octave-change", DataType = "integer")]
        public string clefoctavechange
        {
            get
            {
                return this.clefoctavechangeField;
            }
            set
            {
                this.clefoctavechangeField = value;
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


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public yesno additional
        {
            get
            {
                return this.additionalField;
            }
            set
            {
                this.additionalField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool additionalSpecified
        {
            get
            {
                return this.additionalFieldSpecified;
            }
            set
            {
                this.additionalFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public symbolsize size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sizeSpecified
        {
            get
            {
                return this.sizeFieldSpecified;
            }
            set
            {
                this.sizeFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("after-barline")]
        public yesno afterbarline
        {
            get
            {
                return this.afterbarlineField;
            }
            set
            {
                this.afterbarlineField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool afterbarlineSpecified
        {
            get
            {
                return this.afterbarlineFieldSpecified;
            }
            set
            {
                this.afterbarlineFieldSpecified = value;
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
    }
}