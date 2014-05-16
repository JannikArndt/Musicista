namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class bass
    {

        private bassstep bassstepField;

        private bassalter bassalterField;


        [System.Xml.Serialization.XmlElementAttribute("bass-step")]
        public bassstep bassstep
        {
            get
            {
                return this.bassstepField;
            }
            set
            {
                this.bassstepField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("bass-alter")]
        public bassalter bassalter
        {
            get
            {
                return this.bassalterField;
            }
            set
            {
                this.bassalterField = value;
            }
        }
    }
}