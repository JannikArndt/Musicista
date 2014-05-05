using Model;
using Model.Meta;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using Duration = Model.Duration;

namespace Musicista.UI
{
    public static class UIHelper
    {
        public static List<Canvas> DrawPiece(Piece piece)
        {
            Canvas currentPage = CreatePage();
            var pageList = new List<Canvas> { currentPage };

            if (!String.IsNullOrEmpty(piece.Title))
                DrawTitle(piece.Title, pageList.First());

            if (piece.ListOfComposers != null && piece.ListOfComposers.Count > 0)
                foreach (Composer composer in piece.ListOfComposers)
                    DrawComposer(composer.FullName, pageList.First());

            int count = 4;
            int measuresPerPage = 0;

            if (piece.ListOfSections == null || piece.ListOfSections.Count <= 0)
                return pageList;
            foreach (Section section in piece.ListOfSections)
                if (section.ListOfMovements != null && section.ListOfMovements.Count > 0)
                    foreach (Movement movement in section.ListOfMovements)
                        if (movement.ListOfSegments != null && movement.ListOfSegments.Count > 0)
                            foreach (Segment segment in movement.ListOfSegments)
                                if (segment.ListOfPassages != null && segment.ListOfPassages.Count > 0)
                                    foreach (Passage passage in segment.ListOfPassages)
                                        if (passage.ListOfMeasures != null && passage.ListOfMeasures.Count > 0)
                                        {
                                            int maxStaves =
                                                passage.ListOfMeasures.Select(measure => measure.Parts.Count).Max();
                                            int currentTop = 200;
                                            var staves = new List<UIStaff>();
                                            int staffSpacing = 50;
                                            int additionalSystemSpacing = 30;

                                            foreach (Measure measure in passage.ListOfMeasures)
                                            {
                                                // pagebreak every 16 measures
                                                if (measuresPerPage > 15)
                                                {
                                                    currentPage = CreatePage();
                                                    pageList.Add(currentPage);
                                                    measuresPerPage = 0;
                                                    currentTop = 60;
                                                    staffSpacing = 55;
                                                    additionalSystemSpacing = 40;
                                                }

                                                // once every four measures make a new system
                                                if (count > 3)
                                                {
                                                    staves.Clear();
                                                    for (int i = 0; i < maxStaves; i++)
                                                    {
                                                        UIStaff staff = DrawStaff(currentPage, currentTop);
                                                        DrawTrebleClef(currentPage, staff);
                                                        staves.Add(staff);
                                                        currentTop += staffSpacing; // Spacing between staves
                                                    }
                                                    count = 0;
                                                    currentTop += additionalSystemSpacing; // Spacing between systems
                                                }


                                                count++;
                                                measuresPerPage++;

                                                DrawMeasure(currentPage, staves, measure);
                                            }
                                        }
            return pageList;
        }

        public static Canvas CreatePage()
        {
            var canvas = new Canvas
            {
                Width = 841, // A0 in mm
                Height = 1189,
                Margin = new Thickness(0, 20, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Background = Brushes.White,
                LayoutTransform = new ScaleTransform(1, 1),
                Effect = new DropShadowEffect { RenderingBias = RenderingBias.Performance }
            };
            Panel.SetZIndex(canvas, 0);
            return canvas;
        }

        public static UITitle DrawTitle(string text, Canvas page)
        {
            var title = new UITitle(text, 60, 0);

            // center title
            title.Left = (int)((page.Width / 2) - (title.Width / 2));

            page.Children.Add(title.TitleTextBlock);
            return title;
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
            const int left = 50;
            int width = (int)page.Width - 2 * 50;
            var staff = new UIStaff(top, left, width);

            page.Children.Add(staff.line1);
            page.Children.Add(staff.line2);
            page.Children.Add(staff.line3);
            page.Children.Add(staff.line4);
            page.Children.Add(staff.line5);

            return staff;
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
                        // measure 2 to n
                        if (staves[partNumber].Measures.Count > 0)
                            left = staves[partNumber].Measures.Last().Left + staves[partNumber].Measures.Last().Width;
                        // measure 1
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

                        int currentEnd = staves[partNumber].Left + indent;
                        foreach (UIMeasure uiMeasure in staves[partNumber].Measures)
                        {
                            uiMeasure.Width = (staves[partNumber].Width - indent) / 4;
                            //staves[partNumber].Measures.Count;
                            uiMeasure.Left = currentEnd;
                            currentEnd += uiMeasure.Width;
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

                        foreach (Symbol symbol in measure.Parts[partNumber].ListOfSymbols)
                            DrawSymbol(page, symbol, measures[partNumber]);
                    }

            return measures;
        }

        public static void DrawTrebleClef(Canvas page, UIStaff staff)
        {
            int top = staff.Top - 10;
            int left = staff.Left + 10;

            var clef = new Path
            {
                RenderTransform = new ScaleTransform(.5, .5),
                Fill = Brushes.Black,
                Data = Geometry.Parse(Engraving.TrebleClef)
            };

            Canvas.SetTop(clef, top);
            Canvas.SetLeft(clef, left);
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
            var newRest = new Path
            {
                RenderTransform = new ScaleTransform(.21, .21),
                Fill = Brushes.Red,
                SnapsToDevicePixels = true
            };

            newRest.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Unspecified);
            newRest.SetValue(RenderOptions.ClearTypeHintProperty, ClearTypeHint.Enabled);
            newRest.SetValue(RenderOptions.CachingHintProperty, CachingHint.Cache);

            double left = measure.Left + ((measure.Width - 10) / 4 * (rest.Beat - 1)) + 10;
            const double top = 0;

            switch (rest.Duration)
            {
                case Duration.whole:
                    newRest.Data = Geometry.Parse(Engraving.Whole);
                    break;
                case Duration.half:
                    newRest.Data = Geometry.Parse(Engraving.Half);
                    break;
                case Duration.quarter:
                    newRest.Data = Geometry.Parse(Engraving.Quarter);
                    break;
                case Duration.eigth:
                    newRest.Data = Geometry.Parse(Engraving.Eigth);
                    break;
                case Duration.sixteenth:
                    newRest.Data = Geometry.Parse(Engraving.Sixteenth);
                    break;
            }

            Canvas.SetTop(newRest, measure.Top + top);
            Canvas.SetLeft(newRest, left);
            page.Children.Add(newRest);
        }

        public static void DrawNote(Canvas page, Note note, UIMeasure measure)
        {
            var newNote = new Path
            {
                RenderTransform = new ScaleTransform(.21, .21),
                Fill = Brushes.Black,
                SnapsToDevicePixels = true
            };

            newNote.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Unspecified);
            newNote.SetValue(RenderOptions.ClearTypeHintProperty, ClearTypeHint.Enabled);
            newNote.SetValue(RenderOptions.CachingHintProperty, CachingHint.Cache);

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
                case Pitch.C:
                    top += 18;
                    break;
                case Pitch.CSharp:
                    top += 18;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.DFlat:
                    top += 14;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Pitch.D:
                    top += 14;
                    break;
                case Pitch.DSharp:
                    top += 14;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.EFlat:
                    top += 11;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Pitch.E:
                    top += 11;
                    break;
                case Pitch.ESharp:
                    top += 11;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.FFlat:
                    top += 8;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Pitch.F:
                    top += 8;
                    break;
                case Pitch.FSharp:
                    top += 8;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.GFlat:
                    top += 5;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Pitch.G:
                    top += 5;
                    break;
                case Pitch.GSharp:
                    top += 5;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.AFlat:
                    top += 2;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Pitch.A:
                    top += 2;
                    break;
                case Pitch.ASharp:
                    top += 2;
                    DrawAccidental(page, measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.BFlat:
                    top += -1;
                    DrawAccidental(page, measure, Accidental.Flat, top, left);
                    break;
                case Pitch.B:
                    top += -1;
                    break;
                case Pitch.BSharp:
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
                case Duration.whole:
                    newNote.Data = Geometry.Parse(Engraving.Whole);
                    break;
                case Duration.half:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Half : Engraving.HalfUpsideDown);
                    break;
                case Duration.quarter:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                    break;
                case Duration.eigth:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Eigth : Engraving.EightUpsideDown);
                    break;
                case Duration.sixteenth:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Sixteenth : Engraving.Sixteenth);
                    break;
            }

            Canvas.SetTop(newNote, measure.Top + top);
            Canvas.SetLeft(newNote, left);
            page.Children.Add(newNote);
        }

        public static void DrawLedger(Canvas page, UIMeasure measure, bool below, int count, double left)
        {
            const int Width = 15;
            const int Spacing = 6;

            if (below)
            {
                int top = measure.Top + 41;

                for (int i = 0; i < count; i++)
                {
                    var ledger = new Line
                    {
                        X1 = left - 3,
                        Y1 = top + i * Spacing,
                        X2 = left + Width - 3,
                        Y2 = top + i * Spacing,
                        StrokeThickness = 1,
                        Stroke = Brushes.Black,
                        SnapsToDevicePixels = true
                    };
                    ledger.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                    page.Children.Add(ledger);
                }
            }
            else
            {
                int top = measure.Top + 3;

                for (int i = 0; i < count; i++)
                {
                    var ledger = new Line
                    {
                        X1 = left - 3,
                        Y1 = top - i * Spacing,
                        X2 = left + Width - 3,
                        Y2 = top - i * Spacing,
                        StrokeThickness = 1,
                        Stroke = Brushes.Black,
                        SnapsToDevicePixels = true
                    };
                    ledger.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                    page.Children.Add(ledger);
                }
            }
        }

        public static void DrawAccidental(Canvas page, UIMeasure measure, Accidental accidentalKind, double setTop,
            double setLeft)
        {
            double top = measure.Top + setTop + 16;
            double left = setLeft - 6;

            var newAccidental = new Path
            {
                RenderTransform = new ScaleTransform(.3, .3),
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
                    left -= 3;
                    break;
                case Accidental.DoubleFlat:
                    newAccidental.Data = Geometry.Parse(Engraving.DoubleFlat);
                    left -= 3;
                    break;
            }

            Canvas.SetTop(newAccidental, top);
            Canvas.SetLeft(newAccidental, left);
            page.Children.Add(newAccidental);
        }
    }
}