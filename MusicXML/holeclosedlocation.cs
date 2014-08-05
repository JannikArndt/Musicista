using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "hole-closed-location")]
    public enum holeclosedlocation
    {
        right,


        bottom,


        left,


        top,
    }
}