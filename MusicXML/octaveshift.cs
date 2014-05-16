namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "octave-shift")]
    public partial class octaveshift
    {

        private updownstopcontinue typeField;

        private string numberField;

        private string sizeField;

        private decimal dashlengthField;

        private bool dashlengthFieldSpecified;

        private decimal spacelengthField;

        private bool spacelengthFieldSpecified;

        public octaveshift()
        {
            this.sizeField = "8";
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public updownstopcontinue type
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


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        [System.ComponentModel.DefaultValueAttribute("8")]
        public string size
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


        [System.Xml.Serialization.XmlAttributeAttribute("dash-length")]
        public decimal dashlength
        {
            get
            {
                return this.dashlengthField;
            }
            set
            {
                this.dashlengthField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dashlengthSpecified
        {
            get
            {
                return this.dashlengthFieldSpecified;
            }
            set
            {
                this.dashlengthFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("space-length")]
        public decimal spacelength
        {
            get
            {
                return this.spacelengthField;
            }
            set
            {
                this.spacelengthField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool spacelengthSpecified
        {
            get
            {
                return this.spacelengthFieldSpecified;
            }
            set
            {
                this.spacelengthFieldSpecified = value;
            }
        }
    }
}