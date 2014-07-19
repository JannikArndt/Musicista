using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Model.Meta
{
    public class MusicalKey : INotifyPropertyChanged
    {
        [XmlIgnore]
        private Gender _gender;
        [XmlIgnore]
        private Pitch _pitch;

        public MusicalKey()
        {
        }

        public MusicalKey(Pitch pitch, Gender gender)
        {
            Pitch = pitch;
            Gender = gender;
        }

        public Pitch Pitch
        {
            get { return _pitch; }
            set
            {
                _pitch = value;
                NotifyPropertyChanged();
            }
        }

        public Gender Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Equals(object obj)
        {
            var item = obj as MusicalKey;
            if (item == null)
                return false;
            return (Pitch.Equals(item.Pitch) && Gender.Equals(item.Gender));
        }

        public override int GetHashCode()
        {
            return Pitch.GetHashCode() ^ Gender.GetHashCode();
        }

        public override string ToString()
        {
            return Pitch + " " + Gender;
        }

        public bool NoteIsInKey(Pitch pitch)
        {
            if ((Pitch == Pitch.C && Gender == Gender.Major) || (Pitch == Pitch.A && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.C, Pitch.D, Pitch.E, Pitch.F, Pitch.G, Pitch.A, Pitch.B }.Contains(pitch);

            if ((Pitch == Pitch.G && Gender == Gender.Major) || (Pitch == Pitch.E && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.C, Pitch.D, Pitch.E, Pitch.FSharp, Pitch.G, Pitch.A, Pitch.B }.Contains(pitch);

            if ((Pitch == Pitch.D && Gender == Gender.Major) || (Pitch == Pitch.B && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.CSharp, Pitch.D, Pitch.E, Pitch.FSharp, Pitch.G, Pitch.A, Pitch.B }.Contains(pitch);

            if ((Pitch == Pitch.A && Gender == Gender.Major) || (Pitch == Pitch.FSharp && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.CSharp, Pitch.D, Pitch.E, Pitch.FSharp, Pitch.GSharp, Pitch.A, Pitch.B }.Contains(pitch);

            if ((Pitch == Pitch.E && Gender == Gender.Major) || (Pitch == Pitch.CSharp && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.CSharp, Pitch.DSharp, Pitch.E, Pitch.FSharp, Pitch.GSharp, Pitch.A, Pitch.B }.Contains(pitch);

            if ((Pitch == Pitch.B && Gender == Gender.Major) || (Pitch == Pitch.GSharp && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.CSharp, Pitch.DSharp, Pitch.E, Pitch.FSharp, Pitch.GSharp, Pitch.ASharp, Pitch.B }.Contains(pitch);

            if ((Pitch == Pitch.FSharp && Gender == Gender.Major) || (Pitch == Pitch.DSharp && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.CSharp, Pitch.DSharp, Pitch.ESharp, Pitch.FSharp, Pitch.GSharp, Pitch.ASharp, Pitch.B }.Contains(pitch);

            if ((Pitch == Pitch.CSharp && Gender == Gender.Major) || (Pitch == Pitch.ASharp && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.CSharp, Pitch.DSharp, Pitch.ESharp, Pitch.FSharp, Pitch.GSharp, Pitch.ASharp, Pitch.BSharp }.Contains(pitch);

            if ((Pitch == Pitch.F && Gender == Gender.Major) || (Pitch == Pitch.D && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.C, Pitch.D, Pitch.E, Pitch.F, Pitch.G, Pitch.A, Pitch.BFlat }.Contains(pitch);

            if ((Pitch == Pitch.BFlat && Gender == Gender.Major) || (Pitch == Pitch.G && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.C, Pitch.D, Pitch.EFlat, Pitch.F, Pitch.G, Pitch.A, Pitch.BFlat }.Contains(pitch);

            if ((Pitch == Pitch.EFlat && Gender == Gender.Major) || (Pitch == Pitch.C && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.C, Pitch.D, Pitch.EFlat, Pitch.F, Pitch.G, Pitch.AFlat, Pitch.BFlat }.Contains(pitch);

            if ((Pitch == Pitch.AFlat && Gender == Gender.Major) || (Pitch == Pitch.F && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.C, Pitch.DFlat, Pitch.EFlat, Pitch.F, Pitch.G, Pitch.AFlat, Pitch.BFlat }.Contains(pitch);

            if ((Pitch == Pitch.DFlat && Gender == Gender.Major) || (Pitch == Pitch.BFlat && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.C, Pitch.DFlat, Pitch.EFlat, Pitch.F, Pitch.GFlat, Pitch.AFlat, Pitch.BFlat }.Contains(pitch);

            if ((Pitch == Pitch.GFlat && Gender == Gender.Major) || (Pitch == Pitch.EFlat && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.CFlat, Pitch.DFlat, Pitch.EFlat, Pitch.F, Pitch.GFlat, Pitch.AFlat, Pitch.BFlat }.Contains(pitch);

            if ((Pitch == Pitch.CFlat && Gender == Gender.Major) || (Pitch == Pitch.AFlat && Gender == Gender.Minor))
                return new List<Pitch> { Pitch.CFlat, Pitch.DFlat, Pitch.EFlat, Pitch.FFlat, Pitch.GFlat, Pitch.AFlat, Pitch.BFlat }.Contains(pitch);

            throw new Exception("musical key not found");
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}