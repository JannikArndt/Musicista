using System.Collections.Generic;

namespace Model
{
    public abstract class Symbol
    {
        public double Beat { get; set; }
        public Duration Duration { get; set; }
        public int Voice { get; set; }
        public string Text { get; set; }
        public List<Expression> ListOfExpressionalModifiers { get; set; }
        public List<Ornament> ListOfOrnaments { get; set; }
        public Measure ParentMeasure { get; set; }

        public Symbol Previous
        {
            get { return ParentMeasure.Symbols.FindLast(s => s.Voice == Voice && s.Beat < Beat); }
        }
        public Symbol Next
        {
            get { return ParentMeasure.Symbols.Find(s => s.Voice == Voice && s.Beat > Beat); }
        }
        public Symbol() { }
    }
}
