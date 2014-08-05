using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "left-right")]
    public enum leftright
    {
        left,


        right,
    }
}