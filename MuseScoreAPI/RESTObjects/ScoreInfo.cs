using System.Collections.Generic;
using System.Xml.Serialization;

namespace MuseScoreAPI.RESTObjects
{
    /// <summary>
    /// A container for a list of score objects
    /// </summary>
    [XmlRoot("scores")]
    public class ScoreInfo
    {
        [XmlElement("score")]
        public List<Score> Scores { get; set; }
    }
}
