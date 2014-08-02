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
        private Step _step;

        public MusicalKey()
        {
        }

        public MusicalKey(Step step, Gender gender)
        {
            Step = step;
            Gender = gender;
        }
        [XmlAttribute]
        public Step Step
        {
            get { return _step; }
            set
            {
                _step = value;
                NotifyPropertyChanged();
            }
        }
        [XmlAttribute]
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
            return (Step.Equals(item.Step) && Gender.Equals(item.Gender));
        }

        public override int GetHashCode()
        {
            return Step.GetHashCode() ^ Gender.GetHashCode();
        }

        public override string ToString()
        {
            return Step + " " + Gender;
        }

        public bool NoteIsInKey(Step step)
        {
            if ((Step == Step.C && Gender == Gender.Major) || (Step == Step.A && Gender == Gender.Minor))
                return new List<Step> { Step.C, Step.D, Step.E, Step.F, Step.G, Step.A, Step.B }.Contains(step);

            if ((Step == Step.G && Gender == Gender.Major) || (Step == Step.E && Gender == Gender.Minor))
                return new List<Step> { Step.C, Step.D, Step.E, Step.FSharp, Step.G, Step.A, Step.B }.Contains(step);

            if ((Step == Step.D && Gender == Gender.Major) || (Step == Step.B && Gender == Gender.Minor))
                return new List<Step> { Step.CSharp, Step.D, Step.E, Step.FSharp, Step.G, Step.A, Step.B }.Contains(step);

            if ((Step == Step.A && Gender == Gender.Major) || (Step == Step.FSharp && Gender == Gender.Minor))
                return new List<Step> { Step.CSharp, Step.D, Step.E, Step.FSharp, Step.GSharp, Step.A, Step.B }.Contains(step);

            if ((Step == Step.E && Gender == Gender.Major) || (Step == Step.CSharp && Gender == Gender.Minor))
                return new List<Step> { Step.CSharp, Step.DSharp, Step.E, Step.FSharp, Step.GSharp, Step.A, Step.B }.Contains(step);

            if ((Step == Step.B && Gender == Gender.Major) || (Step == Step.GSharp && Gender == Gender.Minor))
                return new List<Step> { Step.CSharp, Step.DSharp, Step.E, Step.FSharp, Step.GSharp, Step.ASharp, Step.B }.Contains(step);

            if ((Step == Step.FSharp && Gender == Gender.Major) || (Step == Step.DSharp && Gender == Gender.Minor))
                return new List<Step> { Step.CSharp, Step.DSharp, Step.ESharp, Step.FSharp, Step.GSharp, Step.ASharp, Step.B }.Contains(step);

            if ((Step == Step.CSharp && Gender == Gender.Major) || (Step == Step.ASharp && Gender == Gender.Minor))
                return new List<Step> { Step.CSharp, Step.DSharp, Step.ESharp, Step.FSharp, Step.GSharp, Step.ASharp, Step.BSharp }.Contains(step);

            if ((Step == Step.F && Gender == Gender.Major) || (Step == Step.D && Gender == Gender.Minor))
                return new List<Step> { Step.C, Step.D, Step.E, Step.F, Step.G, Step.A, Step.BFlat }.Contains(step);

            if ((Step == Step.BFlat && Gender == Gender.Major) || (Step == Step.G && Gender == Gender.Minor))
                return new List<Step> { Step.C, Step.D, Step.EFlat, Step.F, Step.G, Step.A, Step.BFlat }.Contains(step);

            if ((Step == Step.EFlat && Gender == Gender.Major) || (Step == Step.C && Gender == Gender.Minor))
                return new List<Step> { Step.C, Step.D, Step.EFlat, Step.F, Step.G, Step.AFlat, Step.BFlat }.Contains(step);

            if ((Step == Step.AFlat && Gender == Gender.Major) || (Step == Step.F && Gender == Gender.Minor))
                return new List<Step> { Step.C, Step.DFlat, Step.EFlat, Step.F, Step.G, Step.AFlat, Step.BFlat }.Contains(step);

            if ((Step == Step.DFlat && Gender == Gender.Major) || (Step == Step.BFlat && Gender == Gender.Minor))
                return new List<Step> { Step.C, Step.DFlat, Step.EFlat, Step.F, Step.GFlat, Step.AFlat, Step.BFlat }.Contains(step);

            if ((Step == Step.GFlat && Gender == Gender.Major) || (Step == Step.EFlat && Gender == Gender.Minor))
                return new List<Step> { Step.CFlat, Step.DFlat, Step.EFlat, Step.F, Step.GFlat, Step.AFlat, Step.BFlat }.Contains(step);

            if ((Step == Step.CFlat && Gender == Gender.Major) || (Step == Step.AFlat && Gender == Gender.Minor))
                return new List<Step> { Step.CFlat, Step.DFlat, Step.EFlat, Step.FFlat, Step.GFlat, Step.AFlat, Step.BFlat }.Contains(step);

            throw new Exception("musical key not found");
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}