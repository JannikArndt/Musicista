using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "trill-step")]
    public enum trillstep
    {
        whole,


        half,


        unison,
    }
}