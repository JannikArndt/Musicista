using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("score-timewise", Namespace = "", IsNullable = false)]
    public class ScoreTimewise : MusicXMLScore
    {
        public ScoreTimewise()
        {
            Version = "2.0";
        }

        [XmlElement("measure")]
        public ScoretimewiseMeasure[] Measure { get; set; }
    }
}