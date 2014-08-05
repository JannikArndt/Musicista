using System;

using System.Xml.Serialization;

namespace MusicXML.Enums
{
    
    [Serializable]
    [XmlType(TypeName = "time-symbol")]
    public enum timesymbol
    {
        common,


        cut,


        [XmlEnum("single-number")] singlenumber,


        note,


        [XmlEnum("dotted-note")] dottednote,


        normal,
    }
}