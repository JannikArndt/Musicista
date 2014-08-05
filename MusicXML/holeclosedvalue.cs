using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "hole-closed-value")]
    public enum holeclosedvalue
    {
        yes,


        no,


        half,
    }
}