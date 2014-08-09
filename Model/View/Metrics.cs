
using System.Collections.Generic;

namespace Model.View
{
    public class Metrics
    {
        public int MovementNumber { get; set; }
        public double MarginTop { get; set; }
        public double MarginBelowTitle { get; set; }
        public double StaffSpacing { get; set; }
        public double SystemSpacing { get; set; }
        public double SystemMarginLeft { get; set; }
        public double SystemMarginRight { get; set; }
        public int MeasuresPerSystemStandard { get; set; }
        public List<int> MeasuresPerSystem { get; set; }
    }
}
