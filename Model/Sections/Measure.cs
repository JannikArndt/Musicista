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

        [XmlIgnore]
        public MeasureGroup ParentMeasureGroup { get; set; }

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

        [XmlIgnore]
        public Instrument Instrument
        {
            get { return _instrument; }
            set { _instrument = value; NotifyPropertyChanged(); }
        }

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

        [XmlIgnore]
        public Staff Staff
        {
            get { return _staff; }
            set { _staff = value; NotifyPropertyChanged(); }
        }


        [XmlElement("Note", Type = typeof(Note))]
        [XmlElement("GraceNote", Type = typeof(GraceNote))]
        [XmlElement("Rest", Type = typeof(Rest))]
        public List<Symbol> Symbols { get { return _listOfSymbols; } set { _listOfSymbols = value; } }

        [XmlIgnore]
        public List<Note> Notes { get { return _listOfSymbols.OfType<Note>().ToList(); } }

        [XmlIgnore]
        public List<Rest> Rests { get { return _listOfSymbols.OfType<Rest>().ToList(); } }

        [XmlElement("Wedge")]
        public Wedge Wedge { get; set; }

        [XmlIgnore]
        public List<int> Voices { get { return Symbols.Select(item => item.Voice).Distinct().ToList(); } }

        [XmlIgnore]
        public Measure Previous
        {
            get
            {
                if (ParentMeasureGroup != null && ParentMeasureGroup.Previous != null)
                    return ParentMeasureGroup.Previous.Measures[ParentMeasureGroup.Measures.IndexOf(this)];
                return null;
            }
        }

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

        public void AddSymbol(Symbol symbol)
        {
            _listOfSymbols.Add(symbol);
            symbol.ParentMeasure = this;
            NotifyPropertyChanged();
        }

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