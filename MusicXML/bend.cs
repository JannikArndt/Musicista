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
    public class bend
    {
        private yesno accelerateField;

        private bool accelerateFieldSpecified;

        private decimal beatsField;

        private bool beatsFieldSpecified;
        private decimal bendalterField;

        private decimal firstbeatField;

        private bool firstbeatFieldSpecified;
        private ItemChoiceType1 itemElementNameField;
        private empty itemField;

        private decimal lastbeatField;

        private bool lastbeatFieldSpecified;
        private placementtext withbarField;


        [XmlElement("bend-alter")]
        public decimal bendalter
        {
            get { return bendalterField; }
            set { bendalterField = value; }
        }


        [XmlElement("pre-bend", typeof(empty))]
        [XmlElement("release", typeof(empty))]
        [XmlChoiceIdentifier("ItemElementName")]
        public empty Item
        {
            get { return itemField; }
            set { itemField = value; }
        }


        [XmlIgnore]
        public ItemChoiceType1 ItemElementName
        {
            get { return itemElementNameField; }
            set { itemElementNameField = value; }
        }


        [XmlElement("with-bar")]
        public placementtext withbar
        {
            get { return withbarField; }
            set { withbarField = value; }
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
    }
}