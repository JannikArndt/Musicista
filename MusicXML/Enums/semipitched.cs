using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "semi-pitched")]
    public enum semipitched
    {
        high,


        [XmlEnum("medium-high")] mediumhigh,


        medium,


        [XmlEnum("medium-low")] mediumlow,


        low,


        [XmlEnum("very-low")] verylow,
    }
}