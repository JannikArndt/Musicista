using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "kind-value")]
    public enum kindvalue
    {
        major,


        minor,


        augmented,


        diminished,


        dominant,


        [XmlEnum("major-seventh")] majorseventh,


        [XmlEnum("minor-seventh")] minorseventh,


        [XmlEnum("diminished-seventh")] diminishedseventh,


        [XmlEnum("augmented-seventh")] augmentedseventh,


        [XmlEnum("half-diminished")] halfdiminished,


        [XmlEnum("major-minor")] majorminor,


        [XmlEnum("major-sixth")] majorsixth,


        [XmlEnum("minor-sixth")] minorsixth,


        [XmlEnum("dominant-ninth")] dominantninth,


        [XmlEnum("major-ninth")] majorninth,


        [XmlEnum("minor-ninth")] minorninth,


        [XmlEnum("dominant-11th")] dominant11th,


        [XmlEnum("major-11th")] major11th,


        [XmlEnum("minor-11th")] minor11th,


        [XmlEnum("dominant-13th")] dominant13th,


        [XmlEnum("major-13th")] major13th,


        [XmlEnum("minor-13th")] minor13th,


        [XmlEnum("suspended-second")] suspendedsecond,


        [XmlEnum("suspended-fourth")] suspendedfourth,


        Neapolitan,


        Italian,


        French,


        German,


        pedal,


        power,


        Tristan,


        other,


        none,
    }
}