using System;

using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [XmlRoot("score-partwise")]
    public class ScorePartwise : MusicXMLScore
    {
        public ScorePartwise()
        {
            Version = "3.0";
        }

        [XmlElement("part")]
        public ScorePartwisePart[] Part { get; set; }
    }
}