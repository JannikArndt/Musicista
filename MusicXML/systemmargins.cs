namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "system-margins")]
    public partial class systemmargins
    {

        private decimal leftmarginField;

        private decimal rightmarginField;


        [System.Xml.Serialization.XmlElementAttribute("left-margin")]
        public decimal leftmargin
        {
            get
            {
                return this.leftmarginField;
            }
            set
            {
                this.leftmarginField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("right-margin")]
        public decimal rightmargin
        {
            get
            {
                return this.rightmarginField;
            }
            set
            {
                this.rightmarginField = value;
            }
        }
    }
}