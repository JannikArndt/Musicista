namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "accordion-registration")]
    public partial class accordionregistration
    {

        private empty accordionhighField;

        private string accordionmiddleField;

        private empty accordionlowField;


        [System.Xml.Serialization.XmlElementAttribute("accordion-high")]
        public empty accordionhigh
        {
            get
            {
                return this.accordionhighField;
            }
            set
            {
                this.accordionhighField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("accordion-middle", DataType = "positiveInteger")]
        public string accordionmiddle
        {
            get
            {
                return this.accordionmiddleField;
            }
            set
            {
                this.accordionmiddleField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("accordion-low")]
        public empty accordionlow
        {
            get
            {
                return this.accordionlowField;
            }
            set
            {
                this.accordionlowField = value;
            }
        }
    }
}