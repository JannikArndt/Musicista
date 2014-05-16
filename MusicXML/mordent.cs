namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class mordent : emptytrillsound
    {

        private yesno longField;

        private bool longFieldSpecified;

        private abovebelow approachField;

        private bool approachFieldSpecified;

        private abovebelow departureField;

        private bool departureFieldSpecified;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public yesno @long
        {
            get
            {
                return this.longField;
            }
            set
            {
                this.longField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool longSpecified
        {
            get
            {
                return this.longFieldSpecified;
            }
            set
            {
                this.longFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public abovebelow approach
        {
            get
            {
                return this.approachField;
            }
            set
            {
                this.approachField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool approachSpecified
        {
            get
            {
                return this.approachFieldSpecified;
            }
            set
            {
                this.approachFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public abovebelow departure
        {
            get
            {
                return this.departureField;
            }
            set
            {
                this.departureField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool departureSpecified
        {
            get
            {
                return this.departureFieldSpecified;
            }
            set
            {
                this.departureFieldSpecified = value;
            }
        }
    }
}