using Model;
using Model.Sections;
using Model.View;
using Musicista.Exceptions;
using Musicista.UI.MeasureElements;
using Musicista.UI.TextElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Duration = Model.Sections.Notes.Duration;
using Style = Model.View.Style;

namespace Musicista.UI
{
    public static class UIHelper
    {
        private static List<UIMeasure> _selectedUIMeasures = new List<UIMeasure>();
        public static SolidColorBrush SelectColor = new SolidColorBrush(Color.FromArgb(150, 135, 206, 235));
        private static List<UISymbol> _selectedUISymbols = new List<UISymbol>();

        public static bool SelectionModeIsMeasures
        {
            get { return SelectedUIMeasures.Count > 0; }
        }

        public static List<UIMeasure> SelectedUIMeasures
        {
            get { return _selectedUIMeasures; }
            set { _selectedUIMeasures = value; }
        }

        public static List<UISymbol> SelectedUISymbols
        {
            get { return _selectedUISymbols; }
            set { _selectedUISymbols = value; }
        }

        public static List<UIPage> DrawPiece(Piece piece, bool resetMeasuresPerSystem = false)
        {
            var currentPage = new UIPage { Piece = piece };
            var pageList = new List<UIPage> { currentPage };

            if (!String.IsNullOrEmpty(piece.Meta.Title))
                currentPage.Title = new UITitle(currentPage);

            currentPage.Composer = new UIComposer(currentPage);

            if (piece.Sections == null || piece.Sections.Count <= 0)
                return pageList;

            foreach (var section in piece.Sections)
            {
                if (section.Movements != null && section.Movements.Count > 1)
                    MessageBox.Show("This file has multiple movements, which is great, because that's one of the advantages of the musicista-fileformat. " +
                                    "However, the version of the Musicista-App you are using does not support multiple movements and will just put everything together. " +
                                    "You'll get an automatic update as soon as the app supports multiple movements!", "Info", MessageBoxButton.OK);
                if (section.Movements != null && section.Movements.Count > 0)
                    foreach (var movement in section.Movements)
                    {
                        if (piece.Style == null) piece.Style = new Style();
                        if (piece.Style.MetricForMovement == null) piece.Style.MetricForMovement = new List<Metrics>();

                        var metrics = piece.Style.MetricForMovement.FirstOrDefault(item => item.MovementNumber == movement.Number);
                        if (metrics == null)
                        {
                            metrics = new Metrics
                            {
                                MeasuresPerSystemThreshold = 60,
                                MeasuresPerSystem = CalculateMeasuresPerSystem(movement, 60)
                            };
                            piece.Style.MetricForMovement.Add(metrics);
                        }
                        if (resetMeasuresPerSystem)
                            metrics.MeasuresPerSystem = CalculateMeasuresPerSystem(movement, metrics.MeasuresPerSystemThreshold);

                        var systemNumber = 0;

                        if (movement.Segments != null && movement.Segments.Count > 0)
                            foreach (var segment in movement.Segments)
                                if (segment.Passages != null && segment.Passages.Count > 0)
                                    foreach (var passage in segment.Passages)
                                        if (passage.MeasureGroups != null && passage.MeasureGroups.Count > 0)
                                        {
                                            var maxStaves = passage.MeasureGroups.Select(measure => measure.Measures.Count).Max();

                                            foreach (var measureGroup in passage.MeasureGroups)
                                            {
                                                // pagebreak if page is full
                                                if (currentPage.Systems.Count > 0 && currentPage.Systems.Last().MeasureGroups.Count > metrics.MeasuresPerSystem[systemNumber - 1] - 1
                                                    &&
                                                    currentPage.Systems.Last().Bottom >
                                                    (currentPage.Height - (currentPage.Systems.Last().CalculatedHeight + 80)))
                                                {
                                                    currentPage = new UIPage();
                                                    pageList.Add(currentPage);
                                                }

                                                // systembreak and new System with lines (staves) every 4 measures
                                                if (currentPage.Systems.Count == 0 ||
                                                    currentPage.Systems.Last().MeasureGroups.Count >= metrics.MeasuresPerSystem[systemNumber - 1])
                                                {
                                                    systemNumber++;
                                                    currentPage.Systems.Add(new UISystem(currentPage, maxStaves, systemNumber, metrics.MeasuresPerSystem[systemNumber - 1]));
                                                }

                                                // Now draw the measures and notes
                                                // Create UIMeasureGroup
                                                var uiMeasureGroup = new UIMeasureGroup(currentPage.Systems.Last(), measureGroup);
                                                uiMeasureGroup.Draw();
                                            }
                                        }
                    }
            }
            return pageList;
        }

        public static List<int> CalculateMeasuresPerSystem(Movement movement, int threshold)
        {
            // 1. Step: calculate the fill-degree of each measureGroup (determined by its "fullest" measure). 
            // Notes are grouped in categories and have different weights.
            var fillDegree = new List<int>();
            foreach (var measureGroup in movement.Segments.SelectMany(seg => seg.Passages.SelectMany(pas => pas.MeasureGroups)))
            {
                var measureDegrees = new List<int>();
                foreach (var measure in measureGroup.Measures)
                {
                    var degree = 8 * measure.Symbols.Count(symbol => symbol.Duration < Duration.SixteenthDoubleDotted);
                    degree += 4 * measure.Symbols.Count(symbol => symbol.Duration >= Duration.SixteenthDoubleDotted && symbol.Duration < Duration.Quarter);
                    degree += 2 * measure.Symbols.Count(symbol => symbol.Duration >= Duration.Quarter && symbol.Duration < Duration.Whole);
                    degree += 1 * measure.Symbols.Count(symbol => symbol.Duration >= Duration.Whole);
                    measureDegrees.Add(degree);
                }
                fillDegree.Add(measureDegrees.Max());
            }

            // 2. Step: Group the MeasureGroups according to their fill-degree, aim for a degree of 60 (six quarters + 12 eigths, or six quarters, two halves, four eigths).
            // At least take to measures
            var result = new List<int>();
            var counter = 0;
            var currentSystemDegree = 0;
            foreach (var degree in fillDegree)
            {
                if ((currentSystemDegree > threshold || currentSystemDegree + degree > threshold + 10) && counter > 1)
                {
                    result.Add(counter);
                    counter = 0;
                    currentSystemDegree = 0;
                }
                counter++;
                currentSystemDegree += degree + counter * 2; // add counter * 2 to limit the amount of measures
            }

            // Add the last measureGroups either to the last system or to a new system
            if (counter == 1)
                result[result.Count - 1] += 1;
            else if (counter > 1)
                result.Add(counter);

            return result;
        }

        /// <summary>
        ///     Converts a list of int to a string while concatenating adjecent number, like so: "1, 3-4, 6"
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
        ///     Finds the given start- and end-NoteReferences, sets their background-color
        ///     (and that of all the symbols in between) to blue and adds them to the SelectedUISymbols-list.
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
        ///     Returns the instance of the symbol that the given NoteReference points to, or null
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public static UISymbol FindUISymbol(NoteReference note)
        {
            return MainWindow.PageList.SelectMany(page => page.Systems.SelectMany(system => system.MeasureGroups))
                .Where(uiMeasureGroup => uiMeasureGroup.InnerMeasureGroup.MeasureNumber == note.MeasureNumber)
                .SelectMany(uiMeasureGroup => uiMeasureGroup.UIMeasures[note.StaffNumber].Symbols)
                .FirstOrDefault(uiSymbol => Math.Abs(uiSymbol.Symbol.Beat - note.Beat) < 0.01);
        }

        /// <summary>
        ///     Goes through all selected measures and symbols, restores their background color and clears the
        ///     SelectedUIMeasure/Symbol-lists
        /// </summary>
        public static void UnselectAll()
        {
            foreach (var uiMeasure in SelectedUIMeasures)
                uiMeasure.Background = Brushes.Transparent;
            SelectedUIMeasures.Clear();

            foreach (var uiSymbol in SelectedUISymbols)
                uiSymbol.Background = Brushes.Transparent;
            SelectedUISymbols.Clear();

            MainWindow.TinyNotationTextBox.Text = "";
        }
    }
}