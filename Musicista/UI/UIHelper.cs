using Model;
using Model.Meta;
using Musicista.Exceptions;
using Musicista.UI.TextElements;
using System;
using System.Collections.Generic;
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
        private static List<UIMeasure> _selectedUIMeasures = new List<UIMeasure>();
        public static SolidColorBrush SelectColor = new SolidColorBrush(Color.FromArgb(150, 135, 206, 235));
        public static bool SelectionModeIsMeasures { get { return SelectedUIMeasures.Count > 0; } }

        public static List<UIMeasure> SelectedUIMeasures
        {
            get { return _selectedUIMeasures; }
            set { _selectedUIMeasures = value; }
        }

        private static List<UISymbol> _selectedUISymbols = new List<UISymbol>();

        public static List<UISymbol> SelectedUISymbols
        {
            get { return _selectedUISymbols; }
            set { _selectedUISymbols = value; }
        }

        public static List<UIPage> DrawPiece(Piece piece)
        {
            var currentPage = new UIPage { Piece = piece };
            var pageList = new List<UIPage> { currentPage };

            if (!String.IsNullOrEmpty(piece.Title))
                currentPage.Title = new UITitle(currentPage);

            if (piece.ListOfComposers != null && piece.ListOfComposers.Count > 0)
                currentPage.Composer = new UIComposer(currentPage);

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

                                            foreach (var measureGroup in passage.ListOfMeasureGroups)
                                            {
                                                // pagebreak if page is full
                                                if (currentPage.Systems.Count > 0 && currentPage.Systems.Last().MeasureGroups.Count > 3
                                                    && currentPage.Systems.Last().Bottom > (currentPage.Height - (currentPage.Systems.Last().CalculatedHeight + 50)))
                                                {
                                                    currentPage = new UIPage();
                                                    pageList.Add(currentPage);
                                                }

                                                // systembreak and new System with lines (staves) every 4 measures
                                                if (currentPage.Systems.Count == 0 || currentPage.Systems.Last().MeasureGroups.Count >= currentPage.Systems.Last().MeasuresInSystem)
                                                    currentPage.Systems.Add(new UISystem(currentPage, maxStaves));

                                                // Now draw the measures and notes
                                                DrawMeasureGroup(currentPage.Systems.Last(), measureGroup);
                                            }
                                        }
            return pageList;
        }

        public static void DrawMeasureGroup(UISystem system, MeasureGroup measureGroup, bool hasMouseDown = true)
        {
            if (measureGroup == null || measureGroup.Measures == null || measureGroup.Measures.Count <= 0)
                return;

            // Create UIMeasureGroup
            var uiMeasureGroup = new UIMeasureGroup(system, measureGroup);

            // Fill UIMeasureGroup.Measures with UIMeasures
            for (var part = 0; part < measureGroup.Measures.Count; part++)
                DrawMeasure(uiMeasureGroup, measureGroup.Measures[part], part + 1, hasMouseDown);

            // set connecting barlines
            if (uiMeasureGroup.Measures.Count > 0)
                uiMeasureGroup.Barline.Y2 = Canvas.GetTop(uiMeasureGroup.Measures.Last()) + 36;
        }

        public static void DrawMeasure(UIMeasureGroup uiMeasureGroup, Measure measure, int part, bool hasMouseDown = true)
        {
            if (measure.Symbols == null || measure.Symbols.Count <= 0)
                return;

            var measureGroup = uiMeasureGroup.InnerMeasureGroup;

            var newMeasure = new UIMeasure(uiMeasureGroup, part, measure, hasMouseDown: hasMouseDown);
            uiMeasureGroup.Measures.Add(newMeasure);

            // Draw clef changes
            if (measure.Previous == null || !Equals(measure.Clef, measure.Previous.Clef) || uiMeasureGroup.ParentSystem.MeasureGroups.IndexOf(uiMeasureGroup) == 0)
                newMeasure.Indent += DrawClef(newMeasure, measure.Clef);

            // Draw key signature changes
            if (measureGroup.Previous == null || !Equals(measureGroup.KeySignature, measureGroup.Previous.KeySignature) || uiMeasureGroup.ParentSystem.MeasureGroups.IndexOf(uiMeasureGroup) == 0)
                newMeasure.Indent += DrawKey(newMeasure, measureGroup.KeySignature, measure.Clef);

            // Draw meter changes
            if (measureGroup.Previous == null || !Equals(measureGroup.Previous.TimeSignature, measureGroup.TimeSignature))
                newMeasure.Indent += DrawTimeSignature(newMeasure, measureGroup.TimeSignature);

            // If the width is smaller than the indent, there is no room for any notes. Return without drawing
            if (newMeasure.Width - newMeasure.Indent < 1)
                return;

            // Draw tied notes
            if (newMeasure.PreviousUIMeasure != null)
                foreach (var symbol in newMeasure.PreviousUIMeasure.TiedNotes.OfType<Note>())
                    new UINote(symbol, newMeasure, hasMouseDown, true);

            // Draw notes
            foreach (var symbol in measure.Symbols)
                if (symbol.GetType() == typeof(Note))
                    new UINote((Note)symbol, newMeasure, hasMouseDown);
                else if (symbol.GetType() == typeof(Rest))
                    new UIRest((Rest)symbol, newMeasure, hasMouseDown);
        }

        public static double DrawClef(UIMeasure uiMeasure, Clef clefType)
        {
            var clef = new Path
            {
                Fill = Brushes.Black,
            };

            switch (clefType)
            {
                case Clef.Treble:
                    clef.RenderTransform = new ScaleTransform(2.5, 2.5);
                    clef.Data = Geometry.Parse(Engraving.TrebleClef);
                    Canvas.SetTop(clef, -5);
                    break;
                case Clef.Bass:
                    clef.RenderTransform = new ScaleTransform(.7, .7);
                    clef.Data = Geometry.Parse(Engraving.BassClef);
                    Canvas.SetTop(clef, 50);
                    break;
            }

            Canvas.SetLeft(clef, uiMeasure.Indent);
            uiMeasure.Children.Add(clef);

            return 120;
        }

        public static double DrawKey(UIMeasure uiMeasure, MusicalKey musicalKey, Clef clef)
        {
            var key = new Path
            {
                Fill = Brushes.Black,
                RenderTransform = new ScaleTransform(1.6, 1.6)
            };
            var width = .0;
            if ((musicalKey.Pitch == Pitch.G && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.E && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.GMajor); width = 60; }
            else if ((musicalKey.Pitch == Pitch.D && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.B && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.DMajor); width = 90; }
            else if ((musicalKey.Pitch == Pitch.A && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.FSharp && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.AMajor); width = 120; }
            else if ((musicalKey.Pitch == Pitch.E && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.CSharp && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.EMajor); width = 150; }
            else if ((musicalKey.Pitch == Pitch.B && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.GSharp && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.BMajor); width = 180; }
            else if ((musicalKey.Pitch == Pitch.FSharp && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.DSharp && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.FSharpMajor); width = 210; }
            else if ((musicalKey.Pitch == Pitch.CSharp && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.ASharp && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.CSharpMajor); width = 260; }
            else if ((musicalKey.Pitch == Pitch.F && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.D && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.FMajor); width = 60; }
            else if ((musicalKey.Pitch == Pitch.BFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.G && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.BFlatMajor); width = 120; }
            else if ((musicalKey.Pitch == Pitch.EFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.C && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.EFlatMajor); width = 180; }
            else if ((musicalKey.Pitch == Pitch.AFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.F && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.AFlatMajor); width = 210; }
            else if ((musicalKey.Pitch == Pitch.DFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.BFlat && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.DFlatMajor); width = 240; }
            else if ((musicalKey.Pitch == Pitch.GFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.EFlat && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.GFlatMajor); width = 270; }
            else if ((musicalKey.Pitch == Pitch.CFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.AFlat && musicalKey.Gender == Gender.Minor))
            { key.Data = Geometry.Parse(Engraving.CFlatMajor); width = 300; }

            switch (clef)
            {
                case Clef.Treble:
                    Canvas.SetTop(key, -10);
                    break;
                case Clef.Bass:
                    Canvas.SetTop(key, 25);
                    break;
            }
            Canvas.SetLeft(key, uiMeasure.Indent);
            uiMeasure.Children.Add(key);

            return width;
        }

        public static double DrawTimeSignature(UIMeasure uiMeasure, TimeSignature timeSignature)
        {
            if (timeSignature.IsCommon || timeSignature.IsCutCommon)
            {
                var sign = new Path
                {
                    Fill = Brushes.Black,
                    RenderTransform = new ScaleTransform(2.2, 2.2),
                    Data = timeSignature.IsCommon ? Geometry.Parse(Engraving.CommonTime) : Geometry.Parse(Engraving.CutTime)
                };
                Canvas.SetTop(sign, 50);
                Canvas.SetLeft(sign, uiMeasure.Indent);
                uiMeasure.Children.Add(sign);
            }
            else
            {
                var meter1 = new TextBlock
                {
                    FontSize = 82,
                    TextAlignment = TextAlignment.Center,
                    FontWeight = FontWeights.Bold,
                    Text = timeSignature.Beats.ToString(CultureInfo.InvariantCulture)
                };
                var meter2 = new TextBlock
                {
                    FontSize = 82,
                    TextAlignment = TextAlignment.Center,
                    FontWeight = FontWeights.Bold,
                    Text = timeSignature.BeatUnit.ToString(CultureInfo.InvariantCulture)
                };
                Canvas.SetTop(meter1, 18);
                Canvas.SetLeft(meter1, uiMeasure.Indent);
                Canvas.SetTop(meter2, 80);
                Canvas.SetLeft(meter2, uiMeasure.Indent);
                uiMeasure.Children.Add(meter1);
                uiMeasure.Children.Add(meter2);
            }
            return 80;
        }

        /// <summary>
        /// Converts a list of int to a string while concatenating adjecent number, like so: "1, 3-4, 6"
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string NumbersToString(List<int> numbers)
        {
            // from http://stackoverflow.com/a/13628257/1507481
            numbers.Sort();
            var result = "";
            var start = numbers[0]; // track start and end
            var end = start;
            for (var i = 1; i < numbers.Count; i++)
            {
                // as long as entries are consecutive, move end forward
                if (numbers[i] == (numbers[i - 1] + 1))
                    end = numbers[i];
                else
                {
                    // when no longer consecutive, add group to result
                    // depending on whether start=end (single item) or not
                    if (start == end)
                        result += start + ",";
                    else
                        result += start + "-" + end + ",";

                    start = end = numbers[i];
                }
            }

            // handle the final group
            if (start == end)
                result += start;
            else
                result += start + "-" + end;

            return result;
        }

        /// <summary>
        /// Finds the given start- and end-NoteReferences, sets their background-color 
        /// (and that of all the symbols in between) to blue and adds them to the SelectedUISymbols-list.
        /// </summary>
        /// <param name="start">The first note to be selected</param>
        /// <param name="end">The last note to be selected</param>
        public static void SelectPassageInScore(NoteReference start, NoteReference end)
        {
            UnselectAll();

            var firstNote = FindUISymbol(start);
            var lastNote = FindUISymbol(end);
            var next = firstNote;

            if (lastNote == null)
                throw new GUIException("Could not find note in score. Passages may only cover one voice!");

            while (next != null && !Equals(next, lastNote))
            {
                next.Background = SelectColor;
                SelectedUISymbols.Add(next);
                next = next.NextUISymbol;
            }
            lastNote.Background = SelectColor;
            SelectedUISymbols.Add(lastNote);
        }

        /// <summary>
        /// Returns the instance of the symbol that the given NoteReference points to, or null
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public static UISymbol FindUISymbol(NoteReference note)
        {
            foreach (var uiPage in MainWindow.PageList)
            {
                foreach (var uiSystem in uiPage.Systems)
                {
                    foreach (var uiMeasureGroup in uiSystem.MeasureGroups)
                    {
                        if (uiMeasureGroup.InnerMeasureGroup.MeasureNumber == note.MeasureNumber)
                            foreach (var uiSymbol in uiMeasureGroup.Measures[note.StaffNumber].Symbols)
                            {
                                if (Math.Abs(uiSymbol.Symbol.Beat - note.Beat) < 0.01)
                                    return uiSymbol;
                            }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Goes through all selected measures and symbols, restores their background color and clears the SelectedUIMeasure/Symbol-lists
        /// </summary>
        public static void UnselectAll()
        {
            foreach (var uiMeasure in SelectedUIMeasures)
                uiMeasure.Background = Brushes.Transparent;
            SelectedUIMeasures.Clear();

            foreach (var uiSymbol in SelectedUISymbols)
                uiSymbol.Background = Brushes.Transparent;
            SelectedUISymbols.Clear();
        }
    }
}