using System;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [XmlType(TypeName = "part-list")]
    public class Partlist
    {
        [XmlElement("part-group", typeof(partgroup), Order = 2),
         XmlElement("score-part", typeof(ScorePart), Order = 2)]
        public object[] Items { get; set; }
    }
}