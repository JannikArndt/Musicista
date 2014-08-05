using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "harmony-type")]
    public enum harmonytype
    {
        @explicit,


        implied,


        alternate,
    }
}