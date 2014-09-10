﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model.View
{
    public class Style
    {
        [XmlArray("MovementMetric")]
        public List<Metrics> MetricForMovement { get; set; }

        public Style()
        {
            MetricForMovement = new List<Metrics>();
        }
    }
}
