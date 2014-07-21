using Model.Meta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Model
{
    public class MeasureGroup : INotifyPropertyChanged
    {
        [XmlIgnore]
        private bool _isPickupMeasure;
        [XmlIgnore]
        private MusicalKey _keySignature;
        [XmlIgnore]
        private TimeSignature _timeSignature;
        [XmlIgnore]
        private int _measureNumber;

        public MeasureGroup()
        {
            Measures = new List<Measure>();
        }


        [XmlAttribute("MeasureNumber")]
        public int MeasureNumber
        {
            get { return _measureNumber; }
            set { _measureNumber = value; NotifyPropertyChanged(); }
        }

        public TimeSignature TimeSignature
        {
            get { return _timeSignature; }
            set { _timeSignature = value; NotifyPropertyChanged(); }
        }

        public MusicalKey KeySignature
        {
            get { return _keySignature; }
            set { _keySignature = value; NotifyPropertyChanged(); }
        }

        public List<Measure> Measures { get; set; }

        [XmlIgnore]
        public Passage ParentPassage { get; set; }


        [XmlAttribute, DefaultValue(false)]
        public bool IsPickupMeasure
        {
            get { return _isPickupMeasure; }
            set
            {
                if (value) TurnIntoPickupMeasure();
                _isPickupMeasure = value;
                NotifyPropertyChanged();
            }
        }

        [XmlIgnore]
        public MeasureGroup Previous
        {
            get
            {
                if (ParentPassage != null && ParentPassage.ListOfMeasureGroups.IndexOf(this) > 0)
                    return ParentPassage.ListOfMeasureGroups[ParentPassage.ListOfMeasureGroups.IndexOf(this) - 1];
                return null;
            }
        }

        [XmlIgnore]
        public MeasureGroup Next
        {
            get
            {
                if (ParentPassage != null && ParentPassage.ListOfMeasureGroups.IndexOf(this) > -1 &&
                    ParentPassage.ListOfMeasureGroups.IndexOf(this) < ParentPassage.ListOfMeasureGroups.Count - 1)
                    return ParentPassage.ListOfMeasureGroups[ParentPassage.ListOfMeasureGroups.IndexOf(this) + 1];
                return null;
            }
        }

        [XmlIgnore]
        public int HoldsDuration
        {
            get { return (int)(TimeSignature.Beats * ((double)Duration.Whole / TimeSignature.BeatUnit)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void TurnIntoPickupMeasure()
        {
            foreach (var measure in Measures)
            {
                var difference = measure.ParentMeasureGroup.HoldsDuration - measure.Symbols.Sum(item => (int)item.Duration);
                if (difference > 0)
                    foreach (var symbol in measure.Symbols)
                        symbol.Beat += (difference / ((double)Duration.Whole / measure.ParentMeasureGroup.TimeSignature.BeatUnit));
            }
        }
    }
}