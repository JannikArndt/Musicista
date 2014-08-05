using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    public enum winged
    {
        none,


        straight,


        curved,


        [XmlEnum("double-straight")]
        doublestraight,


        [XmlEnum("double-curved")]
        doublecurved,
    }
}