using System;

using System.Xml.Serialization;

namespace MusicXML.Note
{
    
    [Serializable]
    [XmlType(TypeName = "accidental-value")]
    public enum accidentalvalue
    {
        sharp,


        natural,


        flat,


        [XmlEnum("double-sharp")]
        doublesharp,


        [XmlEnum("sharp-sharp")]
        sharpsharp,


        [XmlEnum("flat-flat")]
        flatflat,


        [XmlEnum("natural-sharp")]
        naturalsharp,


        [XmlEnum("natural-flat")]
        naturalflat,


        [XmlEnum("quarter-flat")]
        quarterflat,


        [XmlEnum("quarter-sharp")]
        quartersharp,


        [XmlEnum("three-quarters-flat")]
        threequartersflat,


        [XmlEnum("three-quarters-sharp")]
        threequarterssharp,


        [XmlEnum("sharp-down")]
        sharpdown,


        [XmlEnum("sharp-up")]
        sharpup,


        [XmlEnum("natural-down")]
        naturaldown,


        [XmlEnum("natural-up")]
        naturalup,


        [XmlEnum("flat-down")]
        flatdown,


        [XmlEnum("flat-up")]
        flatup,


        [XmlEnum("triple-sharp")]
        triplesharp,


        [XmlEnum("triple-flat")]
        tripleflat,


        [XmlEnum("slash-quarter-sharp")]
        slashquartersharp,


        [XmlEnum("slash-sharp")]
        slashsharp,


        [XmlEnum("slash-flat")]
        slashflat,


        [XmlEnum("double-slash-flat")]
        doubleslashflat,


        [XmlEnum("sharp-1")]
        sharp1,


        [XmlEnum("sharp-2")]
        sharp2,


        [XmlEnum("sharp-3")]
        sharp3,


        [XmlEnum("sharp-5")]
        sharp5,


        [XmlEnum("flat-1")]
        flat1,


        [XmlEnum("flat-2")]
        flat2,


        [XmlEnum("flat-3")]
        flat3,


        [XmlEnum("flat-4")]
        flat4,


        sori,


        koron,
    }
}