using Model.Sections.Notes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model.Sections
{
    public class Passage
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }
        [XmlElement("MeasureGroups")]
        public List<MeasureGroup> MeasureGroups { get; set; }
        [XmlIgnore]
        public Segment ParentSegment { get; set; }

        public Passage()
        {
            MeasureGroups = new List<MeasureGroup>();
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
                        KeySignature = symbol.ParentMeasure.ParentMeasureGroup.KeySignature,
                        TimeSignature = symbol.ParentMeasure.ParentMeasureGroup.TimeSignature,
                        ParentPassage = this
                    };
                    currentMeasure = new Measure
                    {
                        Clef = symbol.ParentMeasure.Clef,
                        Instrument = symbol.ParentMeasure.Instrument,
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
