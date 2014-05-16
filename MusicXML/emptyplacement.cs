namespace MusicXML
{
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(strongaccent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(heeltoe))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "empty-placement")]
    public partial class emptyplacement
    {

        private abovebelow placementField;

        private bool placementFieldSpecified;


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