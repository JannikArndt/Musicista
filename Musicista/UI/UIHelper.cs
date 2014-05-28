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
        private static readonly List<Path> NotYetConnectedEigths = new List<Path>();
        private static bool _stemDirectionUp = true;
        public static List<Canvas> DrawPiece(Piece piece)
        {
            Canvas currentPage = CreatePage();
            var pageList = new List<Canvas> { currentPage };

            if (!String.IsNullOrEmpty(piece.Title))
                new UITitle(piece.Title, 60, pageList.First());

            if (piece.ListOfComposers != null && piece.ListOfComposers.Count > 0)
                foreach (var composer in piece.ListOfComposers)
                    DrawComposer(composer.FullName, pageList.First());

            var measuresPerSystem = 4;
            var systemsPerPage = 0;

            if (piece.ListOfSections == null || piece.ListOfSections.Count <= 0)
                return pageList;
            foreach (var section in piece.ListOfSections)
                if (section.ListOfMovements != null && section.ListOfMovements.Count > 0)
                    foreach (var movement in section.ListOfMovements)
                        if (movement.ListOfSegments != null && movement.ListOfSegments.Count > 0)
                            foreach (var segment in movement.ListOfSegments)
                                if (segment.ListOfPassages != null && segment.ListOfPassages.Count > 0)
                                    foreach (var passage in segment.ListOfPassages)
                                        if (passage.ListOfMeasureGroups != null && passage.ListOfMeasureGroups.Count > 0)
                                        {
                                            var maxStaves = passage.ListOfMeasureGroups.Select(measure => measure.Measures.Count).Max();
                                            double currentTop = 200;
                                            double staffSpacing = 50;
                                            double systemSpacing = 30;

                                            // 1. New System
                                            var currentSystem = new UISystem(currentPage, currentTop, 50, 50, staffSpacing, systemSpacing);

                                            foreach (var measureGroup in passage.ListOfMeasureGroups)
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
                                                    // print Barline in front of the system
                                                    if (currentSystem.MeasureGroups.Any() && currentSystem.MeasureGroups[0].Measures.Any())
                                                        currentSystem.BarlineFront.Y2 = Canvas.GetTop(currentSystem.MeasureGroups[0].Measures.Last()) + 36;

                                                    // New System with lines (staves)
                                                    currentSystem = new UISystem(currentPage, currentTop, 50, 50, staffSpacing, systemSpacing);

                                                    for (var i = 0; i < maxStaves; i++)
                                                    {
                                                        var staff = new UIStaff(currentSystem, currentTop);
                                                        currentSystem.AddStaff(staff);
                                                        DrawTrebleClef(staff);
                                                    }
                                                    measuresPerSystem = 0;
                                                    systemsPerPage++;
                                                    currentTop += currentSystem.Bottom; // Beginning of the next system
                                                }
                                                measuresPerSystem++;
                                                DrawMeasureGroup(currentSystem, measureGroup);
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

        public static void DrawMeasureGroup(UISystem system, MeasureGroup measureGroup = null)
        {
            if (measureGroup == null || measureGroup.Measures == null || measureGroup.Measures.Count <= 0)
                return;

            var left = system.Indent;
            // measure 2 to n
            if (system.MeasureGroups.Count > 0)
                left = Canvas.GetLeft(system.MeasureGroups.Last()) + system.MeasureGroups.Last().Width;

            // Create UIMeasureGroup
            var uiMeasureGroup = new UIMeasureGroup(system, left, measureGroup);
            system.MeasureGroups.Add(uiMeasureGroup);

            // Fill UIMeasureGroup.Measures with UIMeasures
            for (var part = 0; part < measureGroup.Measures.Count; part++)
                DrawMeasure(uiMeasureGroup, measureGroup.Measures[part], part + 1);

            // set connecting barlines
            if (uiMeasureGroup.Measures.Count > 0)
                uiMeasureGroup.Barline.Y2 = Canvas.GetTop(uiMeasureGroup.Measures.Last()) + 36;
        }

        public static void DrawMeasure(UIMeasureGroup measureGroup, Measure measure, int part)
        {
            if (measure.Symbols == null || measure.Symbols.Count <= 0)
                return;

            var top = Canvas.GetTop(measureGroup.ParentSystem.Staves[part - 1]) - 10;
            var newMeasure = new UIMeasure(measureGroup, top, part, measure);
            measureGroup.Measures.Add(newMeasure);

            foreach (var symbol in measure.Symbols)
                if (symbol.GetType() == typeof(Note))
                    DrawNote((Note)symbol, newMeasure);
                else if (symbol.GetType() == typeof(Rest))
                    DrawRest((Rest)symbol, newMeasure);
        }

        public static void DrawTrebleClef(UIStaff staff)
        {
            const double top = -10;
            const double left = 10;

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
                Fill = Brushes.Black,
                SnapsToDevicePixels = true
            };

            newRest.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Unspecified);
            newRest.SetValue(RenderOptions.ClearTypeHintProperty, ClearTypeHint.Enabled);
            newRest.SetValue(RenderOptions.CachingHintProperty, CachingHint.Cache);

            const int beatsPerMeasure = 4; // TODO

            // Left
            var left = ((measure.Width - measure.Indent) / beatsPerMeasure * (rest.Beat - 1)) + measure.Indent;
            if (rest.Duration == Duration.whole)
                left = measure.Width / 2;

            // Top
            const double top = 55;

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
                Fill = Brushes.Black,
                SnapsToDevicePixels = true
            };

            const int noteStepSpacing = 15;

            var connectEigthsAtEndOfRun = false;

            newNote.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Unspecified);
            newNote.SetValue(RenderOptions.ClearTypeHintProperty, ClearTypeHint.Enabled);
            newNote.SetValue(RenderOptions.CachingHintProperty, CachingHint.Cache);

            const int beatsPerMeasure = 4; // TODO measure.InnerMeasure.ParentMeasureGroup.TimeSignature.Beats

            double left = ((measure.Width - measure.Indent) / beatsPerMeasure * (note.Beat - 1)) + measure.Indent;
            double top = 0;

            // treble clef
            top -= 16;

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
                    top += 0; //18;
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
                    top -= noteStepSpacing;
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
                    top -= 2 * noteStepSpacing;
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
                    top -= 3 * noteStepSpacing;
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
                    top -= 4 * noteStepSpacing;
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
                    top -= 5 * noteStepSpacing;
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
                    top -= 6 * noteStepSpacing;
                    break;
                case Pitch.BSharp:
                    top += -1;
                    DrawAccidental(measure, Accidental.Sharp, top, left);
                    break;
            }

            // top line = 50, first upper ledger = 20, bottom line = 170, first lower ledger = 200, note height = 110
            if (top >= 89)
                DrawLedger(measure, true, (int)((top - 59) / (2 * noteStepSpacing)), left);
            else if (top < -89)
                DrawLedger(measure, false, (int)((Math.Abs(top) - 60) / (2 * noteStepSpacing)), left);

            switch (note.Duration)
            {
                case Duration.wholeDotted:
                    newNote.Data = Geometry.Parse(Engraving.Whole);
                    DrawDot(measure, top, left);
                    break;
                case Duration.whole:
                    newNote.Data = Geometry.Parse(Engraving.Whole);
                    break;
                case Duration.halfDotted:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Half : Engraving.HalfUpsideDown);
                    DrawDot(measure, top, left);
                    break;
                case Duration.half:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Half : Engraving.HalfUpsideDown);
                    break;
                case Duration.quarterDotted:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                    DrawDot(measure, top, left);
                    break;
                case Duration.quarter:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                    break;
                case Duration.eigthDotted:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Eigth : Engraving.EightUpsideDown);
                    DrawDot(measure, top, left);
                    break;
                case Duration.eigth:
                    newNote.Data = Geometry.Parse(top >= -1 ? Engraving.Eigth : Engraving.EightUpsideDown);
                    if (note.Next != null && note.Next.Duration == Duration.eigth && note.Next.Beat != 1 && note.Next.Beat != 3)
                    {
                        if (!NotYetConnectedEigths.Any())
                            _stemDirectionUp = top >= -1;
                        newNote.Data = Geometry.Parse(_stemDirectionUp ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                        NotYetConnectedEigths.Add(newNote);
                    }
                    else if (NotYetConnectedEigths.Any())
                    {
                        newNote.Data = Geometry.Parse(_stemDirectionUp ? Engraving.Quarter : Engraving.QuarterUpsideDown);
                        NotYetConnectedEigths.Add(newNote);
                        connectEigthsAtEndOfRun = true;
                    }
                    break;
                case Duration.sixteenthDotted:
                    newNote.Data = Geometry.Parse(Engraving.Sixteenth);
                    DrawDot(measure, top, left);
                    break;
                case Duration.sixteenth:
                    newNote.Data = Geometry.Parse(Engraving.Sixteenth);
                    break;
            }

            Canvas.SetTop(newNote, top);
            Canvas.SetLeft(newNote, left);
            measure.Children.Add(newNote);
            if (connectEigthsAtEndOfRun || NotYetConnectedEigths.Count == 4 || (NotYetConnectedEigths.Any() && note.Next != null && (note.Next.Beat == 3 || note.Next.Beat == 1)))
                ConnectEigths(measure);
        }

        public static void DrawLedger(UIMeasure measure, bool below, int count, double left)
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
                        X1 = left - 15,
                        Y1 = top + i * spacing,
                        X2 = left + width - 15,
                        Y2 = top + i * spacing,
                        StrokeThickness = 5,
                        Stroke = Brushes.Black,
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
                        X1 = left - 15,
                        Y1 = top - i * spacing,
                        X2 = left + width - 15,
                        Y2 = top - i * spacing,
                        StrokeThickness = 5,
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
            var top = setTop + 80;
            var left = setLeft - 35;

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

        public static void DrawDot(UIMeasure measure, double setTop, double setLeft)
        {
            double top;
            if (Math.Abs(setTop % 30) < 5)
                top = setTop + 88;
            else
                top = setTop + 103;

            var left = setLeft + 50;

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

        public static void ConnectEigths(UIMeasure measure)
        {
            double x1, x2, y1, y2;

            if (_stemDirectionUp)
            {
                x1 = Canvas.GetLeft(NotYetConnectedEigths.First()) + 34;
                y1 = Canvas.GetTop(NotYetConnectedEigths.First()) + 0;
                x2 = Canvas.GetLeft(NotYetConnectedEigths.Last()) + 38;
                y2 = Canvas.GetTop(NotYetConnectedEigths.Last()) + 0;
            }
            else
            {
                x1 = Canvas.GetLeft(NotYetConnectedEigths.First());
                y1 = Canvas.GetTop(NotYetConnectedEigths.First()) + 225;
                x2 = Canvas.GetLeft(NotYetConnectedEigths.Last()) + 5;
                y2 = Canvas.GetTop(NotYetConnectedEigths.Last()) + 225;
            }

            for (int count = 0; count < 25; count = count + 5)
            {
                var beam = new Line
                {
                    X1 = x1,
                    Y1 = y1 + count,
                    X2 = x2,
                    Y2 = y2 + count,
                    StrokeThickness = 5,
                    Stroke = Brushes.Black,
                    SnapsToDevicePixels = true
                };
                beam.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Unspecified);
                measure.Children.Add(beam);
                NotYetConnectedEigths.Clear();
            }

        }
    }
}