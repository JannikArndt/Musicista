using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "start-stop-discontinue")]
    public enum startstopdiscontinue
    {
        start,


        stop,


        discontinue,
    }
}