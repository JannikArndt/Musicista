using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "symbol-size")]
    public enum symbolsize
    {
        full,


        cue,


        large,
    }
}