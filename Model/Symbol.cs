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
    }
}
