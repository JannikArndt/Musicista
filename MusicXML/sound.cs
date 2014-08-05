using MusicXML.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class sound
    {
        private string codaField;
        private yesno dacapoField;

        private bool dacapoFieldSpecified;

        private string dalsegnoField;
        private string damperpedalField;

        private decimal divisionsField;

        private bool divisionsFieldSpecified;
        private decimal dynamicsField;

        private bool dynamicsFieldSpecified;
        private decimal elevationField;

        private bool elevationFieldSpecified;
        private string fineField;

        private yesno forwardrepeatField;

        private bool forwardrepeatFieldSpecified;
        private mididevice[] midideviceField;

        private midiinstrument[] midiinstrumentField;
        private offset offsetField;

        private decimal panField;

        private bool panFieldSpecified;
        private yesno pizzicatoField;

        private bool pizzicatoFieldSpecified;
        private play[] playField;
        private string segnoField;

        private string softpedalField;

        private string sostenutopedalField;
        private decimal tempoField;

        private bool tempoFieldSpecified;
        private string timeonlyField;
        private string tocodaField;


        [XmlElement("midi-device")]
        public mididevice[] mididevice
        {
            get { return midideviceField; }
            set { midideviceField = value; }
        }


        [XmlElement("midi-instrument")]
        public midiinstrument[] midiinstrument
        {
            get { return midiinstrumentField; }
            set { midiinstrumentField = value; }
        }


        [XmlElement("play")]
        public play[] play
        {
            get { return playField; }
            set { playField = value; }
        }


        public offset offset
        {
            get { return offsetField; }
            set { offsetField = value; }
        }


        [XmlAttribute]
        public decimal tempo
        {
            get { return tempoField; }
            set { tempoField = value; }
        }


        [XmlIgnore]
        public bool tempoSpecified
        {
            get { return tempoFieldSpecified; }
            set { tempoFieldSpecified = value; }
        }


        [XmlAttribute]
        public decimal dynamics
        {
            get { return dynamicsField; }
            set { dynamicsField = value; }
        }


        [XmlIgnore]
        public bool dynamicsSpecified
        {
            get { return dynamicsFieldSpecified; }
            set { dynamicsFieldSpecified = value; }
        }


        [XmlAttribute]
        public yesno dacapo
        {
            get { return dacapoField; }
            set { dacapoField = value; }
        }


        [XmlIgnore]
        public bool dacapoSpecified
        {
            get { return dacapoFieldSpecified; }
            set { dacapoFieldSpecified = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string segno
        {
            get { return segnoField; }
            set { segnoField = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string dalsegno
        {
            get { return dalsegnoField; }
            set { dalsegnoField = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string coda
        {
            get { return codaField; }
            set { codaField = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string tocoda
        {
            get { return tocodaField; }
            set { tocodaField = value; }
        }


        [XmlAttribute]
        public decimal divisions
        {
            get { return divisionsField; }
            set { divisionsField = value; }
        }


        [XmlIgnore]
        public bool divisionsSpecified
        {
            get { return divisionsFieldSpecified; }
            set { divisionsFieldSpecified = value; }
        }


        [XmlAttribute("forward-repeat")]
        public yesno forwardrepeat
        {
            get { return forwardrepeatField; }
            set { forwardrepeatField = value; }
        }


        [XmlIgnore]
        public bool forwardrepeatSpecified
        {
            get { return forwardrepeatFieldSpecified; }
            set { forwardrepeatFieldSpecified = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string fine
        {
            get { return fineField; }
            set { fineField = value; }
        }


        [XmlAttribute("time-only", DataType = "token")]
        public string timeonly
        {
            get { return timeonlyField; }
            set { timeonlyField = value; }
        }


        [XmlAttribute]
        public yesno pizzicato
        {
            get { return pizzicatoField; }
            set { pizzicatoField = value; }
        }


        [XmlIgnore]
        public bool pizzicatoSpecified
        {
            get { return pizzicatoFieldSpecified; }
            set { pizzicatoFieldSpecified = value; }
        }


        [XmlAttribute]
        public decimal pan
        {
            get { return panField; }
            set { panField = value; }
        }


        [XmlIgnore]
        public bool panSpecified
        {
            get { return panFieldSpecified; }
            set { panFieldSpecified = value; }
        }


        [XmlAttribute]
        public decimal elevation
        {
            get { return elevationField; }
            set { elevationField = value; }
        }


        [XmlIgnore]
        public bool elevationSpecified
        {
            get { return elevationFieldSpecified; }
            set { elevationFieldSpecified = value; }
        }


        [XmlAttribute("damper-pedal")]
        public string damperpedal
        {
            get { return damperpedalField; }
            set { damperpedalField = value; }
        }


        [XmlAttribute("soft-pedal")]
        public string softpedal
        {
            get { return softpedalField; }
            set { softpedalField = value; }
        }


        [XmlAttribute("sostenuto-pedal")]
        public string sostenutopedal
        {
            get { return sostenutopedalField; }
            set { sostenutopedalField = value; }
        }
    }
}