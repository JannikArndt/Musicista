using System;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    public class work
    {
        [XmlElement("work-number")]
        public string WorkNumber { get; set; }

        [XmlElement("work-title")]
        public string WorkTitle { get; set; }

        [XmlElement("opus")]
        public opus Opus { get; set; }
    }
}