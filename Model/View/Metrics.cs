
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Model.View
{
    public class Metrics
    {
        public int MovementNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double MarginTop { get; set; }
        public double MarginBelowTitle { get; set; }
        public double StaffSpacing { get; set; }
        public double SystemSpacing { get; set; }
        public double SystemMarginLeft { get; set; }
        public double SystemMarginRight { get; set; }
        public int MeasuresPerSystemThreshold { get; set; }
        [XmlIgnore]
        public List<int> MeasuresPerSystem { get; set; }

        [XmlElement("MeasuresPerSystem")]
        public String MeasuresPerSystemString
        {
            get { return String.Join(",", MeasuresPerSystem); }
            set { MeasuresPerSystem = Array.ConvertAll(value.Split(','), int.Parse).ToList(); }
        }
    }
}
