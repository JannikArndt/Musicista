namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "midi-device")]
    public partial class mididevice
    {

        private string portField;

        private string idField;

        private string valueField;


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public string port
        {
            get
            {
                return this.portField;
            }
            set
            {
                this.portField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "IDREF")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }


        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
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