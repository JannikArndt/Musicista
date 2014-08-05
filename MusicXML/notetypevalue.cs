using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "note-type-value")]
    public enum notetypevalue
    {
        [XmlEnum("1024th")] Item1024th,


        [XmlEnum("512th")] Item512th,


        [XmlEnum("256th")] Item256th,


        [XmlEnum("128th")] Item128th,


        [XmlEnum("64th")] Item64th,


        [XmlEnum("32nd")] Item32nd,


        [XmlEnum("16th")] Item16th,


        eighth,


        quarter,


        half,


        whole,


        breve,


        @long,


        maxima,
    }
}