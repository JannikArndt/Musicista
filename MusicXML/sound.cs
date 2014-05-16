namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class sound
    {

        private mididevice[] midideviceField;

        private midiinstrument[] midiinstrumentField;

        private play[] playField;

        private offset offsetField;

        private decimal tempoField;

        private bool tempoFieldSpecified;

        private decimal dynamicsField;

        private bool dynamicsFieldSpecified;

        private yesno dacapoField;

        private bool dacapoFieldSpecified;

        private string segnoField;

        private string dalsegnoField;

        private string codaField;

        private string tocodaField;

        private decimal divisionsField;

        private bool divisionsFieldSpecified;

        private yesno forwardrepeatField;

        private bool forwardrepeatFieldSpecified;

        private string fineField;

        private string timeonlyField;

        private yesno pizzicatoField;

        private bool pizzicatoFieldSpecified;

        private decimal panField;

        private bool panFieldSpecified;

        private decimal elevationField;

        private bool elevationFieldSpecified;

        private string damperpedalField;

        private string softpedalField;

        private string sostenutopedalField;


        [System.Xml.Serialization.XmlElementAttribute("midi-device")]
        public mididevice[] mididevice
        {
            get
            {
                return this.midideviceField;
            }
            set
            {
                this.midideviceField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("midi-instrument")]
        public midiinstrument[] midiinstrument
        {
            get
            {
                return this.midiinstrumentField;
            }
            set
            {
                this.midiinstrumentField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("play")]
        public play[] play
        {
            get
            {
                return this.playField;
            }
            set
            {
                this.playField = value;
            }
        }


        public offset offset
        {
            get
            {
                return this.offsetField;
            }
            set
            {
                this.offsetField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal tempo
        {
            get
            {
                return this.tempoField;
            }
            set
            {
                this.tempoField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool tempoSpecified
        {
            get
            {
                return this.tempoFieldSpecified;
            }
            set
            {
                this.tempoFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal dynamics
        {
            get
            {
                return this.dynamicsField;
            }
            set
            {
                this.dynamicsField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dynamicsSpecified
        {
            get
            {
                return this.dynamicsFieldSpecified;
            }
            set
            {
                this.dynamicsFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public yesno dacapo
        {
            get
            {
                return this.dacapoField;
            }
            set
            {
                this.dacapoField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dacapoSpecified
        {
            get
            {
                return this.dacapoFieldSpecified;
            }
            set
            {
                this.dacapoFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string segno
        {
            get
            {
                return this.segnoField;
            }
            set
            {
                this.segnoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string dalsegno
        {
            get
            {
                return this.dalsegnoField;
            }
            set
            {
                this.dalsegnoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string coda
        {
            get
            {
                return this.codaField;
            }
            set
            {
                this.codaField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string tocoda
        {
            get
            {
                return this.tocodaField;
            }
            set
            {
                this.tocodaField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal divisions
        {
            get
            {
                return this.divisionsField;
            }
            set
            {
                this.divisionsField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool divisionsSpecified
        {
            get
            {
                return this.divisionsFieldSpecified;
            }
            set
            {
                this.divisionsFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("forward-repeat")]
        public yesno forwardrepeat
        {
            get
            {
                return this.forwardrepeatField;
            }
            set
            {
                this.forwardrepeatField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool forwardrepeatSpecified
        {
            get
            {
                return this.forwardrepeatFieldSpecified;
            }
            set
            {
                this.forwardrepeatFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string fine
        {
            get
            {
                return this.fineField;
            }
            set
            {
                this.fineField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("time-only", DataType = "token")]
        public string timeonly
        {
            get
            {
                return this.timeonlyField;
            }
            set
            {
                this.timeonlyField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public yesno pizzicato
        {
            get
            {
                return this.pizzicatoField;
            }
            set
            {
                this.pizzicatoField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pizzicatoSpecified
        {
            get
            {
                return this.pizzicatoFieldSpecified;
            }
            set
            {
                this.pizzicatoFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal pan
        {
            get
            {
                return this.panField;
            }
            set
            {
                this.panField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool panSpecified
        {
            get
            {
                return this.panFieldSpecified;
            }
            set
            {
                this.panFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal elevation
        {
            get
            {
                return this.elevationField;
            }
            set
            {
                this.elevationField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool elevationSpecified
        {
            get
            {
                return this.elevationFieldSpecified;
            }
            set
            {
                this.elevationFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("damper-pedal")]
        public string damperpedal
        {
            get
            {
                return this.damperpedalField;
            }
            set
            {
                this.damperpedalField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("soft-pedal")]
        public string softpedal
        {
            get
            {
                return this.softpedalField;
            }
            set
            {
                this.softpedalField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("sostenuto-pedal")]
        public string sostenutopedal
        {
            get
            {
                return this.sostenutopedalField;
            }
            set
            {
                this.sostenutopedalField = value;
            }
        }
    }
}