using Model.Meta;
using Model.Sections;
using Model.Sections.Notes;
using Model.Sections.Notes.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musicista.Algorithms
{
    public static class BasicAlgorithms
    {
        public static void HarmonicAnalysis(MeasureGroup measureGroup)
        {
            for (var beat = 1.0; beat < 5; beat++)
            {
                var symbols = measureGroup.GetSymbolsAt(beat).OfType<Note>().ToList();
                var chord = GetChordFromNotes(symbols);
                if (chord != null)
                    measureGroup.Analysis.Add(new Harmony(beat, chord, measureGroup));
            }
        }

        public static Chord GetChordFromNotes(List<Note> notes)
        {
            var steps = notes.Select(note => note.Step).ToList();

            foreach (var step1 in steps)
                foreach (var step2 in steps)
                {
                    switch (Math.Abs(step2.ToStepForSums() - step1.ToStepForSums()))
                    {
                        case 4: // Major 3
                            if (steps.Any(step3 => Math.Abs(step3.ToStepForSums() - step2.ToStepForSums()) == 3)) // Minor 3
                                return new Chord(step1, Gender.Major);
                            break;
                        case 3: // Minor 3
                            if (steps.Any(step3 => Math.Abs(step3.ToStepForSums() - step2.ToStepForSums()) == 4)) // Major 4
                                return new Chord(step1, Gender.Minor);
                            break;
                    }
                }
            return null;
        }
    }
}
