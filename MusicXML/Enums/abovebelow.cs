using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "above-below")]
    public enum abovebelow
    {
    
        above,

    
        below,
    }
}