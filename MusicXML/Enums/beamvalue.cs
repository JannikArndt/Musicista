using System;
using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "beam-value")]
    public enum beamvalue
    {
        begin,


        @continue,


        end,


        [XmlEnum("forward hook")] forwardhook,


        [XmlEnum("backward hook")] backwardhook,
    }
}