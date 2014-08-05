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
    public class DirectionType
    {
        [XmlElement("accordion-registration", typeof(accordionregistration))]
        public accordionregistration AccordionRegistration { get; set; }


        [XmlElement("bracket", typeof(bracket))]
        public bracket Bracket { get; set; }


        [XmlElement("coda", typeof(emptyprintstylealign))]
        public emptyprintstylealign Coda { get; set; }


        [XmlElement("damp", typeof(emptyprintstylealign))]
        public emptyprintstylealign Damp { get; set; }


        [XmlElement("damp-all", typeof(emptyprintstylealign))]
        public emptyprintstylealign DampAll { get; set; }


        [XmlElement("dashes", typeof(dashes))]
        public dashes Dashes { get; set; }


        [XmlElement("dynamics", typeof(dynamics))]
        public dynamics Dynamics { get; set; }


        [XmlElement("eyeglasses", typeof(emptyprintstylealign))]
        public emptyprintstylealign Eyeglasses { get; set; }


        [XmlElement("harp-pedals", typeof(harppedals))]
        public harppedals HarpPedals { get; set; }


        [XmlElement("image", typeof(image))]
        public image Image { get; set; }


        [XmlElement("metronome", typeof(metronome))]
        public metronome Metronome { get; set; }


        [XmlElement("octave-shift", typeof(octaveshift))]
        public octaveshift OctaveShift { get; set; }


        [XmlElement("other-direction", typeof(otherdirection))]
        public otherdirection OtherDirection { get; set; }


        [XmlElement("pedal", typeof(pedal))]
        public pedal Pedal { get; set; }


        [XmlElement("percussion", typeof(percussion))]
        public percussion Percussion { get; set; }


        [XmlElement("principal-voice", typeof(principalvoice))]
        public principalvoice PrincipalVoice { get; set; }


        [XmlElement("rehearsal", typeof(formattedtext))]
        public formattedtext Rehearsal { get; set; }


        [XmlElement("scordatura", typeof(scordatura))]
        public scordatura Scordatura { get; set; }


        [XmlElement("segno", typeof(emptyprintstylealign))]
        public emptyprintstylealign Segno { get; set; }


        [XmlElement("string-mute", typeof(stringmute))]
        public stringmute StringMute { get; set; }


        [XmlElement("wedge", typeof(wedge))]
        public wedge Wedge { get; set; }


        [XmlElement("words", typeof(formattedtext))]
        public formattedtext Words { get; set; }
    }
}