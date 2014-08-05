using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {
        [XmlEnum("delayed-inverted-turn")] delayedinvertedturn,


        [XmlEnum("delayed-turn")] delayedturn,


        [XmlEnum("inverted-mordent")] invertedmordent,


        [XmlEnum("inverted-turn")] invertedturn,


        mordent,


        [XmlEnum("other-ornament")] otherornament,


        schleifer,


        shake,


        tremolo,


        [XmlEnum("trill-mark")] trillmark,


        turn,


        [XmlEnum("vertical-turn")] verticalturn,


        [XmlEnum("wavy-line")] wavyline,
    }
}