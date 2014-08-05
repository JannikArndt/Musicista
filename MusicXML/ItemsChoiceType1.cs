using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {
        chord,


        cue,


        duration,


        grace,


        pitch,


        rest,


        tie,


        unpitched,
    }
}