using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    public enum wood
    {
        [XmlEnum("board clapper")] boardclapper,


        cabasa,


        castanets,


        claves,


        guiro,


        [XmlEnum("log drum")] logdrum,


        maraca,


        maracas,


        ratchet,


        [XmlEnum("sandpaper blocks")] sandpaperblocks,


        [XmlEnum("slit drum")] slitdrum,


        [XmlEnum("temple block")] templeblock,


        vibraslap,


        [XmlEnum("wood block")] woodblock,
    }
}