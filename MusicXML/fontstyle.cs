using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "font-style")]
    public enum fontstyle
    {
        normal,


        italic,
    }
}