using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "margin-type")]
    public enum margintype
    {
        odd,


        even,


        both,
    }
}