using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType3
    {
        arrow,


        bend,


        [XmlEnum("double-tongue")] doubletongue,


        [XmlEnum("down-bow")] downbow,


        fingering,


        fingernails,


        fret,


        [XmlEnum("hammer-on")] hammeron,


        handbell,


        harmonic,


        heel,


        hole,


        [XmlEnum("open-string")] openstring,


        [XmlEnum("other-technical")] othertechnical,


        pluck,


        [XmlEnum("pull-off")] pulloff,


        [XmlEnum("snap-pizzicato")] snappizzicato,


        stopped,


        @string,


        tap,


        [XmlEnum("thumb-position")] thumbposition,


        toe,


        [XmlEnum("triple-tongue")] tripletongue,


        [XmlEnum("up-bow")] upbow,
    }
}