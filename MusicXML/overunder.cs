using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "over-under")]
    public enum overunder
    {
        over,


        under,
    }
}