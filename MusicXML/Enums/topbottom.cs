using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "top-bottom")]
    public enum topbottom
    {
        top,


        bottom,
    }
}