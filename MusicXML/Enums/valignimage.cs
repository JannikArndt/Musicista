using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "valign-image")]
    public enum valignimage
    {
        top,


        middle,


        bottom,
    }
}