using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "start-stop-change-continue")]
    public enum startstopchangecontinue
    {
        start,


        stop,


        change,


        @continue,
    }
}