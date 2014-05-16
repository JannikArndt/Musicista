namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class articulations
    {

        private object[] itemsField;

        private ItemsChoiceType4[] itemsElementNameField;


        [System.Xml.Serialization.XmlElementAttribute("accent", typeof(emptyplacement))]
        [System.Xml.Serialization.XmlElementAttribute("breath-mark", typeof(breathmark))]
        [System.Xml.Serialization.XmlElementAttribute("caesura", typeof(emptyplacement))]
        [System.Xml.Serialization.XmlElementAttribute("detached-legato", typeof(emptyplacement))]
        [System.Xml.Serialization.XmlElementAttribute("doit", typeof(emptyline))]
        [System.Xml.Serialization.XmlElementAttribute("falloff", typeof(emptyline))]
        [System.Xml.Serialization.XmlElementAttribute("other-articulation", typeof(placementtext))]
        [System.Xml.Serialization.XmlElementAttribute("plop", typeof(emptyline))]
        [System.Xml.Serialization.XmlElementAttribute("scoop", typeof(emptyline))]
        [System.Xml.Serialization.XmlElementAttribute("spiccato", typeof(emptyplacement))]
        [System.Xml.Serialization.XmlElementAttribute("staccatissimo", typeof(emptyplacement))]
        [System.Xml.Serialization.XmlElementAttribute("staccato", typeof(emptyplacement))]
        [System.Xml.Serialization.XmlElementAttribute("stress", typeof(emptyplacement))]
        [System.Xml.Serialization.XmlElementAttribute("strong-accent", typeof(strongaccent))]
        [System.Xml.Serialization.XmlElementAttribute("tenuto", typeof(emptyplacement))]
        [System.Xml.Serialization.XmlElementAttribute("unstress", typeof(emptyplacement))]
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
        public ItemsChoiceType4[] ItemsElementName
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