
using System;
using System.Linq;

namespace Model
{
    public class Part
    {
        public NoteReference Start { get; set; }
        public NoteReference End { get; set; }
        public Passage Passage { get; set; }
        public String Name { get; set; }
        public Part() { }
        public Part(Passage passage)
        {
            Passage = passage;
            Start = new NoteReference(Passage.ListOfMeasureGroups[0].Measures[0].Symbols[0]);
            End = new NoteReference(Passage.ListOfMeasureGroups.Last().Measures.Last().Symbols.Last());
        }
    }
}
