using Model.Meta;

namespace Model.Sections.Notes.Analysis
{
    public class Chord
    {
        public Step Step { get; set; }
        public Gender Gender { get; set; }

        public Chord(Step step, Gender gender)
        {
            Step = step;
            Gender = gender;
        }

        public override string ToString()
        {
            return Step + " " + Gender;
        }
    }
}
