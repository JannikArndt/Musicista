using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    public enum membrane
    {
        [XmlEnum("bass drum")] bassdrum,


        [XmlEnum("bass drum on side")] bassdrumonside,


        bongos,


        [XmlEnum("conga drum")] congadrum,


        [XmlEnum("goblet drum")] gobletdrum,


        [XmlEnum("military drum")] militarydrum,


        [XmlEnum("snare drum")] snaredrum,


        [XmlEnum("snare drum snares off")] snaredrumsnaresoff,


        tambourine,


        [XmlEnum("tenor drum")] tenordrum,


        timbales,


        tomtom,
    }
}