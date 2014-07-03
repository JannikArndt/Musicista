
using System;
using System.Globalization;

namespace Model
{
    public class NoteReference
    {
        public int MeasureNumber { get; set; }
        public int StaffNumber { get; set; }
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
