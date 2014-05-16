namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class appearance
    {

        private linewidth[] linewidthField;

        private notesize[] notesizeField;

        private distance[] distanceField;

        private otherappearance[] otherappearanceField;


        [System.Xml.Serialization.XmlElementAttribute("line-width")]
        public linewidth[] linewidth
        {
            get
            {
                return this.linewidthField;
            }
            set
            {
                this.linewidthField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("note-size")]
        public notesize[] notesize
        {
            get
            {
                return this.notesizeField;
            }
            set
            {
                this.notesizeField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("distance")]
        public distance[] distance
        {
            get
            {
                return this.distanceField;
            }
            set
            {
                this.distanceField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("other-appearance")]
        public otherappearance[] otherappearance
        {
            get
            {
                return this.otherappearanceField;
            }
            set
            {
                this.otherappearanceField = value;
            }
        }
    }
}