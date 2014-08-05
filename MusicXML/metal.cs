using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    public enum metal
    {
        almglocken,


        bell,


        [XmlEnum("bell plate")] bellplate,


        [XmlEnum("brake drum")] brakedrum,


        [XmlEnum("Chinese cymbal")] Chinesecymbal,


        cowbell,


        [XmlEnum("crash cymbals")] crashcymbals,


        crotale,


        [XmlEnum("cymbal tongs")] cymbaltongs,


        [XmlEnum("domed gong")] domedgong,


        [XmlEnum("finger cymbals")] fingercymbals,


        flexatone,


        gong,


        [XmlEnum("hi-hat")] hihat,


        [XmlEnum("high-hat cymbals")] highhatcymbals,


        handbell,


        sistrum,


        [XmlEnum("sizzle cymbal")] sizzlecymbal,


        [XmlEnum("sleigh bells")] sleighbells,


        [XmlEnum("suspended cymbal")] suspendedcymbal,


        [XmlEnum("tam tam")] tamtam,


        triangle,


        [XmlEnum("Vietnamese hat")] Vietnamesehat,
    }
}