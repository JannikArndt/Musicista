
using System.Xml.Serialization;

namespace Model.Sections.Notes.Articulation
{
    public class Wedge
    {
        [XmlAttribute("StartBeat")]
        public double StartBeat { get; set; }
        [XmlAttribute("EndBeat")]
        public double EndBeat { get; set; }
        [XmlIgnore]
        private bool _crescendo = true;
        [XmlAttribute("IsCrescendo")]
        public bool IsCrescendo { get { return _crescendo; } set { _crescendo = value; } }
        public bool IsCrescendoSpecified { get { return _crescendo; } }
        [XmlAttribute("IsDecrescendo")]
        public bool IsDecrescendo { get { return !_crescendo; } set { _crescendo = !value; } }
        public bool IsDecrescendoSpecified { get { return !_crescendo; } }

        public Wedge() { }

        public Wedge(double start, double end, bool isCrescendo)
        {
            StartBeat = start;
            EndBeat = end;
            _crescendo = isCrescendo;
        }
    }
}
