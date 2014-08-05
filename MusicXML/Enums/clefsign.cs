using System;
using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "clef-sign")]
    public enum clefsign
    {
        G,
        F,
        C,
        percussion,
        TAB,
        jianpu,
        none,
    }
}