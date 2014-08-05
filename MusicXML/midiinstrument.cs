using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "midi-instrument")]
    public class midiinstrument
    {
        private decimal elevationField;

        private bool elevationFieldSpecified;

        private string idField;
        private string midibankField;
        private string midichannelField;

        private string midinameField;

        private string midiprogramField;

        private string midiunpitchedField;

        private decimal panField;

        private bool panFieldSpecified;
        private decimal volumeField;

        private bool volumeFieldSpecified;


        [XmlElement("midi-channel", DataType = "positiveInteger")]
        public string midichannel
        {
            get { return midichannelField; }
            set { midichannelField = value; }
        }


        [XmlElement("midi-name")]
        public string midiname
        {
            get { return midinameField; }
            set { midinameField = value; }
        }


        [XmlElement("midi-bank", DataType = "positiveInteger")]
        public string midibank
        {
            get { return midibankField; }
            set { midibankField = value; }
        }


        [XmlElement("midi-program", DataType = "positiveInteger")]
        public string midiprogram
        {
            get { return midiprogramField; }
            set { midiprogramField = value; }
        }


        [XmlElement("midi-unpitched", DataType = "positiveInteger")]
        public string midiunpitched
        {
            get { return midiunpitchedField; }
            set { midiunpitchedField = value; }
        }


        public decimal volume
        {
            get { return volumeField; }
            set { volumeField = value; }
        }


        [XmlIgnore]
        public bool volumeSpecified
        {
            get { return volumeFieldSpecified; }
            set { volumeFieldSpecified = value; }
        }


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


        [XmlAttribute(DataType = "IDREF")]
        public string id
        {
            get { return idField; }
            set { idField = value; }
        }
    }
}