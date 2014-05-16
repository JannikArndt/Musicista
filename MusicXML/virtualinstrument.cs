namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "virtual-instrument")]
    public partial class virtualinstrument
    {

        private string virtuallibraryField;

        private string virtualnameField;


        [System.Xml.Serialization.XmlElementAttribute("virtual-library")]
        public string virtuallibrary
        {
            get
            {
                return this.virtuallibraryField;
            }
            set
            {
                this.virtuallibraryField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("virtual-name")]
        public string virtualname
        {
            get
            {
                return this.virtualnameField;
            }
            set
            {
                this.virtualnameField = value;
            }
        }
    }
}