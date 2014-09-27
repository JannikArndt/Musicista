using Model.Instruments;
using Model.Sections.Attributes;
using Model.Sections.Notes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model.Sections
{
    public class Passage
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlElement("MeasureGroup")]
        public List<MeasureGroup> MeasureGroups { get; set; }
        [XmlIgnore]
        public Segment ParentSegment { get; set; }

        public Passage()
        {
        }

        public Passage(IEnumerable<Symbol> symbols)
        {
            ParentSegment = new Segment { Title = "temp" };
            MeasureGroups = new List<MeasureGroup>();

            var currentMeasureGroup = new MeasureGroup();
            var currentMeasure = new Measure();
            var firstRun = true;

            foreach (var symbol in symbols)
            {
                if (symbol.MeasureNumber != currentMeasureGroup.MeasureNumber || firstRun)
                {
                    currentMeasureGroup = new MeasureGroup
                    {
                        MeasureNumber = symbol.MeasureNumber,
                        KeySignature = symbol.ParentMeasure != null && symbol.ParentMeasure.ParentMeasureGroup != null ? symbol.ParentMeasure.ParentMeasureGroup.KeySignature : new MusicalKey(Step.C, Gender.Major),
                        TimeSignature = symbol.ParentMeasure != null && symbol.ParentMeasure.ParentMeasureGroup != null ? symbol.ParentMeasure.ParentMeasureGroup.TimeSignature : new TimeSignature(4, 4),
                        ParentPassage = this
                    };
                    currentMeasure = new Measure
                    {
                        Clef = symbol.ParentMeasure != null ? symbol.ParentMeasure.Clef : Clef.Treble,
                        Instrument = symbol.ParentMeasure != null ? symbol.ParentMeasure.Instrument : new Instrument("temporary Instrument"),
                        ParentMeasureGroup = currentMeasureGroup
                    };
                    currentMeasureGroup.Measures.Add(currentMeasure);
                    MeasureGroups.Add(currentMeasureGroup);
                    firstRun = false;
                }
                currentMeasure.AddSymbol(symbol);
            }
        }

        public Passage(IEnumerable<Measure> measures)
        {
            ParentSegment = new Segment { Title = "temp" };
            MeasureGroups = new List<MeasureGroup>();

            foreach (var measure in measures)
            {
                var newMeasureGroup = new MeasureGroup
                {
                    Measures = new List<Measure> { measure },
                    MeasureNumber = measure.ParentMeasureGroup.MeasureNumber,
                    KeySignature = measure.ParentMeasureGroup.KeySignature,
                    TimeSignature = measure.ParentMeasureGroup.TimeSignature,
                    ParentPassage = this
                };

                measure.ParentMeasureGroup = newMeasureGroup;
                MeasureGroups.Add(newMeasureGroup);
            }
        }
    }
}
