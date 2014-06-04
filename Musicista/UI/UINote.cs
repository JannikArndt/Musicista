using Model;
using Model.Meta;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Duration = Model.Duration;

namespace Musicista.UI
{
    public class UINote
    {
        public Note Note { get; set; }
        public UIMeasure ParentMeasure { get; set; }
        public double Top { get; set; }
        public double Left { get; set; }
        public UINote(Note note, UIMeasure parentMeasure)
        {
            const int beatsPerMeasure = 4; // TODO measure.InnerMeasure.ParentMeasureGroup.TimeSignature.Beats
            parentMeasure.ConnectEigthsAtEndOfRun = false;
            parentMeasure.ConnectSixteenthsAtEndOfRun = false;

            Note = note;
            ParentMeasure = parentMeasure;
            Top = 0;
            Left = ((parentMeasure.Width - parentMeasure.Indent) / beatsPerMeasure * (note.Beat - 1)) + parentMeasure.Indent;

            var newNote = new Path
            {
                Fill = Brushes.Black,
                SnapsToDevicePixels = true
            };
            newNote.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Unspecified);
            newNote.SetValue(RenderOptions.ClearTypeHintProperty, ClearTypeHint.Enabled);
            newNote.SetValue(RenderOptions.CachingHintProperty, CachingHint.Cache);

            Top = SetTop(note, parentMeasure);
            SetDuration(note, parentMeasure, newNote);

            Canvas.SetTop(newNote, Top);
            Canvas.SetLeft(newNote, Left);
            parentMeasure.Children.Add(newNote);

            if (parentMeasure.ConnectEigthsAtEndOfRun || parentMeasure.NotYetConnectedEigths.Count == 4 || (parentMeasure.NotYetConnectedEigths.Any() && note.Next != null && (note.Next.Beat == 3 || note.Next.Beat == 1)))
                parentMeasure.ConnectEigths();
            if (parentMeasure.ConnectSixteenthsAtEndOfRun || parentMeasure.NotYetConnectedSixteenths.Count == 4 || (parentMeasure.NotYetConnectedSixteenths.Any() && note.Next != null && (note.Next.Beat == 3 || note.Next.Beat == 1)))
                parentMeasure.ConnectSixteenths();
        }

        private void SetDuration(Note note, UIMeasure measure, Path newNote)
        {
            switch (note.Duration)
            {
                case Duration.wholeDotted:
                    newNote.Data = Geometry.Parse(Engraving.Whole);
                    DrawDot(measure);
                    break;
                case Duration.whole:
                    newNote.Data = Geometry.Parse(Engraving.Whole);
                    break;
                case Duration.halfDotted:
                    newNote.Data = Geometry.Parse(Top >= -1 ? Engraving.Half : Engraving.HalfUpsideDown);
                    DrawDot(measure);
                    break;
                case Duration.half:
                    newNote.Data = Geometry.Parse(Top >= -1 ? Engraving.Half : Engraving.HalfUpsideDown);
                    break;
                case Duration.quarterDotted:
                    newNote.Data = Geometry.Parse(Top >= -1 ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                    DrawDot(measure);
                    break;
                case Duration.quarter:
                    newNote.Data = Geometry.Parse(Top >= -1 ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                    break;
                case Duration.eigthDotted:
                    newNote.Data = Geometry.Parse(Top >= -1 ? Engraving.Eigth : Engraving.EightUpsideDown);
                    DrawDot(measure);
                    break;
                case Duration.eigth:
                    newNote.Data = Geometry.Parse(Top >= -1 ? Engraving.Eigth : Engraving.EightUpsideDown);
                    if (note.Next != null && note.Next.Duration == Duration.eigth && note.Next.Beat != 1 && note.Next.Beat != 3)
                    {
                        if (!measure.NotYetConnectedEigths.Any())
                            measure.StemDirectionUp = Top >= -1;
                        newNote.Data = Geometry.Parse(measure.StemDirectionUp ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                        measure.NotYetConnectedEigths.Add(newNote);
                    }
                    else if (measure.NotYetConnectedEigths.Any())
                    {
                        newNote.Data = Geometry.Parse(measure.StemDirectionUp ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                        measure.NotYetConnectedEigths.Add(newNote);
                        measure.ConnectEigthsAtEndOfRun = true;
                    }
                    break;
                case Duration.sixteenthDotted:
                    newNote.Data = Geometry.Parse(Engraving.Sixteenth);
                    DrawDot(measure);
                    break;
                case Duration.sixteenth:
                    newNote.Data = Geometry.Parse(Engraving.Sixteenth);
                    if (note.Next != null && note.Next.Duration == Duration.sixteenth && note.Next.Beat != 1 && note.Next.Beat != 3)
                    {
                        if (!measure.NotYetConnectedSixteenths.Any())
                            measure.StemDirectionUp = Top >= -1;
                        newNote.Data = Geometry.Parse(measure.StemDirectionUp ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                        measure.NotYetConnectedSixteenths.Add(newNote);
                    }
                    else if (measure.NotYetConnectedSixteenths.Any())
                    {
                        newNote.Data = Geometry.Parse(measure.StemDirectionUp ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                        measure.NotYetConnectedSixteenths.Add(newNote);
                        measure.ConnectSixteenthsAtEndOfRun = true;
                    }
                    break;
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
            }

            switch (note.Step)
            {
                case Pitch.C:
                    top += 0;
                    break;
                case Pitch.CSharp:
                    top += 0;
                    DrawAccidental(measure, Accidental.Sharp, top);
                    break;
                case Pitch.DFlat:
                    top -= noteStepSpacing;
                    DrawAccidental(measure, Accidental.Flat, top);
                    break;
                case Pitch.D:
                    top -= noteStepSpacing;
                    break;
                case Pitch.DSharp:
                    top -= noteStepSpacing;
                    DrawAccidental(measure, Accidental.Sharp, top);
                    break;
                case Pitch.EFlat:
                    top -= 2 * noteStepSpacing;
                    DrawAccidental(measure, Accidental.Flat, top);
                    break;
                case Pitch.E:
                    top -= 2 * noteStepSpacing;
                    break;
                case Pitch.ESharp:
                    top -= 2 * noteStepSpacing;
                    DrawAccidental(measure, Accidental.Sharp, top);
                    break;
                case Pitch.FFlat:
                    top -= 3 * noteStepSpacing;
                    DrawAccidental(measure, Accidental.Flat, top);
                    break;
                case Pitch.F:
                    top -= 3 * noteStepSpacing;
                    break;
                case Pitch.FSharp:
                    top -= 3 * noteStepSpacing;
                    DrawAccidental(measure, Accidental.Sharp, top);
                    break;
                case Pitch.GFlat:
                    top -= 4 * noteStepSpacing;
                    DrawAccidental(measure, Accidental.Flat, top);
                    break;
                case Pitch.G:
                    top -= 4 * noteStepSpacing;
                    break;
                case Pitch.GSharp:
                    top -= 4 * noteStepSpacing;
                    DrawAccidental(measure, Accidental.Sharp, top);
                    break;
                case Pitch.AFlat:
                    top -= 5 * noteStepSpacing;
                    DrawAccidental(measure, Accidental.Flat, top);
                    break;
                case Pitch.A:
                    top -= 5 * noteStepSpacing;
                    break;
                case Pitch.ASharp:
                    top -= 5 * noteStepSpacing;
                    DrawAccidental(measure, Accidental.Sharp, top);
                    break;
                case Pitch.BFlat:
                    top -= 6 * noteStepSpacing;
                    DrawAccidental(measure, Accidental.Flat, top);
                    break;
                case Pitch.B:
                    top -= 6 * noteStepSpacing;
                    break;
                case Pitch.BSharp:
                    top -= 6 * noteStepSpacing;
                    DrawAccidental(measure, Accidental.Sharp, top);
                    break;
            }

            // top line = 50, first upper ledger = 20, bottom line = 170, first lower ledger = 200, note height = 110
            if (top >= 89)
                DrawLedger(measure, true, (int)((top - 59) / (2 * noteStepSpacing)));
            else if (top < -89)
                DrawLedger(measure, false, (int)((Math.Abs(top) - 60) / (2 * noteStepSpacing)));

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

        public void DrawAccidental(UIMeasure measure, Accidental accidentalKind, double setTop)
        {
            var top = setTop + 80;
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
    }
}
