namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class encoding
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;


        [System.Xml.Serialization.XmlElementAttribute("encoder", typeof(typedtext))]
        [System.Xml.Serialization.XmlElementAttribute("encoding-date", typeof(System.DateTime), DataType = "date")]
        [System.Xml.Serialization.XmlElementAttribute("encoding-description", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("software", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("supports", typeof(supports))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
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


        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }
}