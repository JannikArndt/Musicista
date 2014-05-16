namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class stick
    {

        private sticktype sticktypeField;

        private stickmaterial stickmaterialField;

        private tipdirection tipField;

        private bool tipFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("stick-type")]
        public sticktype sticktype
        {
            get
            {
                return this.sticktypeField;
            }
            set
            {
                this.sticktypeField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("stick-material")]
        public stickmaterial stickmaterial
        {
            get
            {
                return this.stickmaterialField;
            }
            set
            {
                this.stickmaterialField = value;
            }
        }


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
    }
}