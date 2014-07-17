using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Model
{
    public class Measure
    {
        public Clef Clef { get; set; }
        public Measure()
        {
            Instrument = new Instrument();
        }
        [XmlIgnore]
        public MeasureGroup ParentMeasureGroup { get; set; }
        public Instrument Instrument { get; set; }
        [XmlIgnore]
        private readonly List<Symbol> _listOfSymbols = new List<Symbol>();

        public void AddSymbol(Symbol symbol)
        {
            _listOfSymbols.Add(symbol);
            symbol.ParentMeasure = this;
        }
        [XmlElement("Note", Type = typeof(Note))]
        [XmlElement("Rest", Type = typeof(Rest))]
        public List<Symbol> Symbols
        {
            get { return _listOfSymbols; }
        }

        [XmlIgnore]
        public List<int> Voices
        {
            get
            {
                return Symbols.Select(item => item.Voice).Distinct().ToList();
            }
        }

        [XmlIgnore]
        public Measure Previous
        {
            get
            {
                if (ParentMeasureGroup != null && ParentMeasureGroup.Previous != null)
                    return ParentMeasureGroup.Previous.Measures[ParentMeasureGroup.Measures.IndexOf(this)];
                return null;
            }
        }
        [XmlIgnore]
        public Measure Next
        {
            get
            {
                if (ParentMeasureGroup != null && ParentMeasureGroup.Next != null)
                    return ParentMeasureGroup.Next.Measures[ParentMeasureGroup.Measures.IndexOf(this)];
                return null;
            }
        }

        public List<Symbol> GetSymbolsAt(double beat)
        {
            return Symbols.Where(item => Math.Abs(item.Beat - beat) < 0.01).ToList();
        }
    }
}
