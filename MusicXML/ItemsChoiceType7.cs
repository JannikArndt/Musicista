using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType7
    {
        [XmlEnum("accordion-registration")] accordionregistration,


        bracket,


        coda,


        damp,


        [XmlEnum("damp-all")] dampall,


        dashes,


        dynamics,


        eyeglasses,


        [XmlEnum("harp-pedals")] harppedals,


        image,


        metronome,


        [XmlEnum("octave-shift")] octaveshift,


        [XmlEnum("other-direction")] otherdirection,


        pedal,


        percussion,


        [XmlEnum("principal-voice")] principalvoice,


        rehearsal,


        scordatura,


        segno,


        [XmlEnum("string-mute")] stringmute,


        wedge,


        words,
    }
}