using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
    public class Measure
    {
        public Measure()
        {
            ListOfSymbols = new List<Symbol>();
            Instrument = new Instrument();
        }
        [XmlIgnore]
        public MeasureGroup ParentMeasureGroup { get; set; }
        public Instrument Instrument { get; set; }
        [XmlElement("Note", Type = typeof(Note))]
        [XmlElement("Rest", Type = typeof(Rest))]
        public List<Symbol> ListOfSymbols { get; set; }
    }
}
