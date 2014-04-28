using Model;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public static class UIHelper
    {
        public static UIPage CreatePage(Canvas canvas)
        {
            var Page = new UIPage(10, 30, 800, 1000);
            canvas.Children.Add(Page.Page);
            return Page;
        }
        public static UITitle CreateTitle(string text, Canvas canvas, UIPage page)
        {
            var Title = new UITitle(text, 60, 0);

            // center title
            Title.Left = (int)((page.Width / 2) - (Title.Width / 2) + page.Left);

            canvas.Children.Add(Title.TitleTextBlock);
            return Title;
        }

        public static Size MeasureString(string candidate)
        {
            TextBlock tb = new TextBlock();
            var formattedText = new FormattedText(
                candidate,
                CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight,
                new Typeface(tb.FontFamily, tb.FontStyle, tb.FontWeight, tb.FontStretch),
                tb.FontSize,
                Brushes.Black);

            return new Size(formattedText.Width, formattedText.Height);
        }

        public static UIStaff DrawStaff(Canvas canvas, UIPage page, int top)
        {
            int Left = page.Left + 50;
            int Width = page.Width - 2 * 50;
            var Staff = new UIStaff(top, Left, Width);

            canvas.Children.Add(Staff.line1);
            canvas.Children.Add(Staff.line2);
            canvas.Children.Add(Staff.line3);
            canvas.Children.Add(Staff.line4);
            canvas.Children.Add(Staff.line5);

            return Staff;
        }

        public static UIMeasure DrawMeasure(Canvas canvas, UIStaff staff, Measure measure = null)
        {
            int Indent = 40;


            int top = staff.Top - 10;
            int left;
            if (staff.Measures.Count > 0)
                left = staff.Measures.Last().Left + staff.Measures.Last().Width;
            else
                left = staff.Left + Indent;


            // 1. noten pro schlag (z.B. 4 auf 1, 4 auf 2, 1 auf 3, 1 Pause auf 4)
            // 2. Maximum finden (z.B. 4 pro Schlag)
            // 3. Maximum x Schläge = spezifische Breite
            // 4. Für alle Takte berechnen und aufaddieren
            // 6. Absolute Breite = Spezifische Breite / Aufsummierte Breite * Zielbreite

            int width = 150;
            var Measure = new UIMeasure(canvas, top, left, width);
            staff.Measures.Add(Measure);

            int CurrentEnd = staff.Left + Indent;
            foreach (var UIMeasure in staff.Measures)
            {
                UIMeasure.Width = (int)((staff.Width - Indent) / staff.Measures.Count);
                UIMeasure.Left = CurrentEnd;
                CurrentEnd += UIMeasure.Width;
            }

            /*
            // Correct width 
            if (measure != null && measure.TimeSignature != null && measure.Parts != null && measure.Parts[0].ListOfSymbols.Count > 0)
            {
                Model.Duration ShortestNote = Model.Duration.whole;
                foreach (var Part in measure.Parts)
                    foreach (var Symbol in Part.ListOfSymbols)
                        if (Symbol.Duration.CompareTo(ShortestNote) < 0)
                            ShortestNote = Symbol.Duration;

                var SpecificWidth = (1024 - (int)ShortestNote) / 10 * measure.TimeSignature.Beats;

                var TotalWidth = 0;
                foreach (var MyMeasure in staff.Measures)
                    TotalWidth += MyMeasure.Width;

                Measure.Width = (int)((SpecificWidth / TotalWidth) * (staff.Width - Indent));
            }
            */
            return Measure;
        }

        public static void DrawTrebleClef(Canvas canvas, UIStaff staff)
        {
            int Top = staff.Top - 10;
            int Left = staff.Left + 10;

            Path clef = new Path
            {
                RenderTransform = new ScaleTransform(.5, .5),
                Fill = Brushes.Black,
                Data = Geometry.Parse(Engraving.TrebleClef)
            };

            Canvas.SetTop(clef, Top);
            Canvas.SetLeft(clef, Left);
            canvas.Children.Add(clef);
        }

        public static void DrawNote(Canvas canvas, Note note, UIMeasure measure)
        {
            Path Note = new Path
            {
                RenderTransform = new ScaleTransform(.21, .21),
                Fill = Brushes.Black,
                SnapsToDevicePixels = true
            };

            Note.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Unspecified);
            Note.SetValue(RenderOptions.ClearTypeHintProperty, ClearTypeHint.Enabled);
            Note.SetValue(RenderOptions.CachingHintProperty, CachingHint.Cache);

            double left = measure.Left + ((measure.Width - 10) / 4 * (note.Beat - 1)) + 10;
            double top = 0;

            switch (note.Octave)
            {
                case 6:
                    top = -43;
                    break;
                case 5:
                    top = -21.5;
                    break;
                case 4:
                    top = 0;
                    break;
                case 3:
                    top = 21.5;
                    break;
                case 2:
                    top = 43;
                    break;
            }

            switch (note.Step)
            {
                case Model.Meta.Pitch.C:
                    top += 18;
                    break;
                case Model.Meta.Pitch.CSharp:
                    top += 18;
                    DrawAccidental(canvas, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.DFlat:
                    top += 14;
                    DrawAccidental(canvas, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.D:
                    top += 14;
                    break;
                case Model.Meta.Pitch.DSharp:
                    top += 14;
                    DrawAccidental(canvas, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.EFlat:
                    top += 11;
                    DrawAccidental(canvas, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.E:
                    top += 11;
                    break;
                case Model.Meta.Pitch.ESharp:
                    top += 11;
                    DrawAccidental(canvas, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.FFlat:
                    top += 8;
                    DrawAccidental(canvas, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.F:
                    top += 8;
                    break;
                case Model.Meta.Pitch.FSharp:
                    top += 8;
                    DrawAccidental(canvas, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.GFlat:
                    top += 5;
                    DrawAccidental(canvas, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.G:
                    top += 5;
                    break;
                case Model.Meta.Pitch.GSharp:
                    top += 5;
                    DrawAccidental(canvas, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.AFlat:
                    top += 2;
                    DrawAccidental(canvas, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.A:
                    top += 2;
                    break;
                case Model.Meta.Pitch.ASharp:
                    top += 2;
                    DrawAccidental(canvas, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.BFlat:
                    top += -1;
                    DrawAccidental(canvas, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.B:
                    top += -1;
                    break;
                case Model.Meta.Pitch.BSharp:
                    top += -1;
                    DrawAccidental(canvas, measure, Accidental.Sharp, top, left);
                    break;
            }

            if (top >= 17)
                DrawLedger(canvas, measure, true, (int)((top - 10) / 6), left);
            else if (top < -17)
                DrawLedger(canvas, measure, false, (int)((Math.Abs(top) - 16) / 6), left);

            switch (note.Duration)
            {
                case Model.Duration.whole:
                    Note.Data = Geometry.Parse(Engraving.Whole);
                    break;
                case Model.Duration.half:
                    Note.Data = Geometry.Parse(Engraving.Half);
                    break;
                case Model.Duration.quarter:
                    if (top >= -1) // Beim b auch Vorgänger beachten!
                        Note.Data = Geometry.Parse(Engraving.Quarter);
                    else
                        Note.Data = Geometry.Parse(Engraving.QuarterUpsideDown);
                    break;
                case Model.Duration.eigth:
                    Note.Data = Geometry.Parse(Engraving.Eigth);
                    break;
            }

            Canvas.SetTop(Note, measure.Top + top);
            Canvas.SetLeft(Note, left);
            canvas.Children.Add(Note);
        }

        public static void DrawLedger(Canvas canvas, UIMeasure measure, bool below, int count, double left)
        {
            int Width = 15;
            int Spacing = 6;

            if (below)
            {
                int Top = measure.Top + 41;

                for (int i = 0; i < count; i++)
                {
                    var Ledger = new Line { X1 = left - 3, Y1 = Top + i * Spacing, X2 = left + Width - 3, Y2 = Top + i * Spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };
                    Ledger.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                    canvas.Children.Add(Ledger);
                }
            }
            else
            {
                int Top = measure.Top + 3;

                for (int i = 0; i < count; i++)
                {
                    var Ledger = new Line { X1 = left - 3, Y1 = Top - i * Spacing, X2 = left + Width - 3, Y2 = Top - i * Spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };
                    Ledger.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                    canvas.Children.Add(Ledger);
                }
            }
        }

        public static void DrawAccidental(Canvas canvas, UIMeasure measure, Accidental accidentalKind, double top, double left)
        {
            double Top = measure.Top + top + 16;
            double Left = left - 6;

            Path NewAccidental = new Path
            {
                RenderTransform = new ScaleTransform(.3, .3),
                Fill = Brushes.Black,
            };

            switch (accidentalKind)
            {
                case Accidental.Sharp:
                    NewAccidental.Data = Geometry.Parse(Engraving.Sharp);
                    break;
                case Accidental.Flat:
                    NewAccidental.Data = Geometry.Parse(Engraving.Flat);
                    break;
                case Accidental.Natural:
                    NewAccidental.Data = Geometry.Parse(Engraving.Natural);
                    break;
                case Accidental.DoubleSharp:
                    NewAccidental.Data = Geometry.Parse(Engraving.DoubleSharp);
                    Left -= 3;
                    break;
                case Accidental.DoubleFlat:
                    NewAccidental.Data = Geometry.Parse(Engraving.DoubleFlat);
                    Left -= 3;
                    break;
            }

            Canvas.SetTop(NewAccidental, Top);
            Canvas.SetLeft(NewAccidental, Left);
            canvas.Children.Add(NewAccidental);
        }

    }
}
