using Model;
using Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Clef = Model.Clef;
using Duration = Model.Duration;
using Note = Model.Note;

namespace Musicista.UI
{
    public class UINote : UISymbol
    {
        public UINote(Note note, UIMeasure parentMeasure, bool hasMouseDown = true, bool tiedTo = false)
            : base(note, parentMeasure, hasMouseDown)
        {
            Note = note;

            BeatsPerMeasure = (4.0 / ParentMeasure.InnerMeasure.ParentMeasureGroup.TimeSignature.BeatUnit) * ParentMeasure.InnerMeasure.ParentMeasureGroup.TimeSignature.Beats;
            ParentMeasure.ConnectNotesAtEndOfRun = false;

            CanvasLeft = ((ParentMeasure.Width - ParentMeasure.Indent - ParentMeasure.MarginRight) / BeatsPerMeasure * (note.Beat - 1)) + ParentMeasure.Indent;

            // Note Head
            SetTop(NoteHead, CalculateTop(note, ParentMeasure) + 94);
            SetLeft(NoteHead, 10);
            SetDuration(note, ParentMeasure);

            // Stem & Flag
            if ((ParentMeasure.StemDirectionIsSetForGroup && ParentMeasure.StemDirectionUp) || (!ParentMeasure.StemDirectionIsSetForGroup && note.StemShouldGoUp()))
            {
                // stem goes up
                StemDirection = StemDirection.up;
                Stem.X1 = 48;
                Stem.X2 = Stem.X1;
                Stem.Y1 = GetTop(NoteHead) + 12;
                Stem.Y2 = Stem.Y1 - StemLength;

                SetTop(Flag, GetTop(NoteHead) - StemLength + 10);
                SetLeft(Flag, 48);
            }
            else
            {
                // stem goes down
                StemDirection = StemDirection.down;
                Stem.X1 = 14;
                Stem.X2 = Stem.X1;
                Stem.Y1 = GetTop(NoteHead) + 20;
                Stem.Y2 = Stem.Y1 + StemLength;

                SetTop(Flag, GetTop(NoteHead) + 30);
                SetLeft(Flag, 14);
            }

            // Handle overlapping notes (in seperate voices)
            foreach (var overlappingNote in ParentMeasure.InnerMeasure.GetSymbolsAt(Note.Beat).OfType<Note>().Where(item => item.Octave == Note.Octave && item.Step == Note.Step))
                if (overlappingNote.Duration >= Duration.halfTriplet || Note.Duration >= Duration.halfTriplet)
                    if (overlappingNote.Voice < Note.Voice)
                    {
                        SetLeft(NoteHead, 50);
                        Stem.X1 = Stem.X2 += 40;
                    }
            Children.Add(NoteHead);
            if (note.DurationInMeasure < Duration.whole && note.DurationInMeasure != Duration.wholeTriplet)
                Children.Add(Stem);
            else
                StemDirection = StemDirection.none;
            Children.Add(Flag);
            ParentMeasure.Children.Add(this);

            // Connect eigths / sixteenths / thirtyseconds
            if (ParentMeasure.ConnectNotesAtEndOfRun
                || ParentMeasure.NotYetConnectedNotes.Count == 4
                || (ParentMeasure.NotYetConnectedNotes.Any() && note.Next != null && (note.Next.Beat == 3 || note.Next.Beat == 1))
                || (ParentMeasure.NotYetConnectedNotes.Any(item => item.Note.Duration == Duration.sixteenth) && note.Next != null && (note.Next.Beat == 2 || note.Next.Beat == 4))
                || ParentMeasure.NotYetConnectedNotes.Count == 3 && (ParentMeasure.NotYetConnectedNotes.All(item => item.Symbol.Duration == Duration.sixteenthTriplet)
                   || ParentMeasure.NotYetConnectedNotes.All(item => item.Symbol.Duration == Duration.eigthTriplet)))
            {
                ParentMeasure.BalanceStems();
                ParentMeasure.ConnectNotes();
            }

            // Handle triplets ( /tuplets)
            if (note.IsTriplet && !ParentMeasure.Tuplets.Select(item => item.Symbol.Beat).Contains(note.Beat))
                ParentMeasure.Tuplets.Add(this);
            if (ParentMeasure.Tuplets.Count > 2 || (ParentMeasure.Tuplets.Any() && !note.IsTriplet))
                ParentMeasure.ConnectTuplets();

            // Draw ties

            const int moveTieMidToLeft = 120;
            const int tieHeight = 40;

            if (tiedTo)
            {
                var start = new Point(30, GetTop(NoteHead) + 30);
                var end = new Point(-GetLeft(this) - moveTieMidToLeft, start.Y + tieHeight);

                Tie.Data = Geometry.Parse("F0 M " + start.X + "," + start.Y
                    + " C " + start.X + "," + start.Y + " " + start.X + "," + end.Y + " " + end.X + "," + end.Y // right
                    + " L " + end.X + "," + (end.Y + 10)  // down
                    + " C " + end.X + "," + (end.Y + 10) + " " + start.X + "," + (end.Y + 10) + " " + "" + start.X + "," + start.Y + "Z"); // back
                Children.Add(Tie);

                PreviewMouseDown += (sender, args) =>
                {
                    PreviousUINote.ClickToSelectSymbols(PreviousUINote, args);
                    args.Handled = true;
                };
            }

            if (note.DurationInMeasure < note.Duration)
            {
                var start = new Point(30, GetTop(NoteHead) + 30);
                var end = new Point(Width + 10 - moveTieMidToLeft, start.Y + tieHeight);

                Tie.Data = Geometry.Parse("F0 M " + start.X + "," + start.Y
                    + " C " + start.X + "," + start.Y + " " + start.X + "," + end.Y + " " + end.X + "," + end.Y // right
                    + " L " + end.X + "," + (end.Y + 10)  // down
                    + " C " + end.X + "," + (end.Y + 10) + " " + start.X + "," + (end.Y + 10) + " " + "" + start.X + "," + start.Y + "Z"); // back
                Children.Add(Tie);
            }
        }

        public Note Note { get; set; }

        public double StemLength = 100;
        public StemDirection StemDirection = StemDirection.unknown;

        public Path NoteHead = new Path
        {
            Fill = Brushes.Black,
            SnapsToDevicePixels = Properties.Settings.Default.SnapsToDevicePixels,
            RenderTransform = new ScaleTransform(0.26, 0.26)
        };
        public Path Flag = new Path
        {
            Fill = Brushes.Black,
            SnapsToDevicePixels = Properties.Settings.Default.SnapsToDevicePixels,
            RenderTransform = new ScaleTransform(0.26, 0.26)
        };
        public Line Stem = new Line
        {
            SnapsToDevicePixels = Properties.Settings.Default.SnapsToDevicePixels,
            StrokeThickness = 6,
            Stroke = Brushes.Black
        };
        public Path Tie = new Path
        {
            Fill = Brushes.Black,
            SnapsToDevicePixels = Properties.Settings.Default.SnapsToDevicePixels
        };

        public UINote NextUINote
        {
            get
            {
                var index = ParentMeasure.Notes.IndexOf(this);
                if (ParentMeasure.Notes.Count > index + 1)
                    return ParentMeasure.Notes[index + 1];
                if (ParentMeasure.NextUIMeasure != null && ParentMeasure.NextUIMeasure.Notes != null && ParentMeasure.NextUIMeasure.Notes.Count > 0)
                    return ParentMeasure.NextUIMeasure.Notes.FirstOrDefault();
                return null;
            }
        }

        public UINote PreviousUINote
        {
            get
            {
                var index = ParentMeasure.Notes.IndexOf(this);
                if (index > 0)
                    return ParentMeasure.Notes[index - 1];
                if (ParentMeasure.PreviousUIMeasure != null && ParentMeasure.PreviousUIMeasure.Notes != null && ParentMeasure.PreviousUIMeasure.Notes.Count > 0)
                    return ParentMeasure.PreviousUIMeasure.Notes.Last();
                return null;
            }
        }

        public override string ToString()
        {
            return Note.ToString();
        }

        private void SetDuration(Note note, UIMeasure measure)
        {
            // if the note is longer than there is space left in the measure, split it, create a new note and add it to the TiedNotes-list
            if (note.DurationInMeasure < note.Duration)
            {
                measure.TiedNotes.Add(new Note
                {
                    Beat = 1.0,
                    Duration = (Duration)(note.Duration - note.DurationInMeasure),
                    Octave = note.Octave,
                    Step = note.Step,
                    Voice = note.Voice,
                    Velocity = note.Velocity,
                    ParentMeasure = note.ParentMeasure.Next
                });
            }
            switch (note.DurationInMeasure)
            {
                case Duration.whole:
                    NoteHead.Data = Geometry.Parse(Engraving.WholeHead);
                    NoteHead.RenderTransform = new ScaleTransform(0.3, 0.3);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 4;
                    break;
                case Duration.halfDotted:
                    NoteHead.Data = Geometry.Parse(Engraving.HalfHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 3;
                    DrawDot();
                    break;
                case Duration.wholeTriplet:
                    NoteHead.Data = Geometry.Parse(Engraving.WholeHead);
                    NoteHead.RenderTransform = new ScaleTransform(0.3, 0.3);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 2.66;
                    break;
                case Duration.half:
                    NoteHead.Data = Geometry.Parse(Engraving.HalfHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 2;
                    break;
                case Duration.quarterDotted:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 1.5;
                    DrawDot();
                    break;
                case Duration.halfTriplet:
                    NoteHead.Data = Geometry.Parse(Engraving.HalfHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 1.33;
                    break;
                case Duration.quarter:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 1;
                    break;
                case Duration.eigthDotted:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.75;
                    DrawDot();
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.EigthFlagUp : Engraving.EigthFlagDown);
                    break;
                case Duration.quarterTriplet:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.66;
                    break;
                case Duration.eigth:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.5;
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.EigthFlagUp : Engraving.EigthFlagDown);
                    break;
                case Duration.sixteenthDotted:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.37;
                    DrawDot();
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.SixteenthFlagUp : Engraving.SixteenthFlagDown);
                    break;
                case Duration.eigthTriplet:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.333;
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.EigthFlagUp : Engraving.EigthFlagDown);
                    break;
                case Duration.sixteenth:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.25;
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.SixteenthFlagUp : Engraving.SixteenthFlagDown);
                    break;
                case Duration.sixteenthTriplet:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.166;
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.SixteenthFlagUp : Engraving.SixteenthFlagDown);
                    break;
                case Duration.thirtysecond:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    NoteHead.RenderTransform = new ScaleTransform(0.15, 0.15);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.125;
                    SetLeft(NoteHead, GetLeft(NoteHead) + 16);
                    SetTop(NoteHead, GetTop(NoteHead) + 6);
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.SixteenthFlagUp : Engraving.SixteenthFlagDown);
                    break;
            }
        }

        private bool HandleConnectedNotes_NeedsFlag(Note note, UIMeasure measure)
        {
            // a note qualifies for beaming IF there already are others

            // OR IF it is not alone...
            if (note.Next != null
                // AND is followed by a note (not a rest)
                && note.Next.GetType() == typeof(Note)
                // AND the next note is an eigth/dotted or sixteenth/dotted / thirtysecond
                && (note.Next.Duration == Duration.eigth || note.Next.Duration == Duration.sixteenth
                    || note.Next.Duration == Duration.eigthDotted || note.Next.Duration == Duration.sixteenthDotted
                    || note.Next.Duration == Duration.eigthTriplet || note.Next.Duration == Duration.sixteenthTriplet
                    || note.Next.Duration == Duration.thirtysecond)
                // AND the next beat is not a "heavy" beat
                && note.Next.Beat != 1 && note.Next.Beat != 3)
            {
                // if this is the first note, set stem-direction for the rest of the group
                if (!measure.NotYetConnectedNotes.Any())
                {
                    measure.StemDirectionUp = StemOfGroupShouldGoUp;
                    measure.StemDirectionIsSetForGroup = true;
                }
                measure.NotYetConnectedNotes.Add(this);
                return false;
            }

            if (measure.NotYetConnectedNotes.Any())
            {
                measure.NotYetConnectedNotes.Add(this);
                measure.ConnectNotesAtEndOfRun = true;
                return false;
            }
            return true;
        }

        private double CalculateTop(Note note, UIMeasure measure)
        {
            double top = -TopRelativeToMeasure;
            const int noteStepSpacing = 15;

            switch (measure.InnerMeasure.Clef)
            {
                case Clef.Treble:
                    top -= 16;
                    break;
                case Clef.Bass:
                    top -= 180 + 16;
                    break;
            }

            switch (note.Octave)
            {
                case 8:
                    top -= 21 * noteStepSpacing;
                    break;
                case 7:
                    top -= 14 * noteStepSpacing;
                    break;
                case 6:
                    top -= 7 * noteStepSpacing;
                    break;
                case 5:
                    top -= 0;
                    break;
                case 4:
                    top += 7 * noteStepSpacing + 3;
                    break;
                case 3:
                    top += 14 * noteStepSpacing + 4;
                    break;
                case 2:
                    top += 21 * noteStepSpacing + 7;
                    break;
                case 1:
                    top += 28 * noteStepSpacing + 7;
                    break;
            }

            switch (note.Step)
            {
                case Pitch.C:
                    top += 0;
                    break;
                case Pitch.CSharp:
                    top += 0;
                    break;
                case Pitch.DFlat:
                    top -= noteStepSpacing;
                    break;
                case Pitch.D:
                    top -= noteStepSpacing;
                    break;
                case Pitch.DSharp:
                    top -= noteStepSpacing;
                    break;
                case Pitch.EFlat:
                    top -= 2 * noteStepSpacing;
                    break;
                case Pitch.E:
                    top -= 2 * noteStepSpacing;
                    break;
                case Pitch.ESharp:
                    top -= 2 * noteStepSpacing;
                    break;
                case Pitch.FFlat:
                    top -= 3 * noteStepSpacing;
                    break;
                case Pitch.F:
                    top -= 3 * noteStepSpacing;
                    break;
                case Pitch.FSharp:
                    top -= 3 * noteStepSpacing;
                    break;
                case Pitch.GFlat:
                    top -= 4 * noteStepSpacing;
                    break;
                case Pitch.G:
                    top -= 4 * noteStepSpacing;
                    break;
                case Pitch.GSharp:
                    top -= 4 * noteStepSpacing;
                    break;
                case Pitch.AFlat:
                    top -= 5 * noteStepSpacing;
                    break;
                case Pitch.A:
                    top -= 5 * noteStepSpacing;
                    break;
                case Pitch.ASharp:
                    top -= 5 * noteStepSpacing;
                    break;
                case Pitch.BFlat:
                    top -= 6 * noteStepSpacing;
                    break;
                case Pitch.B:
                    top -= 6 * noteStepSpacing;
                    break;
                case Pitch.BSharp:
                    top -= 6 * noteStepSpacing;
                    break;
            }

            DrawAccidentalIfNeeded(measure, note, top);

            // top line = 50, first upper ledger = 20, bottom line = 170, first lower ledger = 200, note height = 110
            if (top >= 89 - TopRelativeToMeasure)
                DrawLedger(measure, true, (int)((top - 59 + TopRelativeToMeasure) / (2 * noteStepSpacing)));
            else if (top < -87 - TopRelativeToMeasure)
                DrawLedger(measure, false, (int)((Math.Abs(top) - 58 - TopRelativeToMeasure) / (2 * noteStepSpacing)));
            return top;
        }

        public void DrawLedger(UIMeasure measure, bool below, int count)
        {
            const double width = 75;
            const double spacing = 30;
            var top = below ? 170 - TopRelativeToMeasure + spacing : 50 - TopRelativeToMeasure - spacing;

            for (var i = 0; i < count; i++)
            {
                var ledger = new Line
                    {
                        X1 = -5,
                        X2 = width - 5,
                        StrokeThickness = 5,
                        Stroke = Brushes.DimGray,
                        SnapsToDevicePixels = Properties.Settings.Default.SnapsToDevicePixels
                    };
                if (below)
                {
                    ledger.Y1 = top + i * spacing;
                    ledger.Y2 = top + i * spacing;
                }
                else
                {
                    ledger.Y1 = top - i * spacing;
                    ledger.Y2 = top - i * spacing;
                }
                ledger.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                Children.Add(ledger);
            }
        }

        public void DrawAccidentalIfNeeded(UIMeasure measure, Note note, double setTop)
        {
            var currentKey = note.ParentMeasure.ParentMeasureGroup.KeySignature;
            var accidentalKind = Accidental.Natural;
            var naturalPitches = new List<Pitch> { Pitch.C, Pitch.D, Pitch.E, Pitch.F, Pitch.G, Pitch.A, Pitch.B };
            var sharpPitches = new List<Pitch> { Pitch.CSharp, Pitch.DSharp, Pitch.ESharp, Pitch.FSharp, Pitch.GSharp, Pitch.ASharp, Pitch.BSharp };
            var flatPitches = new List<Pitch> { Pitch.CFlat, Pitch.DFlat, Pitch.EFlat, Pitch.F, Pitch.GFlat, Pitch.AFlat, Pitch.BFlat };

            if (!currentKey.NoteIsInKey(note.Step) && !measure.AlteredKeys.Contains(note.Step))
            {
                if (naturalPitches.Contains(note.Step))
                    accidentalKind = Accidental.Natural;
                else if (sharpPitches.Contains(note.Step))
                    accidentalKind = Accidental.Sharp;
                else if (flatPitches.Contains(note.Step))
                    accidentalKind = Accidental.Flat;

                measure.AlteredKeys.Add(note.Step);

                DrawAccidental(measure, accidentalKind, setTop);
            }
        }

        public void DrawAccidental(UIMeasure measure, Accidental accidentalKind, double setTop)
        {
            var top = setTop + 56 - TopRelativeToMeasure;
            var left = -25;

            var newAccidental = new Path
            {
                RenderTransform = new ScaleTransform(1.6, 1.6),
                Fill = Brushes.Black,
            };

            switch (accidentalKind)
            {
                case Accidental.Sharp:
                    newAccidental.Data = Geometry.Parse(Engraving.Sharp);
                    break;
                case Accidental.Flat:
                    newAccidental.Data = Geometry.Parse(Engraving.Flat);
                    break;
                case Accidental.Natural:
                    newAccidental.Data = Geometry.Parse(Engraving.Natural);
                    break;
                case Accidental.DoubleSharp:
                    newAccidental.Data = Geometry.Parse(Engraving.DoubleSharp);
                    left -= 15;
                    break;
                case Accidental.DoubleFlat:
                    newAccidental.Data = Geometry.Parse(Engraving.DoubleFlat);
                    left -= 15;
                    break;
            }

            SetTop(newAccidental, top);
            SetLeft(newAccidental, left);
            Children.Add(newAccidental);
        }

        public void DrawDot()
        {
            double top;
            if (Math.Abs((GetTop(NoteHead) - 21) % 31) < 5)
                top = GetTop(NoteHead); // on the line
            else
                top = GetTop(NoteHead) + 5; // between lines

            var newDot = new Ellipse
            {
                Fill = Brushes.Black,
                Width = 18,
                Height = 18
            };

            SetTop(newDot, top);
            SetLeft(newDot, 60);
            Children.Add(newDot);
        }

        public bool StemOfGroupShouldGoUp
        {
            get
            {
                var duration = Note.Duration;
                var ups = 0;
                var downs = 0;
                var currentNote = Note;
                var numberOfNotesToInspect = ((Note.Duration == Duration.eigth && (Note.Beat == 1 || Note.Beat == 3)) || (Note.Duration == Duration.sixteenth))
                    ? 4
                    : 2;
                while (currentNote.Duration == duration && currentNote.GetType() == typeof(Note) && numberOfNotesToInspect > 0)
                {
                    if (currentNote.StemShouldGoUp())
                        ups++;
                    else
                        downs++;
                    if (currentNote.Next != null && currentNote.Next.GetType() == typeof(Note))
                        currentNote = (Note)currentNote.Next;
                    else
                        break;
                    numberOfNotesToInspect--;
                }
                return ups >= downs;
            }
        }
    }
}