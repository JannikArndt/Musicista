using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "measure-numbering-value")]
    public enum measurenumberingvalue
    {
        none,


        measure,


        system,
    }
}