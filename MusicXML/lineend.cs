using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "line-end")]
    public enum lineend
    {
        up,


        down,


        both,


        arrow,


        none,
    }
}