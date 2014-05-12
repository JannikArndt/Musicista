using System.Collections.Generic;

namespace Model
{
    public class Measure
    {
        public MeasureGroup ParentMeasureGroup { get; set; }
        public Instrument Instrument { get; set; }
        public List<Symbol> ListOfSymbols { get; set; }
    }
}
