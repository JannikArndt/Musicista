using Model;
using Model.Meta;
using Musicista.Properties;
using Musicista.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Duration = Model.Meta.Duration;

namespace Musicista.UI.MeasureElements
{
    public class UINote : UISymbol
    {
        public Path Flag = new Path
        {
            Fill = Brushes.Black,
            SnapsToDevicePixels = Settings.Default.SnapsToDevicePixels,
            RenderTransform = new ScaleTransform(0.26, 0.26)
        };

        public Path NoteHead = new Path
        {
            Fill = Brushes.Black,
            SnapsToDevicePixels = Settings.Default.SnapsToDevicePixels,
            RenderTransform = new ScaleTransform(0.26, 0.26)
        };

        public Line Stem = new Line
        {
            SnapsToDevicePixels = Settings.Default.SnapsToDevicePixels,
            StrokeThickness = 6,
            Stroke = Brushes.Black
        };

        public StemDirection StemDirection = StemDirection.Unknown;
        public double StemLength = 100;

        public Path TieFromNote = new Path
        {
            Fill = Brushes.Black,
            SnapsToDevicePixels = Settings.Default.SnapsToDevicePixels
        };

        public Path TieToNote = new Path
        {
            Fill = Brushes.Black,
            SnapsToDevicePixels = Settings.Default.SnapsToDevicePixels
        };

        public UINote(Note note, UIMeasure parentMeasure, bool hasMouseDown = true, bool tiedTo = false)
            : base(note, parentMeasure, hasMouseDown)
        {
            Note = note;

            BeatsPerMeasure = (4.0 / ParentMeasure.InnerMeasure.ParentMeasureGroup.TimeSignature.BeatUnit) *
                              ParentMeasure.InnerMeasure.ParentMeasureGroup.TimeSignature.Beats;
            ParentMeasure.ConnectNotesAtEndOfRun = false;

            CanvasLeft = ((ParentMeasure.Width - ParentMeasure.Indent - ParentMeasure.MarginRight) / BeatsPerMeasure * (note.Beat - 1)) + ParentMeasure.Indent;

            // Note Head
            SetTop(NoteHead, CalculateTop(note, ParentMeasure) + 94);
            SetLeft(NoteHead, 10);
            SetDuration(note, ParentMeasure);

            // Stem & Flag
            if ((ParentMeasure.StemDirectionIsSetForGroup && ParentMeasure.StemDirectionUp) ||
                (!ParentMeasure.StemDirectionIsSetForGroup && note.StemShouldGoUp()))
            {
                // stem goes up
                StemDirection = StemDirection.Up;
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
                StemDirection = StemDirection.Down;
                Stem.X1 = 14;
                Stem.X2 = Stem.X1;
                Stem.Y1 = GetTop(NoteHead) + 20;
                Stem.Y2 = Stem.Y1 + StemLength;

                SetTop(Flag, GetTop(NoteHead) + 30);
                SetLeft(Flag, 14);
            }

            HandleOverlappingNotes();

            HandleNotesInChord();

            HandleBeams();

            HandleTriplets();

            HandleTies(tiedTo);
        }

        public Note Note { get; set; }

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

        public bool StemOfGroupShouldGoUp
        {
            get
            {
                var duration = Note.Duration;
                var ups = 0;
                var downs = 0;
                var currentNote = Note;
                var numberOfNotesToInspect = ((Note.Duration == Duration.Eigth && (Note.Beat == 1 || Note.Beat == 3)) || (Note.Duration == Duration.Sixteenth))
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

        private void HandleOverlappingNotes()
        {
            foreach (
                var overlappingNote in
                    ParentMeasure.InnerMeasure.GetSymbolsAt(Note.Beat).OfType<Note>().Where(item => item.Octave == Note.Octave && item.Step == Note.Step))
                if (overlappingNote.Duration >= Duration.HalfTriplet || Note.Duration >= Duration.HalfTriplet)
                    if (overlappingNote.Voice < Note.Voice)
                    {
                        SetLeft(NoteHead, 50);
                        Stem.X1 = Stem.X2 += 40;
                    }
            Children.Add(NoteHead);
            if (Note.DurationInMeasure < Duration.Whole && Note.DurationInMeasure != Duration.WholeTriplet)
                Children.Add(Stem);
            else
                StemDirection = StemDirection.None;
            Children.Add(Flag);
            ParentMeasure.Children.Add(this);
        }

        private void HandleBeams()
        {
            // Check if all notes, that are on that beat, are already drawn
            if (Note.ParentMeasure.Symbols.OfType<Note>().Count(item => Math.Abs(item.Beat - Note.Beat) < 0.01 && item.Voice == Note.Voice)
                > ParentMeasure.Symbols.OfType<UINote>().Count(item => Math.Abs(item.Symbol.Beat - Note.Beat) < 0.01 && item.Symbol.Voice == Note.Voice))
                return;

            if (
                ParentMeasure.ConnectNotesAtEndOfRun
                || ParentMeasure.NotYetConnectedNotes.Count == 4
                || (ParentMeasure.NotYetConnectedNotes.Any() && Note.Next != null && (Note.Next.Beat == 3 || Note.Next.Beat == 1))
                ||
                (ParentMeasure.NotYetConnectedNotes.Any(item => item.Note.Duration == Duration.Sixteenth) && Note.Next != null &&
                 (Note.Next.Beat == 2 || Note.Next.Beat == 4))
                ||
                ParentMeasure.NotYetConnectedNotes.Count == 3 &&
                (ParentMeasure.NotYetConnectedNotes.All(item => item.Symbol.Duration == Duration.SixteenthTriplet)
                 || ParentMeasure.NotYetConnectedNotes.All(item => item.Symbol.Duration == Duration.EigthTriplet)))
            {
                ParentMeasure.BalanceStems();
                ParentMeasure.ConnectNotes();
            }
        }

        private void HandleTriplets()
        {
            if (Note.IsTriplet && !ParentMeasure.Tuplets.Select(item => item.Symbol.Beat).Contains(Note.Beat))
                ParentMeasure.Tuplets.Add(this);
            if (ParentMeasure.Tuplets.Count > 2 || (ParentMeasure.Tuplets.Any() && !Note.IsTriplet))
                ParentMeasure.ConnectTuplets();
        }

        private void HandleTies(bool tiedTo)
        {
            const int moveTieMidToLeft = 120;
            const int tieHeight = 40;

            if (tiedTo)
            {
                var start = new Point(30, GetTop(NoteHead) + 30);
                var end = new Point(-GetLeft(this) - moveTieMidToLeft, start.Y + tieHeight);

                TieToNote.Data = Geometry.Parse("F0 M " + start.X + "," + start.Y
                                                + " C " + start.X + "," + start.Y + " " + start.X + "," + end.Y + " " + end.X + "," + end.Y // right
                                                + " L " + end.X + "," + (end.Y + 10) // down
                                                + " C " + end.X + "," + (end.Y + 10) + " " + start.X + "," + (end.Y + 10) + " " + "" + start.X + "," + start.Y +
                                                "Z");
                // back
                Children.Add(TieToNote);

                PreviewMouseDown += (sender, args) =>
                {
                    PreviousUINote.ClickToSelectSymbols(PreviousUINote, args);
                    args.Handled = true;
                };
            }

            if (Note.DurationInMeasure < Note.Duration)
            {
                var start = new Point(30, GetTop(NoteHead) + 30);
                var end = new Point(Width + 10 - moveTieMidToLeft, start.Y + tieHeight);

                TieFromNote.Data = Geometry.Parse("F0 M " + start.X + "," + start.Y
                                                  + " C " + start.X + "," + start.Y + " " + start.X + "," + end.Y + " " + end.X + "," + end.Y // right
                                                  + " L " + end.X + "," + (end.Y + 10) // down
                                                  + " C " + end.X + "," + (end.Y + 10) + " " + start.X + "," + (end.Y + 10) + " " + "" + start.X + "," + start.Y +
                                                  "Z");
                // back
                Children.Add(TieFromNote);
            }
        }

        private void HandleNotesInChord()
        {
            var otherNotes =
                ParentMeasure.Symbols.OfType<UINote>().Where(item => Math.Abs(item.Symbol.Beat - Note.Beat) < 0.01 && item.Symbol.Voice == Note.Voice).ToList();
            foreach (var otherNote in otherNotes)
            {
                if (Equals(otherNote, this))
                    continue;

                var verticalDistance = Math.Abs(GetTop(otherNote.NoteHead) - GetTop(NoteHead));

                // Notes are in the same space AND the other note wasn't already moved
                if (verticalDistance < 10 && Math.Abs(GetLeft(otherNote.NoteHead) - 10) < 1)
                {
                    if (Note.Duration >= Duration.Whole || Note.Duration == Duration.WholeTriplet)
                        SetLeft(NoteHead, 64);
                    else
                    {
                        SetLeft(NoteHead, 50);
                        if (otherNote.StemDirection == StemDirection.Down)
                            otherNote.Stem.X1 = otherNote.Stem.X2 = otherNote.Stem.X1 + 40;
                        Children.Remove(Stem);
                    }
                }
                // Notes are only one space apart AND the other note wasn't already moved
                else if (verticalDistance < 16 && Math.Abs(GetLeft(otherNote.NoteHead) - 10) < 1)
                {
                    if (Note.Duration >= Duration.Whole || Note.Duration == Duration.WholeTriplet)
                        SetLeft(NoteHead, 56);
                    else
                    {
                        SetLeft(NoteHead, 50);
                        if (otherNote.StemDirection == StemDirection.Down)
                            otherNote.Stem.X1 = otherNote.Stem.X2 = otherNote.Stem.X1 + 40;
                        Children.Remove(Stem);
                    }
                    // TODO: more than two notes with a stem down need to be rebalanced, so that the bottommost note is on the RIGHT side of the stem (Gould p.49)
                }
                // Notes are more than a space apart
                else
                {
                    if (otherNote.StemDirection == StemDirection.Up)
                        otherNote.Stem.Y2 = StemDirection == StemDirection.Up ? Stem.Y2 : Stem.Y1 - StemLength;
                    else
                        otherNote.Stem.Y1 = StemDirection == StemDirection.Down ? Stem.Y1 : Stem.Y2 + StemLength;
                    if (Children.Contains(Stem))
                        Children.Remove(Stem);
                }
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
                case Duration.Whole:
                    NoteHead.Data = Geometry.Parse(Engraving.WholeHead);
                    NoteHead.RenderTransform = new ScaleTransform(0.3, 0.3);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 4;
                    break;
                case Duration.HalfDotted:
                    NoteHead.Data = Geometry.Parse(Engraving.HalfHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 3;
                    DrawDot();
                    break;
                case Duration.WholeTriplet:
                    NoteHead.Data = Geometry.Parse(Engraving.WholeHead);
                    NoteHead.RenderTransform = new ScaleTransform(0.3, 0.3);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 2.66;
                    break;
                case Duration.Half:
                    NoteHead.Data = Geometry.Parse(Engraving.HalfHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 2;
                    break;
                case Duration.QuarterDotted:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 1.5;
                    DrawDot();
                    break;
                case Duration.HalfTriplet:
                    NoteHead.Data = Geometry.Parse(Engraving.HalfHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 1.33;
                    break;
                case Duration.Quarter:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 1;
                    break;
                case Duration.EigthDotted:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.75;
                    DrawDot();
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.EigthFlagUp : Engraving.EigthFlagDown);
                    break;
                case Duration.QuarterTriplet:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.66;
                    break;
                case Duration.Eigth:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.5;
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.EigthFlagUp : Engraving.EigthFlagDown);
                    break;
                case Duration.SixteenthDotted:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.37;
                    DrawDot();
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.SixteenthFlagUp : Engraving.SixteenthFlagDown);
                    break;
                case Duration.EigthTriplet:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.333;
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.EigthFlagUp : Engraving.EigthFlagDown);
                    break;
                case Duration.Sixteenth:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.25;
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.SixteenthFlagUp : Engraving.SixteenthFlagDown);
                    break;
                case Duration.SixteenthTriplet:
                    NoteHead.Data = Geometry.Parse(Engraving.QuarterHead);
                    Width = (ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * 0.166;
                    if (HandleConnectedNotes_NeedsFlag(note, measure))
                        Flag.Data = Geometry.Parse(Note.StemShouldGoUp() ? Engraving.SixteenthFlagUp : Engraving.SixteenthFlagDown);
                    break;
                case Duration.Thirtysecond:
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
            // ignore notes in chord, except fo the first one, which actually still has a stem
            if (ParentMeasure.Symbols.OfType<UINote>().Count(item => Math.Abs(item.Symbol.Beat - Note.Beat) < 0.01 && item.Symbol.Voice == note.Voice) > 1)
                return false;
            // a note qualifies for beaming IF there already are others

            // OR IF it is not alone...
            if (note.Next != null
                // AND is followed by a note (not a rest)
                && note.Next.GetType() == typeof(Note)
                // AND the next note is an eigth/dotted or sixteenth/dotted / thirtysecond
                && (note.Next.Duration == Duration.Eigth || note.Next.Duration == Duration.Sixteenth
                    || note.Next.Duration == Duration.EigthDotted || note.Next.Duration == Duration.SixteenthDotted
                    || note.Next.Duration == Duration.EigthTriplet || note.Next.Duration == Duration.SixteenthTriplet
                    || note.Next.Duration == Duration.Thirtysecond)
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
                    SnapsToDevicePixels = Settings.Default.SnapsToDevicePixels
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
    }
}