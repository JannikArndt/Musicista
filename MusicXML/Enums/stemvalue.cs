using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "stem-value")]
    public enum stemvalue
    {
        down,


        up,


        @double,


        none,
    }
}