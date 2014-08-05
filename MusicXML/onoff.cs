using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "on-off")]
    public enum onoff
    {
        on,


        off,
    }
}