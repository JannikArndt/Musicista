using System.Collections.Generic;
using System.Xml.Serialization;

namespace MuseScoreAPI.RESTObjects
{
    [XmlRoot("scores")]
    public class ScoreInfo
    {
        [XmlElement("score")]
        public List<Score> Scores { get; set; }
    }
}
