using Model;
using Model.Meta;
using System;
using System.Collections.Generic;
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
                new UITitle(piece.Title, 60, pageList.First());

            if (piece.ListOfComposers != null && piece.ListOfComposers.Count > 0)
                foreach (var composer in piece.ListOfComposers)
                    DrawComposer(composer.FullName, pageList.First());

            int measuresPerSystem = 4;
            int systemsPerPage = 0;

            if (piece.ListOfSections == null || piece.ListOfSections.Count <= 0)
                return pageList;
            foreach (var section in piece.ListOfSections)
                if (section.ListOfMovements != null && section.ListOfMovements.Count > 0)
                    foreach (var movement in section.ListOfMovements)
                        if (movement.ListOfSegments != null && movement.ListOfSegments.Count > 0)
                            foreach (var segment in movement.ListOfSegments)
                                if (segment.ListOfPassages != null && segment.ListOfPassages.Count > 0)
                                    foreach (var passage in segment.ListOfPassages)
                                        if (passage.ListOfMeasures != null && passage.ListOfMeasures.Count > 0)
                                        {
                                            var maxStaves = passage.ListOfMeasures.Select(measure => measure.Parts.Count).Max();
                                            var currentTop = 200;
                                            double staffSpacing = 50;
                                            double systemSpacing = 30;

                                            var currentSystem = new UISystem(currentPage, currentTop, 50, 50, staffSpacing, systemSpacing);

                                            foreach (var measure in passage.ListOfMeasures)
                                            {
                                                // pagebreak every 4 systems
                                                if (systemsPerPage > 3)
                                                {
                                                    currentPage = CreatePage();
                                                    pageList.Add(currentPage);
                                                    systemsPerPage = 0;
                                                    currentTop = 60;
                                                    staffSpacing = 55;
                                                    systemSpacing = 40;
                                                }

                                                // systembreak every 4 measures
                                                if (measuresPerSystem > 3)
                                                {
                                                    currentSystem.ConnectStaves();
                                                    currentSystem = new UISystem(currentPage, currentTop, 50, 50, staffSpacing, systemSpacing);

                                                    for (var i = 0; i < maxStaves; i++)
                                                    {
                                                        var staff = new UIStaff(currentSystem, currentTop);
                                                        currentSystem.AddStaff(staff);
                                                        DrawTrebleClef(staff);
                                                    }
                                                    measuresPerSystem = 0;
                                                    systemsPerPage++;
                                                    currentTop += (int)currentSystem.Bottom; // Beginning of the next system
                                                }
                                                measuresPerSystem++;
                                                DrawMeasure(currentSystem, measure);
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

        public static List<UIMeasure> DrawMeasure(UISystem system, Measure measure = null)
        {
            const int indent = 40;
            const int width = 150;

            var measures = new List<UIMeasure>();

            if (measure == null || measure.Parts == null || measure.Parts.Count <= 0)
                return measures;

            for (var partNumber = 0; partNumber < measure.Parts.Count; partNumber++)
                if (measure.Parts[partNumber] != null && measure.Parts[partNumber].ListOfSymbols.Count > 0)
                {
                    var staff = system.Staves[partNumber];
                    const int top = -10;
                    int left;
                    // measure 2 to n
                    if (staff.Measures.Count > 0)
                        left = (int)(Canvas.GetLeft(staff.Measures.Last()) + staff.Measures.Last().Width);
                    // measure 1
                    else
                        left = indent;


                    // 1. noten pro schlag (z.B. 4 auf 1, 4 auf 2, 1 auf 3, 1 Pause auf 4)
                    // 2. Maximum finden (z.B. 4 pro Schlag)
                    // 3. Maximum x Schläge = spezifische Breite
                    // 4. Für alle Takte berechnen und aufaddieren
                    // 6. Absolute Breite = Spezifische Breite / Aufsummierte Breite * Zielbreite

                    var newMeasure = new UIMeasure(staff, top, left, width, measure);
                    staff.Measures.Add(newMeasure);
                    measures.Add(newMeasure);

                    int currentEnd = indent;
                    foreach (var uiMeasure in staff.Measures)
                    {
                        uiMeasure.Width = (staff.Width - indent) / 4;
                        Canvas.SetLeft(uiMeasure, currentEnd);
                        currentEnd += (int)uiMeasure.Width;
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

                InnerMeasure.Width = (int)((SpecificWidth / TotalWidth) * (staff.Width - Indent));
            }
            */

                    // Draw Notes

                    foreach (var symbol in measure.Parts[partNumber].ListOfSymbols)
                        if (symbol.GetType() == typeof(Note))
                            DrawNote((Note)symbol, measures[partNumber]);
                        else if (symbol.GetType() == typeof(Rest))
                            DrawRest((Rest)symbol, measures[partNumber]);
                }

            return measures;
        }

        public static void DrawTrebleClef(UIStaff staff)
        {
            const int top = -10;
            const int left = 10;

            var clef = new Path
            {
                RenderTransform = new ScaleTransform(.5, .5),
                Fill = Brushes.Black,
                Data = Geometry.Parse(Engraving.TrebleClef)
            };

            Canvas.SetTop(clef, top);
            Canvas.SetLeft(clef, left);
            staff.Children.Add(clef);
        }

        public static void DrawRest(Rest rest, UIMeasure measure)
        {
            var newRest = new Path
            {
                RenderTransform = new ScaleTransform(.21, .21),
                Fill = Brushes.Black,
                SnapsToDevicePixels = true
            };

            newRest.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Unspecified);
            newRest.SetValue(RenderOptions.ClearTypeHintProperty, ClearTypeHint.Enabled);
            newRest.SetValue(RenderOptions.CachingHintProperty, CachingHint.Cache);

            // Left
            var left = ((measure.Width - 10) / 4 * (rest.Beat - 1)) + 10;
            if (rest.Duration == Duration.whole)
                left = measure.Width / 2;

            // Top
            const double top = 11;

            switch (rest.Duration)
            {
                case Duration.whole:
                    newRest.Data = Geometry.Parse(Engraving.RestWhole);
                    break;
                case Duration.half:
                    newRest.Data = Geometry.Parse(Engraving.RestHalf);
                    break;
                case Duration.quarter:
                    newRest.Data = Geometry.Parse(Engraving.RestQuarter);
                    break;
                case Duration.eigth:
                    newRest.Data = Geometry.Parse(Engraving.RestEigth);
                    break;
                case Duration.sixteenth:
                    newRest.Data = Geometry.Parse(Engraving.RestSixteenth);
                    break;
            }

            Canvas.SetTop(newRest, top);
            Canvas.SetLeft(newRest, left);
            measure.Children.Add(newRest);
        }

        public static void DrawNote(Note note, UIMeasure measure)
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

            double left = ((measure.Width - 12) / 4 * (note.Beat - 1)) + 12;
            double top = 0;

            switch (note.Octave)
            {
                case 6:
                    top = -44;
                    break;
                case 5:
                    top = -21;
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
                    DrawAccidental(measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.DFlat:
                    top += 14;
                    DrawAccidental(measure, Accidental.Flat, top, left);
                    break;
                case Pitch.D:
                    top += 14;
                    break;
                case Pitch.DSharp:
                    top += 14;
                    DrawAccidental(measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.EFlat:
                    top += 11;
                    DrawAccidental(measure, Accidental.Flat, top, left);
                    break;
                case Pitch.E:
                    top += 11;
                    break;
                case Pitch.ESharp:
                    top += 11;
                    DrawAccidental(measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.FFlat:
                    top += 8;
                    DrawAccidental(measure, Accidental.Flat, top, left);
                    break;
                case Pitch.F:
                    top += 8;
                    break;
                case Pitch.FSharp:
                    top += 8;
                    DrawAccidental(measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.GFlat:
                    top += 5;
                    DrawAccidental(measure, Accidental.Flat, top, left);
                    break;
                case Pitch.G:
                    top += 5;
                    break;
                case Pitch.GSharp:
                    top += 5;
                    DrawAccidental(measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.AFlat:
                    top += 2;
                    DrawAccidental(measure, Accidental.Flat, top, left);
                    break;
                case Pitch.A:
                    top += 2;
                    break;
                case Pitch.ASharp:
                    top += 2;
                    DrawAccidental(measure, Accidental.Sharp, top, left);
                    break;
                case Pitch.BFlat:
                    top += -1;
                    DrawAccidental(measure, Accidental.Flat, top, left);
                    break;
                case Pitch.B:
                    top += -1;
                    break;
                case Pitch.BSharp:
                    top += -1;
                    DrawAccidental(measure, Accidental.Sharp, top, left);
                    break;
            }

            if (top >= 17)
                DrawLedger(measure, true, (int)((top - 10) / 6), left);
            else if (top < -15)
                DrawLedger(measure, false, (int)((Math.Abs(top) - 15) / 6), left);

            switch (note.Duration)
            {
                case Duration.wholeDotted:
                    newNote.Data = Geometry.Parse(Engraving.Whole);
                    newNote.Fill = Brushes.DarkRed;
                    // TODO Punkt
                    break;
                case Duration.whole:
                    newNote.Data = Geometry.Parse(Engraving.Whole);
                    break;
                case Duration.halfDotted:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Half : Engraving.HalfUpsideDown);
                    newNote.Fill = Brushes.DarkRed;
                    // TODO Punkt
                    break;
                case Duration.half:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Half : Engraving.HalfUpsideDown);
                    break;
                case Duration.quarterDotted:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                    newNote.Fill = Brushes.DarkRed;
                    // TODO Punkt
                    break;
                case Duration.quarter:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                    break;
                case Duration.eigthDotted:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Eigth : Engraving.EightUpsideDown);
                    newNote.Fill = Brushes.DarkRed;
                    // TODO Punkt
                    break;
                case Duration.eigth:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Eigth : Engraving.EightUpsideDown);
                    break;
                case Duration.sixteenthDotted:
                    newNote.Data = Geometry.Parse(Engraving.Sixteenth);
                    newNote.Fill = Brushes.DarkRed;
                    // TODO Punkt
                    break;
                case Duration.sixteenth:
                    newNote.Data = Geometry.Parse(Engraving.Sixteenth);
                    break;
            }

            Canvas.SetTop(newNote, top);
            Canvas.SetLeft(newNote, left);
            measure.Children.Add(newNote);
        }

        public static void DrawLedger(UIMeasure measure, bool below, int count, double left)
        {
            const int width = 15;
            const int spacing = 6;

            if (below)
            {
                const int top = 41;

                for (int i = 0; i < count; i++)
                {
                    var ledger = new Line
                    {
                        X1 = left - 3,
                        Y1 = top + i * spacing,
                        X2 = left + width - 3,
                        Y2 = top + i * spacing,
                        StrokeThickness = 1,
                        Stroke = Brushes.Black,
                        SnapsToDevicePixels = true
                    };
                    ledger.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                    measure.Children.Add(ledger);
                }
            }
            else
            {
                const int top = 3;

                for (int i = 0; i < count; i++)
                {
                    var ledger = new Line
                    {
                        X1 = left - 3,
                        Y1 = top - i * spacing,
                        X2 = left + width - 3,
                        Y2 = top - i * spacing,
                        StrokeThickness = 1,
                        Stroke = Brushes.Black,
                        SnapsToDevicePixels = true
                    };
                    ledger.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                    measure.Children.Add(ledger);
                }
            }
        }

        public static void DrawAccidental(UIMeasure measure, Accidental accidentalKind, double setTop, double setLeft)
        {
            double top = setTop + 16;
            double left = setLeft - 7;

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
            measure.Children.Add(newAccidental);
        }
    }
}