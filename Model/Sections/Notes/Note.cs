using Model.Sections.Attributes;
using System;
using System.Linq;
using System.Xml.Serialization;

namespace Model.Sections.Notes
{
    public class Note : Symbol
    {
        /// <summary>
        /// The step of this note, i.e. C, CSharp, DFlat, ...
        /// </summary>
        [XmlAttribute("Step")]
        public Step Step { get; set; }

        /// <summary>
        /// The octave of this note, middle C is 4.
        /// </summary>
        [XmlAttribute("Octave")]
        public int Octave { get; set; }

        /// <summary>
        /// The midi-velocity, for compatability. Ranges from 0 to 127.
        /// </summary>
        [XmlAttribute("Velocity")]
        public int Velocity { get; set; } // 0-127, c.f. midi

        public Note() { }

        /// <summary>
        /// Compares this note to another note, can handle enharmonic spelling.
        /// </summary>
        /// <param name="otherStep"></param>
        /// <param name="otherOctave"></param>
        /// <returns></returns>
        public int PitchIsHigherThan(Step otherStep, int otherOctave)
        {
            if (Octave == otherOctave)
            {
                // Enharmonic equivalent
                if (Step == Step.CSharp && otherStep == Step.DFlat ||
                    Step == Step.DSharp && otherStep == Step.EFlat ||
                    Step == Step.ESharp && otherStep == Step.F ||
                    Step == Step.FSharp && otherStep == Step.GFlat ||
                    Step == Step.GSharp && otherStep == Step.AFlat ||
                    Step == Step.ASharp && otherStep == Step.BFlat ||
                    Step == Step.BSharp && otherStep == Step.C ||
                    Step == Step.CFlat && otherStep == Step.B ||
                    Step == Step.DFlat && otherStep == Step.CSharp ||
                    Step == Step.EFlat && otherStep == Step.DSharp ||
                    Step == Step.FFlat && otherStep == Step.E ||
                    Step == Step.GFlat && otherStep == Step.FSharp ||
                    Step == Step.AFlat && otherStep == Step.GSharp ||
                    Step == Step.BFlat && otherStep == Step.ASharp)
                    return 0;
                return Step.CompareTo(otherStep);
            }
            return Octave.CompareTo(otherOctave);
        }

        /// <summary>
        /// Compares this note to another note, can handle enharmonic spelling.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int PitchIsHigherThan(Note other)
        {
            return PitchIsHigherThan(other.Step, other.Octave);
        }

        /// <summary>
        /// Compares this note to another note, can handle enharmonic spelling.
        /// </summary>
        /// <param name="noteString"></param>
        /// <returns></returns>
        public int PitchIsHigherThan(String noteString)
        {
            var otherStep = (Step)Enum.Parse(typeof(Step), noteString.Substring(0, noteString.Length - 1));
            var otherOctave = int.Parse(noteString.Substring(noteString.Length - 1, 1));
            return PitchIsHigherThan(otherStep, otherOctave);
        }

        public override string ToString()
        {
            return "" + Step + Octave + " on " + Math.Round(Beat, 2) + " for " + Duration;
        }

        /// <summary>
        /// Determines from voice and lef if the stemp should go up (true) or down (false). This does not look at the neighbouring notes!
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Calculates the interval to another note.
        /// </summary>
        /// <param name="otherNote"></param>
        /// <returns></returns>
        public Interval DistanceTo(Note otherNote)
        {
            var step1 = (int)Step.ToStepForSums();
            var step2 = (int)otherNote.Step.ToStepForSums();

            if (otherNote.Octave > Octave)
                step2 += 12 * (otherNote.Octave - Octave);
            if (otherNote.Octave < Octave)
                step1 += 12 * (Octave - otherNote.Octave);

            if (step1 > step2)
                return (Interval)(step1 - step2);
            if (step2 > step1)
                return (Interval)(step2 - step1);
            return Interval.PerfectUnison;
        }
    }
}