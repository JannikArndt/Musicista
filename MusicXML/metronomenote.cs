namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "metronome-note")]
    public partial class metronomenote
    {

        private notetypevalue metronometypeField;

        private empty[] metronomedotField;

        private metronomebeam[] metronomebeamField;

        private metronometuplet metronometupletField;


        [System.Xml.Serialization.XmlElementAttribute("metronome-type")]
        public notetypevalue metronometype
        {
            get
            {
                return this.metronometypeField;
            }
            set
            {
                this.metronometypeField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("metronome-dot")]
        public empty[] metronomedot
        {
            get
            {
                return this.metronomedotField;
            }
            set
            {
                this.metronomedotField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("metronome-beam")]
        public metronomebeam[] metronomebeam
        {
            get
            {
                return this.metronomebeamField;
            }
            set
            {
                this.metronomebeamField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("metronome-tuplet")]
        public metronometuplet metronometuplet
        {
            get
            {
                return this.metronometupletField;
            }
            set
            {
                this.metronometupletField = value;
            }
        }
    }
}