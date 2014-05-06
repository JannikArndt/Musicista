
namespace Model.Meta
{
    public class MusicalKey
    {
        public Pitch Pitch;
        public Gender Gender;

        public MusicalKey(Pitch pitch, Gender gender)
        {
            Pitch = pitch;
            Gender = gender;
        }

        public override bool Equals(object obj)
        {
            var item = obj as MusicalKey;
            if (item == null)
                return false;
            if (base.Equals(obj))
                return true;
            return (Pitch.Equals(item.Pitch) && Gender.Equals(item.Gender));
        }
    }
}
