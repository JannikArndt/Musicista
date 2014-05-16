namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class forward
    {

        private decimal durationField;

        private formattedtext footnoteField;

        private level levelField;

        private string voiceField;

        private string staffField;


        public decimal duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }


        public formattedtext footnote
        {
            get
            {
                return this.footnoteField;
            }
            set
            {
                this.footnoteField = value;
            }
        }


        public level level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }


        public string voice
        {
            get
            {
                return this.voiceField;
            }
            set
            {
                this.voiceField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
        public string staff
        {
            get
            {
                return this.staffField;
            }
            set
            {
                this.staffField = value;
            }
        }
    }
}