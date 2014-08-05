using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType9
    {
        [XmlEnum("beat-type")] beattype,


        beats,


        interchangeable,


        [XmlEnum("senza-misura")] senzamisura,
    }
}