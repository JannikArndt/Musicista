using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "part-list")]
    public class Partlist
    {
        [XmlElement("part-group")]
        public List<partgroup> PartGroups { get; set; }

        [XmlElement("score-part")]
        public List<ScorePart> ScoreParts { get; set; }
    }
}