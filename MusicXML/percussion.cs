namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class percussion
    {

        private object itemField;

        private enclosureshape enclosureField;

        private bool enclosureFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("beater", typeof(beater))]
        [System.Xml.Serialization.XmlElementAttribute("effect", typeof(effect))]
        [System.Xml.Serialization.XmlElementAttribute("glass", typeof(glass))]
        [System.Xml.Serialization.XmlElementAttribute("membrane", typeof(membrane))]
        [System.Xml.Serialization.XmlElementAttribute("metal", typeof(metal))]
        [System.Xml.Serialization.XmlElementAttribute("other-percussion", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("pitched", typeof(pitched))]
        [System.Xml.Serialization.XmlElementAttribute("stick", typeof(stick))]
        [System.Xml.Serialization.XmlElementAttribute("stick-location", typeof(sticklocation))]
        [System.Xml.Serialization.XmlElementAttribute("timpani", typeof(empty))]
        [System.Xml.Serialization.XmlElementAttribute("wood", typeof(wood))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public enclosureshape enclosure
        {
            get
            {
                return this.enclosureField;
            }
            set
            {
                this.enclosureField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool enclosureSpecified
        {
            get
            {
                return this.enclosureFieldSpecified;
            }
            set
            {
                this.enclosureFieldSpecified = value;
            }
        }
    }
}