namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class figure
    {

        private styletext prefixField;

        private styletext figurenumberField;

        private styletext suffixField;

        private extend extendField;


        public styletext prefix
        {
            get
            {
                return this.prefixField;
            }
            set
            {
                this.prefixField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("figure-number")]
        public styletext figurenumber
        {
            get
            {
                return this.figurenumberField;
            }
            set
            {
                this.figurenumberField = value;
            }
        }


        public styletext suffix
        {
            get
            {
                return this.suffixField;
            }
            set
            {
                this.suffixField = value;
            }
        }


        public extend extend
        {
            get
            {
                return this.extendField;
            }
            set
            {
                this.extendField = value;
            }
        }
    }
}