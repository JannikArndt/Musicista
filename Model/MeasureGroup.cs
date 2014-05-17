using Model.Meta;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
    public class MeasureGroup
    {
        public MeasureGroup()
        {
            Measures = new List<Measure>();
        }
        [XmlAttribute("MeasureNumber")]
        public int MeasureNumber { get; set; }
        public TimeSignature TimeSignature { get; set; }
        public MusicalKey KeySignature { get; set; }
        public List<Measure> Measures { get; set; }
    }
}
