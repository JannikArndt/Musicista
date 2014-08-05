using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "start-note")]
    public enum startnote
    {
    
        upper,

    
        main,

    
        below,
    }
}