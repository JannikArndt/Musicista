using System;
using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "beater-value")]
    public enum beatervalue
    {
        bow,


        [XmlEnum("chime hammer")] chimehammer,


        coin,


        finger,


        fingernail,


        fist,


        [XmlEnum("guiro scraper")] guiroscraper,


        hammer,


        hand,


        [XmlEnum("jazz stick")] jazzstick,


        [XmlEnum("knitting needle")] knittingneedle,


        [XmlEnum("metal hammer")] metalhammer,


        [XmlEnum("snare stick")] snarestick,


        [XmlEnum("spoon mallet")] spoonmallet,


        [XmlEnum("triangle beater")] trianglebeater,


        [XmlEnum("triangle beater plain")] trianglebeaterplain,


        [XmlEnum("wire brush")] wirebrush,
    }
}