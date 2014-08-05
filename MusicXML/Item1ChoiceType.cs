using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum Item1ChoiceType
    {
        [XmlEnum("base-pitch")] basepitch,


        [XmlEnum("sounding-pitch")] soundingpitch,


        [XmlEnum("touching-pitch")] touchingpitch,
    }
}