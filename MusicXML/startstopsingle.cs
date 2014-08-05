using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "start-stop-single")]
    public enum startstopsingle
    {
    
        start,

    
        stop,

    
        single,
    }
}