using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "up-down")]
    public enum updown
    {
        up,


        down,
    }
}