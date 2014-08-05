using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "font-weight")]
    public enum fontweight
    {
        normal,


        bold,
    }
}