namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class arrow
    {

        private object[] itemsField;

        private abovebelow placementField;

        private bool placementFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("arrow-direction", typeof(arrowdirection))]
        [System.Xml.Serialization.XmlElementAttribute("arrow-style", typeof(arrowstyle))]
        [System.Xml.Serialization.XmlElementAttribute("circular-arrow", typeof(circulararrow))]
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