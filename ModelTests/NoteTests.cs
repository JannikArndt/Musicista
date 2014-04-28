using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Model.Tests
{
    [TestClass()]
    public class NoteTests
    {
        [TestMethod()]
        public void PitchIsHigherThanTest()
        {
            var Note1 = new Note { Octave = 1, Step = Meta.Pitch.C };
            var Note2 = new Note { Octave = 1, Step = Meta.Pitch.DSharp };
            var Note3 = new Note { Octave = 1, Step = Meta.Pitch.EFlat };
            var Note4 = new Note { Octave = 2, Step = Meta.Pitch.C };

            // Different steps, same octave
            Assert.IsTrue(Note1.PitchIsHigherThan(Note2) == -1);
            Assert.IsTrue(Note2.PitchIsHigherThan(Note1) == 1);

            // Different octaves
            Assert.IsTrue(Note1.PitchIsHigherThan(Note4) == -1);
            Assert.IsTrue(Note4.PitchIsHigherThan(Note1) == 1);

            // Enharmonic euqivalents
            Assert.IsTrue(Note2.PitchIsHigherThan(Note3) == 0);
        }
    }
}
