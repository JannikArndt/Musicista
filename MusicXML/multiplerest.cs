namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "multiple-rest")]
    public partial class multiplerest
    {

        private yesno usesymbolsField;

        private bool usesymbolsFieldSpecified;

        private string valueField;


        [System.Xml.Serialization.XmlAttributeAttribute("use-symbols")]
        public yesno usesymbols
        {
            get
            {
                return this.usesymbolsField;
            }
            set
            {
                this.usesymbolsField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool usesymbolsSpecified
        {
            get
            {
                return this.usesymbolsFieldSpecified;
            }
            set
            {
                this.usesymbolsFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlTextAttribute()]
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