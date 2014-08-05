using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "group-symbol-value")]
    public enum groupsymbolvalue
    {
        none,


        brace,


        line,


        bracket,


        square,
    }
}