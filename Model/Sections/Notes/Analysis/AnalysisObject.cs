﻿using System.Xml.Serialization;

namespace Model.Sections.Notes.Analysis
{
    public class AnalysisObject
    {
        [XmlAttribute("Beat")]
        public double Beat { get; set; }

        [XmlAttribute("Key")]
        public string Key { get; set; }

        [XmlAttribute("Value")]
        public string Value { get; set; }

        [XmlIgnore]
        public MeasureGroup ParentMeasureGroup { get; set; }


        [XmlIgnore]
        public int MeasureNumber
        {
            get { return ParentMeasureGroup.MeasureNumber; }
        }

        public AnalysisObject(double beat, MeasureGroup parentMeasureGroup)
        {
            Beat = beat;
            ParentMeasureGroup = parentMeasureGroup;
        }

        public AnalysisObject() { }
    }
}
