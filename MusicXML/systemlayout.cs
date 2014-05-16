namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "system-layout")]
    public partial class systemlayout
    {

        private systemmargins systemmarginsField;

        private decimal systemdistanceField;

        private bool systemdistanceFieldSpecified;

        private decimal topsystemdistanceField;

        private bool topsystemdistanceFieldSpecified;

        private systemdividers systemdividersField;


        [System.Xml.Serialization.XmlElementAttribute("system-margins")]
        public systemmargins systemmargins
        {
            get
            {
                return this.systemmarginsField;
            }
            set
            {
                this.systemmarginsField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("system-distance")]
        public decimal systemdistance
        {
            get
            {
                return this.systemdistanceField;
            }
            set
            {
                this.systemdistanceField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool systemdistanceSpecified
        {
            get
            {
                return this.systemdistanceFieldSpecified;
            }
            set
            {
                this.systemdistanceFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("top-system-distance")]
        public decimal topsystemdistance
        {
            get
            {
                return this.topsystemdistanceField;
            }
            set
            {
                this.topsystemdistanceField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool topsystemdistanceSpecified
        {
            get
            {
                return this.topsystemdistanceFieldSpecified;
            }
            set
            {
                this.topsystemdistanceFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("system-dividers")]
        public systemdividers systemdividers
        {
            get
            {
                return this.systemdividersField;
            }
            set
            {
                this.systemdividersField = value;
            }
        }
    }
}