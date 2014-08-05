using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "line-type")]
    public enum linetype
    {
        solid,


        dashed,


        dotted,


        wavy,
    }
}