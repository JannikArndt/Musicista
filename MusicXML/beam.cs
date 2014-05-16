namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class beam
    {

        private string numberField;

        private yesno repeaterField;

        private bool repeaterFieldSpecified;

        private fan fanField;

        private bool fanFieldSpecified;

        private string colorField;

        private beamvalue valueField;

        public beam()
        {
            this.numberField = "1";
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        [System.ComponentModel.DefaultValueAttribute("1")]
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
        public yesno repeater
        {
            get
            {
                return this.repeaterField;
            }
            set
            {
                this.repeaterField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool repeaterSpecified
        {
            get
            {
                return this.repeaterFieldSpecified;
            }
            set
            {
                this.repeaterFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public fan fan
        {
            get
            {
                return this.fanField;
            }
            set
            {
                this.fanField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fanSpecified
        {
            get
            {
                return this.fanFieldSpecified;
            }
            set
            {
                this.fanFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string color
        {
            get
            {
                return this.colorField;
            }
            set
            {
                this.colorField = value;
            }
        }


        [System.Xml.Serialization.XmlTextAttribute()]
        public beamvalue Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}