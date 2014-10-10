using Model.Instruments;
using Model.Sections.Notes;
using Model.Sections.Notes.Articulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Model.Sections
{
    public class Measure : INotifyPropertyChanged
    {
        [XmlIgnore]
        private List<Symbol> _listOfSymbols = new List<Symbol>();
        [XmlIgnore]
        private Clef _clef;
        [XmlIgnore]
        private Instrument _instrument;
        [XmlIgnore]
        private Staff _staff;

        public Measure()
        {
            Instrument = new Instrument();
            Staff = new Staff();
        }

        /// <summary>
        /// The clef of this measure.
        /// </summary>
        [XmlAttribute("Clef")]
        public Clef Clef
        {
            get { return _clef; }
            set
            {
                _clef = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The MeasureGroup that contains this Measure.
        /// </summary>
        [XmlIgnore]
        public MeasureGroup ParentMeasureGroup { get; set; }

        /// <summary>
        /// The instrument's ID, if the instrument is set. Otherwise the IDBackup. The setter automatically looks for the corresponding instrument to link.
        /// </summary>
        [XmlAttribute("InstrumentID")]
        public int InstrumentID
        {
            get { return Instrument != null && Instrument.ID != 0 ? Instrument.ID : _instrumentIDBackup; }
            set
            {
                if (ParentMeasureGroup != null)
                    Instrument =
                        ParentMeasureGroup.ParentPassage.ParentSegment.ParentMovement.ParentSection.ParentPiece
                            .Instruments.FirstOrDefault(instrument => instrument.ID == value);
                else
                    _instrumentIDBackup = value;
            }
        }

        [XmlIgnore]
        private int _instrumentIDBackup;

        /// <summary>
        /// The instrument that this measure belongs to.
        /// </summary>
        [XmlIgnore]
        public Instrument Instrument
        {
            get { return _instrument; }
            set { _instrument = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// The ID of the staff that this measure belongs to. The staff is a property of the instrument.
        /// </summary>
        [XmlAttribute("StaffID")]
        public int StaffID
        {
            get { return Staff.ID; }
            set
            {
                if (ParentMeasureGroup != null)
                    Staff = ParentMeasureGroup.ParentPassage.ParentSegment.ParentMovement.ParentSection.ParentPiece.Staves.FirstOrDefault(staff => staff.ID == value);
            }
        }

        /// <summary>
        /// The staff of the instrument where this measure is supposed to be.
        /// </summary>
        [XmlIgnore]
        public Staff Staff
        {
            get { return _staff; }
            set { _staff = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// The Note, Rest and GraceNote objects are stored in this list. To access them seperately, use Notes and Rests.
        /// </summary>
        [XmlElement("Note", Type = typeof(Note))]
        [XmlElement("GraceNote", Type = typeof(GraceNote))]
        [XmlElement("Rest", Type = typeof(Rest))]
        public List<Symbol> Symbols { get { return _listOfSymbols; } set { _listOfSymbols = value; } }

        /// <summary>
        /// Those symbols that are of type Note.
        /// </summary>
        [XmlIgnore]
        public List<Note> Notes { get { return _listOfSymbols.OfType<Note>().ToList(); } }

        /// <summary>
        /// This symbols that are of type Rest.
        /// </summary>
        [XmlIgnore]
        public List<Rest> Rests { get { return _listOfSymbols.OfType<Rest>().ToList(); } }

        /// <summary>
        /// A wedge for crescendos and decrescendos. Remember to set the start and end beat.
        /// </summary>
        [XmlElement("Wedge")]
        public Wedge Wedge { get; set; }

        /// <summary>
        /// A list of all voice-numbers that appear. Note that voice-numbers are arbitrar, i.e. the result can be 1,2,4,5.
        /// </summary>
        [XmlIgnore]
        public List<int> Voices { get { return Symbols.Select(item => item.Voice).Distinct().ToList(); } }

        /// <summary>
        /// The previous measure, i.e. from the previous MeasureGroup the measure with the same index as this one.
        /// </summary>
        [XmlIgnore]
        public Measure Previous
        {
            get
            {
                if (ParentMeasureGroup != null && ParentMeasureGroup.Previous != null && ParentMeasureGroup.Previous.Measures.Count > ParentMeasureGroup.Measures.IndexOf(this))
                    return ParentMeasureGroup.Previous.Measures[ParentMeasureGroup.Measures.IndexOf(this)];
                return null;
            }
        }

        /// <summary>
        /// The next measure, i.e. from the next MeasureGroup the measure with the same index as this one.
        /// </summary>
        [XmlIgnore]
        public Measure Next
        {
            get
            {
                if (ParentMeasureGroup != null && ParentMeasureGroup.Next != null)
                    return ParentMeasureGroup.Next.Measures[ParentMeasureGroup.Measures.IndexOf(this)];
                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Adds a symbol and sets the symbol's ParentMeasure property to this measure.
        /// </summary>
        /// <param name="symbol"></param>
        public void AddSymbol(Symbol symbol)
        {
            _listOfSymbols.Add(symbol);
            symbol.ParentMeasure = this;
            NotifyPropertyChanged();
        }

        /// <summary>
        /// Returns a list of all symbols at the specified beat, with a 0.01 tolerance.
        /// </summary>
        /// <param name="beat"></param>
        /// <returns></returns>
        public List<Symbol> GetSymbolsAt(double beat)
        {
            return Symbols.Where(item => Math.Abs(item.Beat - beat) < 0.01).ToList();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return "Measure of " + Instrument.Name;
        }
    }
}