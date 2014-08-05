using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "handbell-value")]
    public enum handbellvalue
    {
        damp,


        echo,


        gyro,


        [XmlEnum("hand martellato")] handmartellato,


        [XmlEnum("mallet lift")] malletlift,


        [XmlEnum("mallet table")] mallettable,


        martellato,


        [XmlEnum("martellato lift")] martellatolift,


        [XmlEnum("muted martellato")] mutedmartellato,


        [XmlEnum("pluck lift")] plucklift,


        swing,
    }
}