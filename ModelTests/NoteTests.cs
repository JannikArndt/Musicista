using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Meta;
using Model.Sections.Attributes;
using Model.Sections.Notes;

namespace ModelTests
{
    [TestClass]
    public class NoteTests
    {
        [TestMethod]
        public void PitchIsHigherThanTest()
        {
            var Note1 = new Note { Octave = 1, Step = Step.C };
            var Note2 = new Note { Octave = 1, Step = Step.DSharp };
            var Note3 = new Note { Octave = 1, Step = Step.EFlat };
            var Note4 = new Note { Octave = 2, Step = Step.C };

            // Different steps, same octave
            Assert.IsTrue(Note1.PitchIsHigherThan(Note2) == -1);
            Assert.IsTrue(Note2.PitchIsHigherThan(Note1) == 1);

            // Different octaves
            Assert.IsTrue(Note1.PitchIsHigherThan(Note4) == -1);
            Assert.IsTrue(Note4.PitchIsHigherThan(Note1) == 1);

            // Enharmonic euqivalents
            Assert.IsTrue(Note2.PitchIsHigherThan(Note3) == 0);
        }

        [TestMethod]
        public void DistanceTest()
        {
            var Note1 = new Note { Octave = 1, Step = Step.C };
            var Note2 = new Note { Octave = 1, Step = Step.DSharp };
            var Note3 = new Note { Octave = 1, Step = Step.EFlat };
            var Note4 = new Note { Octave = 2, Step = Step.C };
            var Note5 = new Note { Octave = 2, Step = Step.D };

            // Same for enharmonic equivalents
            Assert.IsTrue(Note1.DistanceTo(Note2) == Interval.MinorThird);
            Assert.IsTrue(Note1.DistanceTo(Note3) == Interval.MinorThird);

            // Same for different order
            Assert.IsTrue(Note1.DistanceTo(Note4) == Interval.PerfectOctave);
            Assert.IsTrue(Note4.DistanceTo(Note1) == Interval.PerfectOctave);

            // More than one octave
            Assert.IsTrue(Note1.DistanceTo(Note5) == Interval.MajorNinth);
            Assert.IsTrue(Note5.DistanceTo(Note1) == Interval.MajorNinth);
        }

        [TestMethod]
        public void PitchConversion()
        {
            Assert.IsTrue(Step.C.ToStepForSums() == StepForSums.C);
            Assert.IsTrue(Step.CSharp.ToStepForSums() == StepForSums.CSharp);
            Assert.IsTrue(Step.DFlat.ToStepForSums() == StepForSums.CSharp);
            Assert.IsTrue(Step.ESharp.ToStepForSums() == StepForSums.F);
            Assert.IsTrue(Step.A.ToStepForSums() == StepForSums.A);
        }
    }
}