using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Model.Meta
{
    /// <summary>
    ///     3/4: Beats = 3, BeatUnit = 4
    /// </summary>
    public class TimeSignature : INotifyPropertyChanged
    {
        private int _beatUnit = 4;
        private int _beats = 4;
        private bool _isCommon;
        private bool _isCutCommon;

        public TimeSignature()
        {
        }

        public TimeSignature(int beats, int beatUnit)
        {
            Beats = beats;
            BeatUnit = beatUnit;
            IsCommon = false;
            IsCutCommon = false;
        }

        public TimeSignature(bool isCommon = false, bool isCutCommon = false)
        {
            if (isCommon)
                IsCommon = true;
            else if (isCutCommon)
                IsCutCommon = true;
            else
            {
                Beats = 4;
                BeatUnit = 4;
            }
        }
        [XmlAttribute("Beats")]
        public int Beats
        {
            get { return _beats; }
            set
            {
                if (value == _beats) return;
                _beats = value;
                NotifyPropertyChanged();
            }
        }
        [XmlAttribute("BeatUnit")]
        public int BeatUnit
        {
            get { return _beatUnit; }
            set
            {
                if (value == _beatUnit) return;
                _beatUnit = value;
                NotifyPropertyChanged();
            }
        }

        [XmlAttribute, DefaultValue(false)]
        public bool IsCommon // 4/4 = c
        {
            get { return _isCommon; }
            set
            {
                if (_isCommon == value) return;
                if (value)
                {
                    IsCutCommon = false;
                    Beats = 4;
                    BeatUnit = 4;
                }
                _isCommon = value;
                NotifyPropertyChanged();
            }
        }

        [XmlAttribute, DefaultValue(false)]
        public bool IsCutCommon // 2/2 = </:
        {
            get { return _isCutCommon; }
            set
            {
                if (value == _isCutCommon) return;
                if (value)
                {
                    IsCommon = false;
                    Beats = 2;
                    BeatUnit = 2;
                }
                _isCutCommon = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool Equals(object obj)
        {
            var other = (TimeSignature)obj;
            if (other == null)
                return false;
            if (IsCommon)
                return other.IsCommon;
            if (IsCutCommon)
                return other.IsCutCommon;
            if (other.IsCommon)
                return IsCommon;
            if (other.IsCutCommon)
                return IsCutCommon;
            return Beats == other.Beats && BeatUnit == other.BeatUnit;
        }

        public override int GetHashCode()
        {
            return Beats.GetHashCode() ^ BeatUnit.GetHashCode() ^ IsCommon.GetHashCode() ^ IsCutCommon.GetHashCode();
        }

        public override string ToString()
        {
            if (IsCommon) return "Common 4/4";
            if (IsCutCommon) return "Cut 2/2";
            return Beats + "/" + BeatUnit;
        }
    }
}