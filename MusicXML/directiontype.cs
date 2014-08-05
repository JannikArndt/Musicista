using MusicXML.Note.Articulation;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "direction-type")]
    public class directiontype
    {
        private ItemsChoiceType7[] itemsElementNameField;
        private object[] itemsField;


        [XmlElement("accordion-registration", typeof(accordionregistration))]
        [XmlElement("bracket", typeof(bracket))]
        [XmlElement("coda", typeof(emptyprintstylealign))]
        [XmlElement("damp", typeof(emptyprintstylealign))]
        [XmlElement("damp-all", typeof(emptyprintstylealign))]
        [XmlElement("dashes", typeof(dashes))]
        [XmlElement("dynamics", typeof(dynamics))]
        [XmlElement("eyeglasses", typeof(emptyprintstylealign))]
        [XmlElement("harp-pedals", typeof(harppedals))]
        [XmlElement("image", typeof(image))]
        [XmlElement("metronome", typeof(metronome))]
        [XmlElement("octave-shift", typeof(octaveshift))]
        [XmlElement("other-direction", typeof(otherdirection))]
        [XmlElement("pedal", typeof(pedal))]
        [XmlElement("percussion", typeof(percussion))]
        [XmlElement("principal-voice", typeof(principalvoice))]
        [XmlElement("rehearsal", typeof(formattedtext))]
        [XmlElement("scordatura", typeof(scordatura))]
        [XmlElement("segno", typeof(emptyprintstylealign))]
        [XmlElement("string-mute", typeof(stringmute))]
        [XmlElement("wedge", typeof(wedge))]
        [XmlElement("words", typeof(formattedtext))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlElement("ItemsElementName")]
        [XmlIgnore]
        public ItemsChoiceType7[] ItemsElementName
        {
            get { return itemsElementNameField; }
            set { itemsElementNameField = value; }
        }
    }
}