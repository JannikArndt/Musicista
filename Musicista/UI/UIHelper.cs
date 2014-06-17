using Model;
using Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Duration = Model.Duration;

namespace Musicista.UI
{
    public static class UIHelper
    {
        private static List<UIMeasure> _selectedUIMeasures = new List<UIMeasure>();
        public static List<UIMeasure> SelectedUIMeasures
        {
            get { return _selectedUIMeasures; }
            set { _selectedUIMeasures = value; }
        }
        public static List<Canvas> DrawPiece(Piece piece)
        {
            var currentPage = new UIPage();
            var pageList = new List<Canvas> { currentPage };

            if (!String.IsNullOrEmpty(piece.Title))
                new UITitle(piece, 60, pageList.First());

            if (piece.ListOfComposers != null && piece.ListOfComposers.Count > 0)
                foreach (var composer in piece.ListOfComposers)
                    DrawComposer(piece, pageList.First());

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
                                            double staffSpacing = 70;
                                            double systemSpacing = 30;

                                            // 1. New System
                                            var currentSystem = new UISystem(currentPage, currentTop, 50, 50, staffSpacing, systemSpacing);

                                            foreach (var measureGroup in passage.ListOfMeasureGroups)
                                            {
                                                // pagebreak every 4 systems
                                                if (systemsPerPage > 3)
                                                {
                                                    currentPage = new UIPage();
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
                                                        if (measureGroup.Measures.Count > i && measureGroup.Measures[i] != null)
                                                        {
                                                            DrawClef(staff, measureGroup.Measures[i].Clef);
                                                            var keyWidth = DrawKey(staff, measureGroup.KeySignature, measureGroup.Measures[i].Clef);
                                                            currentSystem.Indent += keyWidth;
                                                        }
                                                    }
                                                    measuresPerSystem = 0;
                                                    systemsPerPage++;
                                                    currentTop += currentSystem.Bottom; // Beginning of the next system
                                                }
                                                measuresPerSystem++;
                                                DrawMeasureGroup(currentSystem, measureGroup);
                                            }
                                            // print Barline in front of the system
                                            if (currentSystem.MeasureGroups.Any() && currentSystem.MeasureGroups[0].Measures.Any())
                                                currentSystem.BarlineFront.Y2 = Canvas.GetTop(currentSystem.MeasureGroups[0].Measures.Last()) + 36;
                                        }
            return pageList;
        }

        public static void DrawComposer(Piece piece, Canvas page)
        {
            var composerTextBlock = new TextBlock
            {
                DataContext = piece,
                FontSize = 16,
                TextAlignment = TextAlignment.Right,
                TextWrapping = TextWrapping.WrapWithOverflow,
                Width = 200
            };
            composerTextBlock.SetBinding(TextBlock.TextProperty, "ComposersAsString");

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

            // Add indent in special occasions
            var indent = (measureGroup.Previous != null && !Equals(measureGroup.KeySignature, measureGroup.Previous.KeySignature)) ? 100 : 60;

            // Fill UIMeasureGroup.Measures with UIMeasures
            for (var part = 0; part < measureGroup.Measures.Count; part++)
                DrawMeasure(uiMeasureGroup, measureGroup.Measures[part], part + 1, indent);

            // Draw key signature changes
            if (measureGroup.Previous != null && !Equals(measureGroup.KeySignature, measureGroup.Previous.KeySignature))
                foreach (var uiMeasure in uiMeasureGroup.Measures)
                    DrawKey(uiMeasure, measureGroup.KeySignature, uiMeasure.InnerMeasure.Clef);

            // set connecting barlines
            if (uiMeasureGroup.Measures.Count > 0)
                uiMeasureGroup.Barline.Y2 = Canvas.GetTop(uiMeasureGroup.Measures.Last()) + 36;
        }

        public static void DrawMeasure(UIMeasureGroup measureGroup, Measure measure, int part, int indent = 60)
        {
            if (measure.Symbols == null || measure.Symbols.Count <= 0)
                return;

            var top = Canvas.GetTop(measureGroup.ParentSystem.Staves[part - 1]) - 10;
            var newMeasure = new UIMeasure(measureGroup, top, part, measure) { Indent = indent };
            measureGroup.Measures.Add(newMeasure);

            foreach (var symbol in measure.Symbols)
                if (symbol.GetType() == typeof(Note))
                    new UINote((Note)symbol, newMeasure);
                else if (symbol.GetType() == typeof(Rest))
                    DrawRest((Rest)symbol, newMeasure);
        }

        public static void DrawClef(Canvas canvas, Clef clefType)
        {
            var clef = new Path
            {
                Fill = Brushes.Black,
            };

            var scale = 1;
            var additionalTop = 0;
            if (canvas.GetType() == typeof(UIMeasure))
            {
                scale = 5;
                additionalTop = 45;
                ((UIMeasure)canvas).Indent += 100;
            }

            switch (clefType)
            {
                case Clef.Treble:
                    clef.RenderTransform = new ScaleTransform(.5 * scale, .5 * scale);
                    clef.Data = Geometry.Parse(Engraving.TrebleClef);
                    Canvas.SetTop(clef, -10 * scale + additionalTop);
                    Canvas.SetLeft(clef, 10);
                    break;
                case Clef.Bass:
                    clef.RenderTransform = new ScaleTransform(.14 * scale, .14 * scale);
                    clef.Data = Geometry.Parse(Engraving.BassClef);
                    Canvas.SetTop(clef, 1 * scale + additionalTop);
                    Canvas.SetLeft(clef, 10);
                    break;
            }

            canvas.Children.Add(clef);
        }

        public static double DrawKey(Canvas canvas, MusicalKey musicalKey, Clef clef)
        {
            var scale = 1;
            var additionalTop = 0;
            var indent = 30;

            if (canvas.GetType() == typeof(UIMeasure))
            {
                scale = 5;
                additionalTop = 45;
                indent = ((UIMeasure)canvas).Indent - 60;
                ((UIMeasure)canvas).Indent += 200;
            }
            var key = new Path
            {
                Fill = Brushes.Black,
                RenderTransform = new ScaleTransform(.32 * scale, .32 * scale)
            };

            //if ((musicalKey.Pitch == Pitch.C        && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.A       && musicalKey.Gender == Gender.Minor))
            //key.Data = Geometry.Parse(Engraving.CMajor);
            if ((musicalKey.Pitch == Pitch.G && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.E && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.GMajor);
            else if ((musicalKey.Pitch == Pitch.D && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.B && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.DMajor);
            else if ((musicalKey.Pitch == Pitch.A && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.FSharp && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.AMajor);
            else if ((musicalKey.Pitch == Pitch.E && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.CSharp && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.EMajor);
            else if ((musicalKey.Pitch == Pitch.B && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.GSharp && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.BMajor);
            else if ((musicalKey.Pitch == Pitch.FSharp && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.DSharp && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.FSharpMajor);
            else if ((musicalKey.Pitch == Pitch.CSharp && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.ASharp && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.CSharpMajor);
            else if ((musicalKey.Pitch == Pitch.F && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.D && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.FMajor);
            else if ((musicalKey.Pitch == Pitch.BFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.G && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.BFlatMajor);
            else if ((musicalKey.Pitch == Pitch.EFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.C && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.EFlatMajor);
            else if ((musicalKey.Pitch == Pitch.AFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.F && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.AFlatMajor);
            else if ((musicalKey.Pitch == Pitch.DFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.BFlat && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.DFlatMajor);
            else if ((musicalKey.Pitch == Pitch.GFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.EFlat && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.GFlatMajor);
            else if ((musicalKey.Pitch == Pitch.CFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.AFlat && musicalKey.Gender == Gender.Minor))
                key.Data = Geometry.Parse(Engraving.CFlatMajor);

            switch (clef)
            {
                case Clef.Treble:
                    Canvas.SetTop(key, -11 * scale + additionalTop);
                    break;
                case Clef.Bass:
                    Canvas.SetTop(key, -4 * scale + additionalTop);
                    break;
            }
            Canvas.SetLeft(key, indent);
            canvas.Children.Add(key);
            return key.ActualWidth;
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