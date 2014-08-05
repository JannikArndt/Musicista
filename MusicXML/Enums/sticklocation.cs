using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "stick-location")]
    public enum sticklocation
    {
        center,


        rim,


        [XmlEnum("cymbal bell")] cymbalbell,


        [XmlEnum("cymbal edge")] cymbaledge,
    }
}