using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "stick-type")]
    public enum sticktype
    {
        [XmlEnum("bass drum")] bassdrum,


        [XmlEnum("double bass drum")] doublebassdrum,


        timpani,


        xylophone,


        yarn,
    }
}