using System.Collections.Generic;

namespace Model
{
    public class Passage
    {
        public List<MeasureGroup> ListOfMeasureGroups { get; set; }
        public string Title { get; set; }
        public Passage() { }

        public Passage(IEnumerable<Symbol> symbols)
        {
            ListOfMeasureGroups = new List<MeasureGroup>();

            var currentMeasureGroup = new MeasureGroup();
            var currentMeasure = new Measure();

            foreach (var symbol in symbols)
            {
                if (symbol.MeasureNumber != currentMeasureGroup.MeasureNumber)
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
                    ListOfMeasureGroups.Add(currentMeasureGroup);
                }
                currentMeasure.AddSymbol(symbol);
            }
        }

        public Passage(IEnumerable<Measure> measures)
        {
            ListOfMeasureGroups = new List<MeasureGroup>();

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
                ListOfMeasureGroups.Add(newMeasureGroup);
            }
        }
    }
}
