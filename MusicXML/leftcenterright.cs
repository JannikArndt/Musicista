using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "left-center-right")]
    public enum leftcenterright
    {
        left,


        center,


        right,
    }
}