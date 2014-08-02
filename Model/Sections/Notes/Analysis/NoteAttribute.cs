using System;
using System.Xml.Serialization;

namespace Model.Sections.Notes.Analysis
{
    public class NoteAttribute : AnalysisObject
    {
        [XmlAttribute("SetOn")]
        public DateTime SetOn { get; set; }
        [XmlText]
        public string Text { get; set; }

        public NoteAttribute(double beat, string text, MeasureGroup parentMeasureGroup)
            : base(beat, parentMeasureGroup)
        {
            SetOn = DateTime.Now;
            Text = text;
        }

        public NoteAttribute() { }
    }
}
