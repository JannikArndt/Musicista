using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "stick-material")]
    public enum stickmaterial
    {
        soft,


        medium,


        hard,


        shaded,


        x,
    }
}