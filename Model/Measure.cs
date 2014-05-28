using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
    public class Measure
    {
        public Measure()
        {
            Instrument = new Instrument();
        }
        [XmlIgnore]
        public MeasureGroup ParentMeasureGroup { get; set; }
        public Instrument Instrument { get; set; }
        [XmlElement("Note", Type = typeof(Note))]
        [XmlElement("Rest", Type = typeof(Rest))]
        private readonly List<Symbol> _listOfSymbols = new List<Symbol>();

        public void AddSymbol(Symbol symbol)
        {
            _listOfSymbols.Add(symbol);
            symbol.ParentMeasure = this;
        }
        public List<Symbol> Symbols
        {
            get { return _listOfSymbols; }
        }

    }
}
