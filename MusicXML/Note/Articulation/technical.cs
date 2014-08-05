using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note.Articulation
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class technical
    {
        private ItemsChoiceType3[] itemsElementNameField;
        private object[] itemsField;


        [XmlElement("arrow", typeof(arrow))]
        [XmlElement("bend", typeof(bend))]
        [XmlElement("double-tongue", typeof(Emptyplacement))]
        [XmlElement("down-bow", typeof(Emptyplacement))]
        [XmlElement("fingering", typeof(fingering))]
        [XmlElement("fingernails", typeof(Emptyplacement))]
        [XmlElement("fret", typeof(fret))]
        [XmlElement("hammer-on", typeof(hammeronpulloff))]
        [XmlElement("handbell", typeof(handbell))]
        [XmlElement("harmonic", typeof(harmonic))]
        [XmlElement("heel", typeof(heeltoe))]
        [XmlElement("hole", typeof(hole))]
        [XmlElement("open-string", typeof(Emptyplacement))]
        [XmlElement("other-technical", typeof(placementtext))]
        [XmlElement("pluck", typeof(placementtext))]
        [XmlElement("pull-off", typeof(hammeronpulloff))]
        [XmlElement("snap-pizzicato", typeof(Emptyplacement))]
        [XmlElement("stopped", typeof(Emptyplacement))]
        [XmlElement("string", typeof(@string))]
        [XmlElement("tap", typeof(placementtext))]
        [XmlElement("thumb-position", typeof(Emptyplacement))]
        [XmlElement("toe", typeof(heeltoe))]
        [XmlElement("triple-tongue", typeof(Emptyplacement))]
        [XmlElement("up-bow", typeof(Emptyplacement))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlElement("ItemsElementName")]
        [XmlIgnore]
        public ItemsChoiceType3[] ItemsElementName
        {
            get { return itemsElementNameField; }
            set { itemsElementNameField = value; }
        }
    }
}