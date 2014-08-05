using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "start-stop-continue")]
    public enum startstopcontinue
    {
    
        start,

    
        stop,

    
        @continue,
    }
}