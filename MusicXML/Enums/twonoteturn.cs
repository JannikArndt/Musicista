using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "two-note-turn")]
    public enum twonoteturn
    {
        whole,


        half,


        none,
    }
}