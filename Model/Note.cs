using Model.Meta;
using System;

namespace Model
{
    public class Note : Symbol
    {
        public Pitch Step { get; set; }
        public int Octave { get; set; }
        public int Velocity { get; set; } // 0-127, c.f. midi

        public Note() { }
        public int PitchIsHigherThan(Pitch otherStep, int otherOctave)
        {
            if (Octave == otherOctave)
            {
                // Enharmonic equivalent
                if (Step == Pitch.CSharp && otherStep == Pitch.DFlat ||
                    Step == Pitch.DSharp && otherStep == Pitch.EFlat ||
                    Step == Pitch.ESharp && otherStep == Pitch.F ||
                    Step == Pitch.FSharp && otherStep == Pitch.GFlat ||
                    Step == Pitch.GSharp && otherStep == Pitch.AFlat ||
                    Step == Pitch.ASharp && otherStep == Pitch.BFlat ||
                    Step == Pitch.BSharp && otherStep == Pitch.C ||
                    Step == Pitch.CFlat && otherStep == Pitch.B ||
                    Step == Pitch.DFlat && otherStep == Pitch.CSharp ||
                    Step == Pitch.EFlat && otherStep == Pitch.DSharp ||
                    Step == Pitch.FFlat && otherStep == Pitch.E ||
                    Step == Pitch.GFlat && otherStep == Pitch.FSharp ||
                    Step == Pitch.AFlat && otherStep == Pitch.GSharp ||
                    Step == Pitch.BFlat && otherStep == Pitch.ASharp)
                    return 0;
                return Step.CompareTo(otherStep);
            }
            return Octave.CompareTo(otherOctave);
        }

        public int PitchIsHigherThan(Note other)
        {
            return PitchIsHigherThan(other.Step, other.Octave);
        }

        public int PitchIsHigherThan(String noteString)
        {
            var otherStep = (Pitch)Enum.Parse(typeof(Pitch), noteString.Substring(0, noteString.Length - 1));
            var otherOctave = int.Parse(noteString.Substring(noteString.Length - 1, 1));
            return PitchIsHigherThan(otherStep, otherOctave);
        }

        public override string ToString()
        {
            return "" + Step + Octave + " on " + Beat + " for " + Duration;
        }

        public bool StemShouldGoUp()
        {
            switch (ParentMeasure.Clef)
            {
                case Clef.Treble:
                    return PitchIsHigherThan("B4") <= 0;
                case Clef.Bass:
                    return PitchIsHigherThan("D3") <= 0;
            }
            return true;
        }
    }
}