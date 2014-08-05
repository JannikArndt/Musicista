using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "time-relation")]
    public enum timerelation
    {
        parentheses,


        bracket,


        equals,


        slash,


        space,


        hyphen,
    }
}