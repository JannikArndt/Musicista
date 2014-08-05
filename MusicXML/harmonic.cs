using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class harmonic
    {
        private Item1ChoiceType item1ElementNameField;
        private empty item1Field;
        private ItemChoiceType itemElementNameField;
        private empty itemField;

        private abovebelow placementField;

        private bool placementFieldSpecified;
        private yesno printobjectField;

        private bool printobjectFieldSpecified;


        [XmlElement("artificial", typeof (empty))]
        [XmlElement("natural", typeof (empty))]
        [XmlChoiceIdentifier("ItemElementName")]
        public empty Item
        {
            get { return itemField; }
            set { itemField = value; }
        }


        [XmlIgnore]
        public ItemChoiceType ItemElementName
        {
            get { return itemElementNameField; }
            set { itemElementNameField = value; }
        }


        [XmlElement("base-pitch", typeof (empty))]
        [XmlElement("sounding-pitch", typeof (empty))]
        [XmlElement("touching-pitch", typeof (empty))]
        [XmlChoiceIdentifier("Item1ElementName")]
        public empty Item1
        {
            get { return item1Field; }
            set { item1Field = value; }
        }


        [XmlIgnore]
        public Item1ChoiceType Item1ElementName
        {
            get { return item1ElementNameField; }
            set { item1ElementNameField = value; }
        }


        [XmlAttribute("print-object")]
        public yesno printobject
        {
            get { return printobjectField; }
            set { printobjectField = value; }
        }


        [XmlIgnore]
        public bool printobjectSpecified
        {
            get { return printobjectFieldSpecified; }
            set { printobjectFieldSpecified = value; }
        }


        [XmlAttribute]
        public abovebelow placement
        {
            get { return placementField; }
            set { placementField = value; }
        }


        [XmlIgnore]
        public bool placementSpecified
        {
            get { return placementFieldSpecified; }
            set { placementFieldSpecified = value; }
        }
    }
}