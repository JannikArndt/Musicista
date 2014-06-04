using Model;
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
                                                        DrawClef(staff, measureGroup.Measures[i].Clef);
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
                    new UINote((Note)symbol, newMeasure);
                else if (symbol.GetType() == typeof(Rest))
                    DrawRest((Rest)symbol, newMeasure);
        }

        public static void DrawClef(UIStaff staff, Clef clefType)
        {
            var clef = new Path
            {
                Fill = Brushes.Black,
            };

            switch (clefType)
            {
                case Clef.Treble:
                    clef.RenderTransform = new ScaleTransform(.5, .5);
                    clef.Data = Geometry.Parse(Engraving.TrebleClef);
                    Canvas.SetTop(clef, -10);
                    Canvas.SetLeft(clef, 10);
                    break;
                case Clef.Bass:
                    clef.RenderTransform = new ScaleTransform(.13, .13);
                    clef.Data = Geometry.Parse(Engraving.BassClef);
                    Canvas.SetTop(clef, 1);
                    Canvas.SetLeft(clef, 10);
                    break;
            }

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
    }
}