using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "group-barline-value")]
    public enum groupbarlinevalue
    {
        yes,


        no,


        Mensurstrich,
    }
}