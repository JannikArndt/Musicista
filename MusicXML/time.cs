namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class time
    {

        private object[] itemsField;

        private ItemsChoiceType9[] itemsElementNameField;

        private string numberField;

        private timesymbol symbolField;

        private bool symbolFieldSpecified;

        private timeseparator separatorField;

        private bool separatorFieldSpecified;

        private yesno printobjectField;

        private bool printobjectFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("beat-type", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("beats", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("interchangeable", typeof(interchangeable))]
        [System.Xml.Serialization.XmlElementAttribute("senza-misura", typeof(string))]
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
        public ItemsChoiceType9[] ItemsElementName
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


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public timesymbol symbol
        {
            get
            {
                return this.symbolField;
            }
            set
            {
                this.symbolField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool symbolSpecified
        {
            get
            {
                return this.symbolFieldSpecified;
            }
            set
            {
                this.symbolFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public timeseparator separator
        {
            get
            {
                return this.separatorField;
            }
            set
            {
                this.separatorField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool separatorSpecified
        {
            get
            {
                return this.separatorFieldSpecified;
            }
            set
            {
                this.separatorFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("print-object")]
        public yesno printobject
        {
            get
            {
                return this.printobjectField;
            }
            set
            {
                this.printobjectField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool printobjectSpecified
        {
            get
            {
                return this.printobjectFieldSpecified;
            }
            set
            {
                this.printobjectFieldSpecified = value;
            }
        }
    }
}