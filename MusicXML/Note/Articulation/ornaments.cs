using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note.Articulation
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class ornaments
    {
        private accidentalmark[] accidentalmarkField;
        private ItemsChoiceType2[] itemsElementNameField;
        private object[] itemsField;


        [XmlElement("delayed-inverted-turn", typeof(horizontalturn))]
        [XmlElement("delayed-turn", typeof(horizontalturn))]
        [XmlElement("inverted-mordent", typeof(mordent))]
        [XmlElement("inverted-turn", typeof(horizontalturn))]
        [XmlElement("mordent", typeof(mordent))]
        [XmlElement("other-ornament", typeof(placementtext))]
        [XmlElement("schleifer", typeof(Emptyplacement))]
        [XmlElement("shake", typeof(emptytrillsound))]
        [XmlElement("tremolo", typeof(tremolo))]
        [XmlElement("trill-mark", typeof(emptytrillsound))]
        [XmlElement("turn", typeof(horizontalturn))]
        [XmlElement("vertical-turn", typeof(emptytrillsound))]
        [XmlElement("wavy-line", typeof(wavyline))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlElement("ItemsElementName")]
        [XmlIgnore]
        public ItemsChoiceType2[] ItemsElementName
        {
            get { return itemsElementNameField; }
            set { itemsElementNameField = value; }
        }


        [XmlElement("accidental-mark")]
        public accidentalmark[] accidentalmark
        {
            get { return accidentalmarkField; }
            set { accidentalmarkField = value; }
        }
    }
}