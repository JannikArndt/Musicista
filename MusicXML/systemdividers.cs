namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "system-dividers")]
    public partial class systemdividers
    {

        private emptyprintobjectstylealign leftdividerField;

        private emptyprintobjectstylealign rightdividerField;


        [System.Xml.Serialization.XmlElementAttribute("left-divider")]
        public emptyprintobjectstylealign leftdivider
        {
            get
            {
                return this.leftdividerField;
            }
            set
            {
                this.leftdividerField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("right-divider")]
        public emptyprintobjectstylealign rightdivider
        {
            get
            {
                return this.rightdividerField;
            }
            set
            {
                this.rightdividerField = value;
            }
        }
    }
}