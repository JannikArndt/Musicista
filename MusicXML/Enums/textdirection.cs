using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "text-direction")]
    public enum textdirection
    {
        ltr,


        rtl,


        lro,


        rlo,
    }
}