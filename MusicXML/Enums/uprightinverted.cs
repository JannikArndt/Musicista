using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "upright-inverted")]
    public enum uprightinverted
    {
        upright,


        inverted,
    }
}