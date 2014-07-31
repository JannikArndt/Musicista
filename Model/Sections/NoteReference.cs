using Model.Sections.Notes;
using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Model.Sections
{
    public class NoteReference
    {
        [XmlAttribute("MeasureNumber")]
        public int MeasureNumber { get; set; }
        [XmlAttribute("StaffNumber")]
        public int StaffNumber { get; set; }
        [XmlAttribute("Beat")]
        public double Beat { get; set; }

        public NoteReference() { }
        public NoteReference(Symbol symbol)
        {
            MeasureNumber = symbol.MeasureNumber;
            StaffNumber = symbol.ParentMeasure.ParentMeasureGroup.Measures.IndexOf(symbol.ParentMeasure);
            Beat = symbol.Beat;
        }

        public override string ToString()
        {
            return MeasureNumber + ":" + (StaffNumber + 1) + ":" + Math.Round(Beat, 2).ToString(CultureInfo.GetCultureInfo("en-US"));
        }
    }
}
