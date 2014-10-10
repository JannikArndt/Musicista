using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Model.View
{
    public class MeasuresMetrics
    {
        [XmlAttribute("Threshold")]
        public int MeasuresPerSystemThreshold { get; set; }


        [XmlIgnore]
        public List<int> MeasuresPerSystem { get; set; }

        [XmlAttribute("Division")]
        public String MeasuresPerSystemString
        {
            get { return String.Join(",", MeasuresPerSystem); }
            set { MeasuresPerSystem = Array.ConvertAll(value.Split(','), int.Parse).ToList(); }
        }


        public MeasuresMetrics()
        {
            MeasuresPerSystem = new List<int>();
        }
    }
}
