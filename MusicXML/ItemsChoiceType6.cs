using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType6
    {
        elision,


        extend,


        humming,


        laughing,


        syllabic,


        text,
    }
}