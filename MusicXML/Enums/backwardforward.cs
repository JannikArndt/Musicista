using System;
using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "backward-forward")]
    public enum backwardforward
    {
    
        backward,

    
        forward,
    }
}