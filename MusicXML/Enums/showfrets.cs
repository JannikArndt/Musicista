using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "show-frets")]
    public enum showfrets
    {
        numbers,


        letters,
    }
}