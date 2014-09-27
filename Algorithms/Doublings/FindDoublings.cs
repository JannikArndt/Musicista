using Model;
using Model.Instruments;
using Model.Sections;
using Model.Sections.Notes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Doublings
{
    public static class FindDoublings
    {
        public static List<Part> Run(Piece piece, Instrument instrument1, Instrument instrument2)
        {
            if (piece == null)
                throw new ArgumentException("piece");
            if (instrument1 == null)
                throw new ArgumentException("instrument1");
            if (instrument2 == null)
                throw new ArgumentException("instrument2");

            var results = new List<Part>();
            var similarNotes = new List<Symbol>();

            foreach (var measureGroup in piece.MeasureGroups)
            {
                var instrument1Notes = measureGroup.Measures.First(measure => measure.Instrument == instrument1).Notes;
                var instrument2Notes = measureGroup.Measures.First(measure => measure.Instrument == instrument2).Notes;

                foreach (var instrument1Note in instrument1Notes)
                {
                    var instrument2Note = instrument2Notes.FirstOrDefault(note => Math.Abs(note.Beat - instrument1Note.Beat) < 0.01);
                    if (instrument2Note != null && instrument1Note.Step == instrument2Note.Step && instrument1Note.Duration == instrument2Note.Duration)
                        similarNotes.Add(instrument1Note);
                    else if (similarNotes.Count > 0)
                    {
                        results.Add(new Part(new Passage(similarNotes), measureGroup.ParentPassage.ParentSegment.ParentMovement));
                        similarNotes.Clear();
                    }
                }
            }

            return results;
        }
    }
}
