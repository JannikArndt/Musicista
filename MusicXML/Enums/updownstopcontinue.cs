using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "up-down-stop-continue")]
    public enum updownstopcontinue
    {
        up,


        down,


        stop,


        @continue,
    }
}