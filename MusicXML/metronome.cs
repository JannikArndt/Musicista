namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class metronome
    {

        private object[] itemsField;

        private leftcenterright justifyField;

        private bool justifyFieldSpecified;

        private yesno parenthesesField;

        private bool parenthesesFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("beat-unit", typeof(notetypevalue))]
        [System.Xml.Serialization.XmlElementAttribute("beat-unit-dot", typeof(empty))]
        [System.Xml.Serialization.XmlElementAttribute("metronome-note", typeof(metronomenote))]
        [System.Xml.Serialization.XmlElementAttribute("metronome-relation", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("per-minute", typeof(perminute))]
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


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public leftcenterright justify
        {
            get
            {
                return this.justifyField;
            }
            set
            {
                this.justifyField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool justifySpecified
        {
            get
            {
                return this.justifyFieldSpecified;
            }
            set
            {
                this.justifyFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public yesno parentheses
        {
            get
            {
                return this.parenthesesField;
            }
            set
            {
                this.parenthesesField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool parenthesesSpecified
        {
            get
            {
                return this.parenthesesFieldSpecified;
            }
            set
            {
                this.parenthesesFieldSpecified = value;
            }
        }
    }
}