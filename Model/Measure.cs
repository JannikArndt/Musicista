using Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Measure
    {
        public int MeasureNumber { get; set; }
        public TimeSignature TimeSignature { get; set; }
        public MusicalKey KeySignature { get; set; }
        public List<Part> Parts { get; set; }
    }
}
