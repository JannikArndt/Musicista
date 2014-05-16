namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "first-fret")]
    public partial class firstfret
    {

        private string textField;

        private leftright locationField;

        private bool locationFieldSpecified;

        private string valueField;


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


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public leftright location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool locationSpecified
        {
            get
            {
                return this.locationFieldSpecified;
            }
            set
            {
                this.locationFieldSpecified = value;
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