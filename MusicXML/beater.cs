namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class beater
    {

        private tipdirection tipField;

        private bool tipFieldSpecified;

        private beatervalue valueField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public tipdirection tip
        {
            get
            {
                return this.tipField;
            }
            set
            {
                this.tipField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool tipSpecified
        {
            get
            {
                return this.tipFieldSpecified;
            }
            set
            {
                this.tipFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlTextAttribute()]
        public beatervalue Value
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