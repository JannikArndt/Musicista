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
    public class slide
    {
        private yesno accelerateField;

        private bool accelerateFieldSpecified;

        private decimal beatsField;

        private bool beatsFieldSpecified;
        private decimal dashlengthField;

        private bool dashlengthFieldSpecified;

        private decimal firstbeatField;

        private bool firstbeatFieldSpecified;

        private decimal lastbeatField;

        private bool lastbeatFieldSpecified;
        private linetype linetypeField;

        private bool linetypeFieldSpecified;
        private string numberField;
        private decimal spacelengthField;

        private bool spacelengthFieldSpecified;
        private startstop typeField;

        private string valueField;

        public slide()
        {
            numberField = "1";
        }


        [XmlAttribute]
        public startstop type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        [DefaultValue("1")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }


        [XmlAttribute("line-type")]
        public linetype linetype
        {
            get { return linetypeField; }
            set { linetypeField = value; }
        }


        [XmlIgnore]
        public bool linetypeSpecified
        {
            get { return linetypeFieldSpecified; }
            set { linetypeFieldSpecified = value; }
        }


        [XmlAttribute("dash-length")]
        public decimal dashlength
        {
            get { return dashlengthField; }
            set { dashlengthField = value; }
        }


        [XmlIgnore]
        public bool dashlengthSpecified
        {
            get { return dashlengthFieldSpecified; }
            set { dashlengthFieldSpecified = value; }
        }


        [XmlAttribute("space-length")]
        public decimal spacelength
        {
            get { return spacelengthField; }
            set { spacelengthField = value; }
        }


        [XmlIgnore]
        public bool spacelengthSpecified
        {
            get { return spacelengthFieldSpecified; }
            set { spacelengthFieldSpecified = value; }
        }


        [XmlAttribute]
        public yesno accelerate
        {
            get { return accelerateField; }
            set { accelerateField = value; }
        }


        [XmlIgnore]
        public bool accelerateSpecified
        {
            get { return accelerateFieldSpecified; }
            set { accelerateFieldSpecified = value; }
        }


        [XmlAttribute]
        public decimal beats
        {
            get { return beatsField; }
            set { beatsField = value; }
        }


        [XmlIgnore]
        public bool beatsSpecified
        {
            get { return beatsFieldSpecified; }
            set { beatsFieldSpecified = value; }
        }


        [XmlAttribute("first-beat")]
        public decimal firstbeat
        {
            get { return firstbeatField; }
            set { firstbeatField = value; }
        }


        [XmlIgnore]
        public bool firstbeatSpecified
        {
            get { return firstbeatFieldSpecified; }
            set { firstbeatFieldSpecified = value; }
        }


        [XmlAttribute("last-beat")]
        public decimal lastbeat
        {
            get { return lastbeatField; }
            set { lastbeatField = value; }
        }


        [XmlIgnore]
        public bool lastbeatSpecified
        {
            get { return lastbeatFieldSpecified; }
            set { lastbeatFieldSpecified = value; }
        }


        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}