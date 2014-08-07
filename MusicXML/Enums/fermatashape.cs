using System;
using System.Xml.Serialization;

namespace MusicXML.Enums
{
    [Serializable]
    [XmlType(TypeName = "fermata-shape")]
    public enum fermatashape
    {
        normal,


        angled,


        square,


        [XmlEnum("")]
        Item,
    }
}