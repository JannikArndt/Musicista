namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "hole-closed")]
    public partial class holeclosed
    {

        private holeclosedlocation locationField;

        private bool locationFieldSpecified;

        private holeclosedvalue valueField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public holeclosedlocation location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool locationSpecified
        {
            get
            {
                return this.locationFieldSpecified;
            }
            set
            {
                this.locationFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlTextAttribute()]
        public holeclosedvalue Value
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