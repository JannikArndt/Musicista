using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note.Articulation
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class Articulations
    {
        private ItemsChoiceType4[] itemsElementNameField;
        private object[] itemsField;


        [XmlElement("accent", typeof(Emptyplacement))]
        [XmlElement("breath-mark", typeof(breathmark))]
        [XmlElement("caesura", typeof(Emptyplacement))]
        [XmlElement("detached-legato", typeof(Emptyplacement))]
        [XmlElement("doit", typeof(emptyline))]
        [XmlElement("falloff", typeof(emptyline))]
        [XmlElement("other-articulation", typeof(placementtext))]
        [XmlElement("plop", typeof(emptyline))]
        [XmlElement("scoop", typeof(emptyline))]
        [XmlElement("spiccato", typeof(Emptyplacement))]
        [XmlElement("staccatissimo", typeof(Emptyplacement))]
        [XmlElement("staccato", typeof(Emptyplacement))]
        [XmlElement("stress", typeof(Emptyplacement))]
        [XmlElement("strong-accent", typeof(strongaccent))]
        [XmlElement("tenuto", typeof(Emptyplacement))]
        [XmlElement("unstress", typeof(Emptyplacement))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlElement("ItemsElementName")]
        [XmlIgnore]
        public ItemsChoiceType4[] ItemsElementName
        {
            get { return itemsElementNameField; }
            set { itemsElementNameField = value; }
        }
    }
}