using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "wedge-type")]
    public enum wedgetype
    {
        crescendo,


        diminuendo,


        stop,


        @continue,
    }
}