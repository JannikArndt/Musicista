using Model.Meta;
using System.Xml.Serialization;
using Model.Sections.Attributes;

namespace Model.Sections.Notes.Analysis
{
    public class Harmony : AnalysisObject
    {
        [XmlAttribute("Step")]
        public Step Step { get; set; }
        [XmlAttribute("Gender")]
        public Gender Gender { get; set; }
        [XmlAttribute]
        public DiatonicFunction Function { get; set; }

        public Harmony(double beat, Chord chord, MeasureGroup parentMeasureGroup)
            : base(beat, parentMeasureGroup)
        {
            Step = chord.Step;
            Gender = chord.Gender;
        }

        public Harmony() { }

        public override string ToString()
        {
            return Step + " " + Gender;
        }
    }
}
