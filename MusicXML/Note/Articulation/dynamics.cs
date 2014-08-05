using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML.Note.Articulation
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class dynamics
    {
        private enclosureshape enclosureField;

        private bool enclosureFieldSpecified;
        private ItemsChoiceType5[] itemsElementNameField;
        private object[] itemsField;
        private string linethroughField;
        private string overlineField;

        private abovebelow placementField;

        private bool placementFieldSpecified;

        private string underlineField;


        [XmlElement("f", typeof (empty))]
        [XmlElement("ff", typeof (empty))]
        [XmlElement("fff", typeof (empty))]
        [XmlElement("ffff", typeof (empty))]
        [XmlElement("fffff", typeof (empty))]
        [XmlElement("ffffff", typeof (empty))]
        [XmlElement("fp", typeof (empty))]
        [XmlElement("fz", typeof (empty))]
        [XmlElement("mf", typeof (empty))]
        [XmlElement("mp", typeof (empty))]
        [XmlElement("other-dynamics", typeof (string))]
        [XmlElement("p", typeof (empty))]
        [XmlElement("pp", typeof (empty))]
        [XmlElement("ppp", typeof (empty))]
        [XmlElement("pppp", typeof (empty))]
        [XmlElement("ppppp", typeof (empty))]
        [XmlElement("pppppp", typeof (empty))]
        [XmlElement("rf", typeof (empty))]
        [XmlElement("rfz", typeof (empty))]
        [XmlElement("sf", typeof (empty))]
        [XmlElement("sffz", typeof (empty))]
        [XmlElement("sfp", typeof (empty))]
        [XmlElement("sfpp", typeof (empty))]
        [XmlElement("sfz", typeof (empty))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlElement("ItemsElementName")]
        [XmlIgnore]
        public ItemsChoiceType5[] ItemsElementName
        {
            get { return itemsElementNameField; }
            set { itemsElementNameField = value; }
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


        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string underline
        {
            get { return underlineField; }
            set { underlineField = value; }
        }


        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string overline
        {
            get { return overlineField; }
            set { overlineField = value; }
        }


        [XmlAttribute("line-through", DataType = "nonNegativeInteger")]
        public string linethrough
        {
            get { return linethroughField; }
            set { linethroughField = value; }
        }


        [XmlAttribute]
        public enclosureshape enclosure
        {
            get { return enclosureField; }
            set { enclosureField = value; }
        }


        [XmlIgnore]
        public bool enclosureSpecified
        {
            get { return enclosureFieldSpecified; }
            set { enclosureFieldSpecified = value; }
        }
    }
}