using System;
using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "breath-mark-value")]
    public enum breathmarkvalue
    {
        [XmlEnum("")] Item,


        comma,


        tick,
    }
}