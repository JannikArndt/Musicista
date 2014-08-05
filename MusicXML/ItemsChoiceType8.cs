using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType8
    {
        cancel,


        fifths,


        [XmlEnum("key-accidental")] keyaccidental,


        [XmlEnum("key-alter")] keyalter,


        [XmlEnum("key-step")] keystep,


        mode,
    }
}