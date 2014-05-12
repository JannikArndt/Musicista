using Model.Meta;
using System.Collections.Generic;

namespace Model
{
    public class MeasureGroup
    {
        public int MeasureNumber { get; set; }
        public TimeSignature TimeSignature { get; set; }
        public MusicalKey KeySignature { get; set; }
        public List<Measure> Measures { get; set; }
    }
}
