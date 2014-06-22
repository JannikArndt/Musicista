using Model;
using Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UINote : UISymbol
    {
        public UINote(Note note, UIMeasure parentMeasure)
        {
            ParentMeasure = parentMeasure;
            Note = note;
            ParentMeasure.Symbols.Add(this);

            BeatsPerMeasure = parentMeasure.InnerMeasure.ParentMeasureGroup.TimeSignature.Beats;
            parentMeasure.ConnectNotesAtEndOfRun = false;

            Left = ((parentMeasure.Width - parentMeasure.Indent) / BeatsPerMeasure * (note.Beat - 1)) + parentMeasure.Indent;
            Top = SetTop(note, parentMeasure);
            SetDuration(note, parentMeasure);

            parentMeasure.Children.Add(Path);

            if (parentMeasure.ConnectNotesAtEndOfRun || parentMeasure.NotYetConnectedNotes.Count == 4
                || (parentMeasure.NotYetConnectedNotes.Any() && note.Next != null && (note.Next.Beat == 3 || note.Next.Beat == 1))
                ||
                (parentMeasure.NotYetConnectedNotes.Any(item => item.Note.Duration == Duration.sixteenth) && note.Next != null &&
                 (note.Next.Beat == 2 || note.Next.Beat == 4)))
                parentMeasure.ConnectNotes();
        }

        public Note Note { get; set; }

        public UINote NextUINote
        {
            get
            {
                var index = ParentMeasure.Notes.IndexOf(this);
                if (ParentMeasure.Notes.Count > index + 1)
                    return ParentMeasure.Notes[index + 1];
                return null;
            }
        }

        private void SetDuration(Note note, UIMeasure measure)
        {
            switch (note.Duration)
            {
                case Duration.wholeDotted:
                    Path.Data = Geometry.Parse(Engraving.Whole);
                    DrawDot(measure);
                    break;
                case Duration.whole:
                    Path.Data = Geometry.Parse(Engraving.Whole);
                    break;
                case Duration.halfDotted:
                    Path.Data = Geometry.Parse(note.StemShouldGoUp() ? Engraving.Half : Engraving.HalfUpsideDown);
                    DrawDot(measure);
                    break;
                case Duration.half:
                    Path.Data = Geometry.Parse(note.StemShouldGoUp() ? Engraving.Half : Engraving.HalfUpsideDown);
                    break;
                case Duration.quarterDotted:
                    Path.Data = Geometry.Parse(note.StemShouldGoUp() ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                    DrawDot(measure);
                    break;
                case Duration.quarter:
                    Path.Data = Geometry.Parse(note.StemShouldGoUp() ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                    break;
                case Duration.eigthDotted:
                    Path.Data = Geometry.Parse(note.StemShouldGoUp() ? Engraving.Eigth : Engraving.EightUpsideDown);
                    DrawDot(measure);
                    HandleConnectedNotes(note, measure);
                    break;
                case Duration.eigth:
                    Path.Data = Geometry.Parse(note.StemShouldGoUp() ? Engraving.Eigth : Engraving.EightUpsideDown);
                    HandleConnectedNotes(note, measure);
                    break;
                case Duration.sixteenthDotted:
                    Path.Data = Geometry.Parse(Engraving.Sixteenth);
                    DrawDot(measure);
                    HandleConnectedNotes(note, measure);
                    break;
                case Duration.sixteenth:
                    Path.Data = Geometry.Parse(Engraving.Sixteenth);
                    HandleConnectedNotes(note, measure);
                    break;
            }
        }

        private void HandleConnectedNotes(Note note, UIMeasure measure)
        {
            if (note.Next != null
                && (note.Next.Duration == Duration.eigth || note.Next.Duration == Duration.sixteenth
                    || note.Next.Duration == Duration.eigthDotted || note.Next.Duration == Duration.sixteenthDotted)
                && note.Next.Beat != 1 && note.Next.Beat != 3)
            {
                if (!measure.NotYetConnectedNotes.Any())
                    measure.StemDirectionUp = StemOfGroupShouldGoUp(note);
                Path.Data = Geometry.Parse(measure.StemDirectionUp ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                measure.NotYetConnectedNotes.Add(this);
            }
            else if (measure.NotYetConnectedNotes.Any())
            {
                Path.Data = Geometry.Parse(measure.StemDirectionUp ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                measure.NotYetConnectedNotes.Add(this);
                measure.ConnectNotesAtEndOfRun = true;
            }
        }

        private double SetTop(Note note, UIMeasure measure)
        {
            double top = 0;
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
            if (top >= 89)
                DrawLedger(measure, true, (int)((top - 59) / (2 * noteStepSpacing)));
            else if (top < -87)
                DrawLedger(measure, false, (int)((Math.Abs(top) - 58) / (2 * noteStepSpacing)));
            return top;
        }

        public void DrawLedger(UIMeasure measure, bool below, int count)
        {
            const double width = 75;
            const double spacing = 30;
            var top = below ? 170 + spacing : 50 - spacing;

            if (below)
            {
                for (var i = 0; i < count; i++)
                {
                    var ledger = new Line
                    {
                        X1 = Left - 15,
                        Y1 = top + i * spacing,
                        X2 = Left + width - 15,
                        Y2 = top + i * spacing,
                        StrokeThickness = 5,
                        Stroke = Brushes.DimGray,
                        SnapsToDevicePixels = true
                    };
                    ledger.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                    measure.Children.Add(ledger);
                }
            }
            else
            {
                for (var i = 0; i < count; i++)
                {
                    var ledger = new Line
                    {
                        X1 = Left - 15,
                        Y1 = top - i * spacing,
                        X2 = Left + width - 15,
                        Y2 = top - i * spacing,
                        StrokeThickness = 5,
                        Stroke = Brushes.DimGray,
                        SnapsToDevicePixels = true
                    };
                    ledger.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                    measure.Children.Add(ledger);
                }
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
            var top = setTop + 68;
            var left = Left - 35;

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

            Canvas.SetTop(newAccidental, top);
            Canvas.SetLeft(newAccidental, left);
            measure.Children.Add(newAccidental);
        }

        public void DrawDot(UIMeasure measure)
        {
            double top;
            if (Math.Abs(Top % 30) < 5)
                top = Top + 88;
            else
                top = Top + 103;

            var left = Left + 50;

            var newDot = new Ellipse
            {
                Fill = Brushes.Black,
                Width = 18,
                Height = 18
            };

            Canvas.SetTop(newDot, top);
            Canvas.SetLeft(newDot, left);
            measure.Children.Add(newDot);
        }

        public bool StemOfGroupShouldGoUp(Note note)
        {
            var duration = note.Duration;
            var ups = 0;
            var downs = 0;
            var currentNote = note;
            var numberOfNotesToInspect = ((note.Duration == Duration.eigth && (note.Beat == 1 || note.Beat == 3)) || (note.Duration == Duration.sixteenth)) ? 4 : 2;
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