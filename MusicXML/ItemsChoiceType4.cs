using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType4
    {
        accent,


        [XmlEnum("breath-mark")] breathmark,


        caesura,


        [XmlEnum("detached-legato")] detachedlegato,


        doit,


        falloff,


        [XmlEnum("other-articulation")] otherarticulation,


        plop,


        scoop,


        spiccato,


        staccatissimo,


        staccato,


        stress,


        [XmlEnum("strong-accent")] strongaccent,


        tenuto,


        unstress,
    }
}