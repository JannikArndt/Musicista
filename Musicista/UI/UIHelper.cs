using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public static class UIHelper
    {
        public static List<Canvas> DrawPiece(Piece piece)
        {
            var pageList = new List<Canvas> { CreatePage(), CreatePage() };
            var currentPage = pageList.First();

            if (!String.IsNullOrEmpty(piece.Title))
                DrawTitle(piece.Title, pageList.First());

            if (piece.ListOfComposers != null && piece.ListOfComposers.Count > 0)
                foreach (var composer in piece.ListOfComposers)
                    DrawComposer(composer.FullName, pageList.First());

            int count = 4;

            if (piece.ListOfSections != null && piece.ListOfSections.Count > 0)
                foreach (var section in piece.ListOfSections)
                    if (section.ListOfMovements != null && section.ListOfMovements.Count > 0)
                        foreach (var movement in section.ListOfMovements)
                            if (movement.ListOfSegments != null && movement.ListOfSegments.Count > 0)
                                foreach (var segment in movement.ListOfSegments)
                                    if (segment.ListOfPassages != null && segment.ListOfPassages.Count > 0)
                                        foreach (var passage in segment.ListOfPassages)
                                            if (passage.ListOfMeasures != null && passage.ListOfMeasures.Count > 0)
                                            {
                                                int maxStaves = passage.ListOfMeasures.Select(measure => measure.Parts.Count).Max();
                                                int currentTop = 200;
                                                var staves = new List<UIStaff>();

                                                foreach (var measure in passage.ListOfMeasures)
                                                {
                                                    if (count > 3)
                                                    {
                                                        staves.Clear();
                                                        for (int i = 0; i < maxStaves; i++)
                                                        {
                                                            var staff = DrawStaff(currentPage, currentTop);
                                                            DrawTrebleClef(pageList.First(), staff);
                                                            staves.Add(staff);
                                                            currentTop += 80;
                                                        }
                                                        count = 0;
                                                    }
                                                    count++;

                                                    DrawMeasure(pageList.First(), staves, measure);
                                                }
                                            }
            return pageList;
        }

        public static Canvas CreatePage()
        {
            return new Canvas
            {
                Width = 841,     // A0 in mm
                Height = 1189,
                Margin = new Thickness(0, 20, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                LayoutTransform = new ScaleTransform(1, 1),
                Background = Brushes.White,
                Effect = new DropShadowEffect { RenderingBias = RenderingBias.Performance }
            };
        }
        public static UITitle DrawTitle(string text, Canvas page)
        {
            var Title = new UITitle(text, 60, 0);

            // center title
            Title.Left = (int)((page.Width / 2) - (Title.Width / 2));

            page.Children.Add(Title.TitleTextBlock);
            return Title;
        }

        public static void DrawComposer(string text, Canvas page)
        {
            var composerTextBlock = new TextBlock
            {
                Text = text,
                FontSize = 16
            };
            Canvas.SetTop(composerTextBlock, 150);
            Canvas.SetRight(composerTextBlock, 50);
            page.Children.Add(composerTextBlock);
        }

        public static Size MeasureString(string candidate)
        {
            var textBlock = new TextBlock();
            var formattedText = new FormattedText(
                candidate,
                CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight,
                new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch),
                textBlock.FontSize,
                Brushes.Black);

            return new Size(formattedText.Width, formattedText.Height);
        }

        public static UIStaff DrawStaff(Canvas page, int top)
        {
            int Left = 50;
            int Width = (int)page.Width - 2 * 50;
            var Staff = new UIStaff(top, Left, Width);

            page.Children.Add(Staff.line1);
            page.Children.Add(Staff.line2);
            page.Children.Add(Staff.line3);
            page.Children.Add(Staff.line4);
            page.Children.Add(Staff.line5);

            return Staff;
        }

        public static List<UIMeasure> DrawMeasure(Canvas page, List<UIStaff> staves, Measure measure = null)
        {
            const int indent = 40;
            const int width = 150;

            var measures = new List<UIMeasure>();

            if (measure != null && measure.Parts != null && measure.Parts.Count > 0)
                for (int partNumber = 0; partNumber < measure.Parts.Count; partNumber++)
                    if (measure.Parts[partNumber] != null && measure.Parts[partNumber].ListOfSymbols.Count > 0)
                    {

                        int top = staves[partNumber].Top - 10;
                        int left;
                        if (staves[partNumber].Measures.Count > 0)
                            left = staves[partNumber].Measures.Last().Left + staves[partNumber].Measures.Last().Width;
                        else
                            left = staves[partNumber].Left + indent;


                        // 1. noten pro schlag (z.B. 4 auf 1, 4 auf 2, 1 auf 3, 1 Pause auf 4)
                        // 2. Maximum finden (z.B. 4 pro Schlag)
                        // 3. Maximum x Schläge = spezifische Breite
                        // 4. Für alle Takte berechnen und aufaddieren
                        // 6. Absolute Breite = Spezifische Breite / Aufsummierte Breite * Zielbreite

                        var newMeasure = new UIMeasure(page, top, left, width, measure);
                        staves[partNumber].Measures.Add(newMeasure);
                        measures.Add(newMeasure);

                        int CurrentEnd = staves[partNumber].Left + indent;
                        foreach (var UIMeasure in staves[partNumber].Measures)
                        {
                            UIMeasure.Width = (staves[partNumber].Width - indent) / 2; //staves[partNumber].Measures.Count;
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

                        // Draw Notes

                        foreach (var symbol in measure.Parts[partNumber].ListOfSymbols)
                            DrawSymbol(page, symbol, measures[partNumber]);
                    }

            return measures;
        }

        public static void DrawTrebleClef(Canvas page, UIStaff staff)
        {
            int Top = staff.Top - 10;
            int Left = staff.Left + 10;

            var clef = new Path
            {
                RenderTransform = new ScaleTransform(.5, .5),
                Fill = Brushes.Black,
                Data = Geometry.Parse(Engraving.TrebleClef)
            };

            Canvas.SetTop(clef, Top);
            Canvas.SetLeft(clef, Left);
            page.Children.Add(clef);
        }

        public static void DrawSymbol(Canvas page, Symbol symbol, UIMeasure measure)
        {
            if (symbol.GetType() == typeof(Note))
                DrawNote(page, (Note)symbol, measure);
            else if (symbol.GetType() == typeof(Rest))
                DrawRest(page, (Rest)symbol, measure);

        }

        public static void DrawRest(Canvas page, Rest rest, UIMeasure measure)
        {
            var Rest = new Path
            {
                RenderTransform = new ScaleTransform(.21, .21),
                Fill = Brushes.Red,
                SnapsToDevicePixels = true
            };

            Rest.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Unspecified);
            Rest.SetValue(RenderOptions.ClearTypeHintProperty, ClearTypeHint.Enabled);
            Rest.SetValue(RenderOptions.CachingHintProperty, CachingHint.Cache);

            double left = measure.Left + ((measure.Width - 10) / 4 * (rest.Beat - 1)) + 10;
            double top = 0;

            switch (rest.Duration)
            {
                case Model.Duration.whole:
                    Rest.Data = Geometry.Parse(Engraving.Whole);
                    break;
                case Model.Duration.half:
                    Rest.Data = Geometry.Parse(top >= -1 ? Engraving.Half : Engraving.HalfUpsideDown);
                    break;
                case Model.Duration.quarter:
                    Rest.Data = Geometry.Parse(top >= -1 ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                    break;
                case Model.Duration.eigth:
                    Rest.Data = Geometry.Parse(top >= -1 ? Engraving.Eigth : Engraving.EightUpsideDown);
                    break;
                case Model.Duration.sixteenth:
                    Rest.Data = Geometry.Parse(top >= -1 ? Engraving.Sixteenth : Engraving.Sixteenth);
                    break;
            }

            Canvas.SetTop(Rest, measure.Top + top);
            Canvas.SetLeft(Rest, left);
            page.Children.Add(Rest);
        }

        public static void DrawNote(Canvas page, Note note, UIMeasure measure)
        {
            var Note = new Path
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
                    top = -44;
                    break;
                case 5:
                    top = -22;
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
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.DFlat:
                    top += 14;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.D:
                    top += 14;
                    break;
                case Model.Meta.Pitch.DSharp:
                    top += 14;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.EFlat:
                    top += 11;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.E:
                    top += 11;
                    break;
                case Model.Meta.Pitch.ESharp:
                    top += 11;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.FFlat:
                    top += 8;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.F:
                    top += 8;
                    break;
                case Model.Meta.Pitch.FSharp:
                    top += 8;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.GFlat:
                    top += 5;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.G:
                    top += 5;
                    break;
                case Model.Meta.Pitch.GSharp:
                    top += 5;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.AFlat:
                    top += 2;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.A:
                    top += 2;
                    break;
                case Model.Meta.Pitch.ASharp:
                    top += 2;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Model.Meta.Pitch.BFlat:
                    top += -1;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Model.Meta.Pitch.B:
                    top += -1;
                    break;
                case Model.Meta.Pitch.BSharp:
                    top += -1;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
            }

            if (top >= 17)
                DrawLedger(page, measure, true, (int)((top - 10) / 6), left);
            else if (top < -15)
                DrawLedger(page, measure, false, (int)((Math.Abs(top) - 15) / 6), left);

            switch (note.Duration)
            {
                case Model.Duration.whole:
                    Note.Data = Geometry.Parse(Engraving.Whole);
                    break;
                case Model.Duration.half:
                    Note.Data = Geometry.Parse(top >= -1 ? Engraving.Half : Engraving.HalfUpsideDown);
                    break;
                case Model.Duration.quarter:
                    Note.Data = Geometry.Parse(top >= -1 ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                    break;
                case Model.Duration.eigth:
                    Note.Data = Geometry.Parse(top >= -1 ? Engraving.Eigth : Engraving.EightUpsideDown);
                    break;
                case Model.Duration.sixteenth:
                    Note.Data = Geometry.Parse(top >= -1 ? Engraving.Sixteenth : Engraving.Sixteenth);
                    break;
            }

            Canvas.SetTop(Note, measure.Top + top);
            Canvas.SetLeft(Note, left);
            page.Children.Add(Note);
        }

        public static void DrawLedger(Canvas page, UIMeasure measure, bool below, int count, double left)
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
                    page.Children.Add(Ledger);
                }
            }
            else
            {
                int Top = measure.Top + 3;

                for (int i = 0; i < count; i++)
                {
                    var Ledger = new Line { X1 = left - 3, Y1 = Top - i * Spacing, X2 = left + Width - 3, Y2 = Top - i * Spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };
                    Ledger.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                    page.Children.Add(Ledger);
                }
            }
        }

        public static void DrawAccidental(Canvas page, UIMeasure measure, Accidental accidentalKind, double top, double left)
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
            page.Children.Add(NewAccidental);
        }

    }
}
