using Model.Meta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Model.Sections
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
        [XmlElement("TimeSignature")]
        public TimeSignature TimeSignature
        {
            get { return _timeSignature; }
            set { _timeSignature = value; NotifyPropertyChanged(); }
        }
        [XmlElement("KeySignature")]
        public MusicalKey KeySignature
        {
            get { return _keySignature; }
            set { _keySignature = value; NotifyPropertyChanged(); }
        }

        [XmlElement("Measures")]
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
                if (ParentPassage != null && ParentPassage.MeasureGroups.IndexOf(this) > 0)
                    return ParentPassage.MeasureGroups[ParentPassage.MeasureGroups.IndexOf(this) - 1];
                return null;
            }
        }

        [XmlIgnore]
        public MeasureGroup Next
        {
            get
            {
                if (ParentPassage != null && ParentPassage.MeasureGroups.IndexOf(this) > -1 &&
                    ParentPassage.MeasureGroups.IndexOf(this) < ParentPassage.MeasureGroups.Count - 1)
                    return ParentPassage.MeasureGroups[ParentPassage.MeasureGroups.IndexOf(this) + 1];
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