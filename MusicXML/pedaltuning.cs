namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "pedal-tuning")]
    public partial class pedaltuning
    {

        private step pedalstepField;

        private decimal pedalalterField;


        [System.Xml.Serialization.XmlElementAttribute("pedal-step")]
        public step pedalstep
        {
            get
            {
                return this.pedalstepField;
            }
            set
            {
                this.pedalstepField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("pedal-alter")]
        public decimal pedalalter
        {
            get
            {
                return this.pedalalterField;
            }
            set
            {
                this.pedalalterField = value;
            }
        }
    }
}