
namespace Model
{
    public class NoteReference
    {
        public int MeasureNumber { get; set; }
        public double Beat { get; set; }

        public NoteReference() { }
        public NoteReference(Symbol symbol)
        {
            MeasureNumber = symbol.MeasureNumber;
            Beat = symbol.Beat;
        }
    }
}
