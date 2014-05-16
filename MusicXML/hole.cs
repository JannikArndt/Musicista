namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class hole
    {

        private string holetypeField;

        private holeclosed holeclosedField;

        private string holeshapeField;

        private abovebelow placementField;

        private bool placementFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("hole-type")]
        public string holetype
        {
            get
            {
                return this.holetypeField;
            }
            set
            {
                this.holetypeField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("hole-closed")]
        public holeclosed holeclosed
        {
            get
            {
                return this.holeclosedField;
            }
            set
            {
                this.holeclosedField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("hole-shape")]
        public string holeshape
        {
            get
            {
                return this.holeshapeField;
            }
            set
            {
                this.holeshapeField = value;
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