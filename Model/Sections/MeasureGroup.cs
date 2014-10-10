using Model.Sections.Attributes;
using Model.Sections.Notes;
using Model.Sections.Notes.Analysis;
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
        private List<Tempo> _tempi = new List<Tempo>();
        [XmlIgnore]
        private int _measureNumber;
        [XmlIgnore]
        private readonly List<AnalysisObject> _listOfAnalysisObjects = new List<AnalysisObject>();
        [XmlIgnore]
        private List<Barline> _barlines = new List<Barline>();

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

        /// <summary>
        /// The time signature for the complete measure group.
        /// </summary>
        [XmlElement("TimeSignature")]
        public TimeSignature TimeSignature
        {
            get { return _timeSignature; }
            set { _timeSignature = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// The key signature for the complete measure group.
        /// </summary>
        [XmlElement("KeySignature")]
        public MusicalKey KeySignature
        {
            get { return _keySignature; }
            set { _keySignature = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// A lit of Tempo elements
        /// </summary>
        [XmlElement("Tempo")]
        public List<Tempo> Tempi
        {
            get { return _tempi; }
            set { _tempi = value; NotifyPropertyChanged(); }
        }
        public bool ShouldSerializeTempo() { return Tempi != null && Tempi.Any(); }

        /// <summary>
        /// A list of AnalysisObjects
        /// </summary>
        [XmlArray("Analysis"), XmlArrayItem(typeof(Harmony)), XmlArrayItem(typeof(NoteAttribute)), XmlArrayItem(typeof(AnalysisObject))]
        public List<AnalysisObject> Analysis { get { return _listOfAnalysisObjects; } }
        public bool ShouldSerializeAnalysis() { return Analysis != null && Analysis.Any(); }

        /// <summary>
        /// A list of bar lines (since they can appear at the beginning, end or during a measure).
        /// </summary>
        [XmlArray("Barlines")]
        public List<Barline> Barlines
        {
            get { return _barlines; }
            set { _barlines = value; NotifyPropertyChanged(); }
        }
        public bool ShouldSerializeBarlines() { return Barlines != null && Barlines.Any(); }

        /// <summary>
        /// The measures with all their symbols.
        /// </summary>
        [XmlElement("Measure")]
        public List<Measure> Measures { get; set; }

        [XmlIgnore]
        public Passage ParentPassage { get; set; }

        /// <summary>
        /// If this MeasureGroup is a pick up measure. If set to true this will move all notes to the end of the measure.
        /// </summary>
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

        /// <summary>
        /// A rehearsal mark that is printed at the beginning of this measure group.
        /// </summary>
        [XmlAttribute("RehearsalMark")]
        public String RehearsalMark { get; set; }
        public bool RehearsalMarkSpecified { get { return !string.IsNullOrEmpty(RehearsalMark); } }

        /// <summary>
        /// The previous measure group. If this is the first in the passage, this will return the last measure group of the previous passage.
        /// </summary>
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

        /// <summary>
        /// The next measure grouo. If this is the last in the passage, this will return the first measure group of the next passage.
        /// </summary>
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

        /// <summary>
        /// How many beats fit in this measure group. Returns an int that can be converted into a Duration (i.e. 960 = quarter).
        /// </summary>
        [XmlIgnore]
        public int HoldsDuration
        {
            get { return (int)(TimeSignature.Beats * ((double)Duration.Whole / TimeSignature.BeatUnit)); }
        }

        /// <summary>
        /// For da Capo / dal Segno / ... repetitions. For usual repetitions use the Barlines property.
        /// </summary>
        [XmlAttribute("Repetition")]
        public Repetition Repetition { get; set; }
        public bool RepetitionSpecified { get { return Repetition != Repetition.None; } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Moves the symbols of all measures to the end.
        /// </summary>
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

        /// <summary>
        /// Returns all symbols at a given beat, with a 0.01 tolerance.
        /// </summary>
        /// <param name="beat"></param>
        /// <returns></returns>
        public List<Symbol> GetSymbolsAt(double beat)
        {
            return Measures.SelectMany(measure => measure.GetSymbolsAt(beat)).ToList();
        }

        public override string ToString()
        {
            return "MeasureGroup #" + MeasureNumber + " (" + TimeSignature + ", " + KeySignature + ")";
        }
    }
}