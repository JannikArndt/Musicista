﻿using Model.Meta;
using System;
using System.Linq;

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
            return "" + Step + Octave + " on " + Math.Round(Beat, 2) + " for " + Duration;
        }

        public bool StemShouldGoUp()
        {
            if (ParentMeasure.Voices.Count > 1)
                if (Voice == ParentMeasure.Voices.Min())
                    return true;
                else if (Voice == ParentMeasure.Voices.Max())
                    return false;

            switch (ParentMeasure.Clef)
            {
                case Clef.Treble:
                    return PitchIsHigherThan("B4") <= 0;
                case Clef.Bass:
                    return PitchIsHigherThan("D3") <= 0;
            }
            return true;
        }

        public Interval DistanceTo(Note otherNote)
        {
            var pitch1 = (int)Step.ToPitchForSums();
            var pitch2 = (int)otherNote.Step.ToPitchForSums();

            if (otherNote.Octave > Octave)
                pitch2 += 12 * (otherNote.Octave - Octave);
            if (otherNote.Octave < Octave)
                pitch1 += 12 * (Octave - otherNote.Octave);

            if (pitch1 > pitch2)
                return (Interval)(pitch1 - pitch2);
            if (pitch2 > pitch1)
                return (Interval)(pitch2 - pitch1);
            return Interval.PerfectUnison;
        }
    }
}