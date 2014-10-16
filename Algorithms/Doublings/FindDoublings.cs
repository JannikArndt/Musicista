using Model;
using Model.Instruments;
using Model.Sections;
using Model.Sections.Notes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Doublings
{
    /// <summary>
    /// An algorithm class that finds doublings in two given instruments
    /// </summary>
    public static class FindDoublings
    {
        /// <summary>
        /// The FindDoublings algorithm, which compares two instruments and searches for passages where they play the same notes.
        /// </summary>
        /// <param name="piece">The piece to analyze</param>
        /// <param name="instrument1">The first instrument</param>
        /// <param name="instrument2">The second instrument</param>
        /// <returns>A list of parts that reference the passages that are doubled</returns>
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
                var inst1Measure = measureGroup.Measures.FirstOrDefault(measure => measure.Instrument == instrument1);
                var inst2Measure = measureGroup.Measures.FirstOrDefault(measure => measure.Instrument == instrument2);
                if (inst1Measure == null || inst2Measure == null) continue;

                foreach (var instrument1Note in inst1Measure.Notes)
                {
                    var instrument2Note = inst2Measure.Notes.FirstOrDefault(note => Math.Abs(note.Beat - instrument1Note.Beat) < 0.01);
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
