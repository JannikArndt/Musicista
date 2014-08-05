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
    public class percussion
    {
        private enclosureshape enclosureField;

        private bool enclosureFieldSpecified;
        private object itemField;


        [XmlElement("beater", typeof(beater))]
        [XmlElement("effect", typeof(effect))]
        [XmlElement("glass", typeof(glass))]
        [XmlElement("membrane", typeof(membrane))]
        [XmlElement("metal", typeof(metal))]
        [XmlElement("other-percussion", typeof(string))]
        [XmlElement("pitched", typeof(pitched))]
        [XmlElement("stick", typeof(stick))]
        [XmlElement("stick-location", typeof(sticklocation))]
        [XmlElement("timpani", typeof(empty))]
        [XmlElement("wood", typeof(wood))]
        public object Item
        {
            get { return itemField; }
            set { itemField = value; }
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