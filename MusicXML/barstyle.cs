using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace MusicXML
{
    [GeneratedCode("xsd", "4.0.30319.33440")]
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