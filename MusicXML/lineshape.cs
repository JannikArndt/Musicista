using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "line-shape")]
    public enum lineshape
    {
        straight,


        curved,
    }
}