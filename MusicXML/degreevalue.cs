namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "degree-value")]
    public partial class degreevalue
    {

        private degreesymbolvalue symbolField;

        private bool symbolFieldSpecified;

        private string textField;

        private string valueField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public degreesymbolvalue symbol
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


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }


        [System.Xml.Serialization.XmlTextAttribute(DataType = "positiveInteger")]
        public string Value
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