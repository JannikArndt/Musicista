using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "arrow-direction")]
    public enum arrowdirection
    {
        left,


        up,


        right,


        down,


        northwest,


        northeast,


        southeast,


        southwest,


        [XmlEnum("left right")]
        leftright,


        [XmlEnum("up down")]
        updown,


        [XmlEnum("northwest southeast")]
        northwestsoutheast,


        [XmlEnum("northeast southwest")]
        northeastsouthwest,


        other,
    }
}