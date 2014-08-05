using System;
using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "bar-style")]
    public enum barstyle
    {
    
        regular,

    
        dotted,

    
        dashed,

    
        heavy,

    
        [XmlEnum("light-light")]
        lightlight,

    
        [XmlEnum("light-heavy")]
        lightheavy,

    
        [XmlEnum("heavy-light")]
        heavylight,

    
        [XmlEnum("heavy-heavy")]
        heavyheavy,

    
        tick,

    
        @short,

    
        none,
    }
}