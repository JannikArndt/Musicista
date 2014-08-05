using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    public enum mute
    {
        on,


        off,


        straight,


        cup,


        [XmlEnum("harmon-no-stem")] harmonnostem,


        [XmlEnum("harmon-stem")] harmonstem,


        bucket,


        plunger,


        hat,


        solotone,


        practice,


        [XmlEnum("stop-mute")] stopmute,


        [XmlEnum("stop-hand")] stophand,


        echo,


        palm,
    }
}