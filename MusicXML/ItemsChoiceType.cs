using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType
    {
        encoder,


        [XmlEnum("encoding-date")] encodingdate,


        [XmlEnum("encoding-description")] encodingdescription,


        software,


        supports,
    }
}