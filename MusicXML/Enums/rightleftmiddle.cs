using System;
using System.Xml.Serialization;

namespace MusicXML.Enums
{
    [Serializable]
    [XmlType(TypeName = "right-left-middle")]
    public enum rightleftmiddle
    {
        right,


        left,


        middle,
    }
}