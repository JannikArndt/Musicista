
using Model;
using Model.Extensions;
using Model.Instruments;
using Model.Sections.Notes;
using Musicista.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Musicista.Sidebar
{
    /// <summary>
    /// Interaction logic for SidebarAlgorithms.xaml
    /// </summary>
    public partial class SidebarAlgorithms
    {
        public SidebarAlgorithms()
        {
            InitializeComponent();

            MouseEnter += (sender, args) =>
            {
                if (MainWindow.CurrentPiece != null)
                {
                    DoublingInstrument1.ItemsSource = MainWindow.CurrentPiece.Instruments;
                    DoublingInstrument2.ItemsSource = MainWindow.CurrentPiece.Instruments;
                }
            };
        }



        //private void ClickAnalyzeChords(object sender, RoutedEventArgs e)
        //{
        //    foreach (var measureGroup in MainWindow.CurrentPiece.MeasureGroups)
        //        BasicAlgorithms.HarmonicAnalysis(measureGroup);
        //}

        //private void ClickAnalyzeSelectedChords(object sender, RoutedEventArgs e)
        //{
        //    var selectedNotes = UIHelper.SelectedUISymbols.Select(uiNote => uiNote.Symbol).OfType<Note>().ToList();
        //    var allNotes = selectedNotes.SelectMany(note => note.ParentMeasure.ParentMeasureGroup.GetSymbolsAt(note.Beat).OfType<Note>()).ToList();
        //    AnalyzeSelectedResult.Text = "" + BasicAlgorithms.GetChordFromNotes(allNotes);
        //}

        //private void AddAnalysisText(object sender, RoutedEventArgs e)
        //{
        //    var note = UIHelper.SelectedUISymbols.FirstOrDefault(item => item.GetType() == typeof(UINote));
        //    if (note == null) return;
        //    var measureNumber = note.Symbol.ParentMeasure.ParentMeasureGroup.MeasureNumber;
        //    var measureGroup = MainWindow.CurrentPiece.MeasureGroups.FirstOrDefault(item => item.MeasureNumber == measureNumber);

        //    if (measureGroup != null)
        //        measureGroup.Analysis.Add(new NoteAttribute(note.Symbol.Beat, TextToAdd.Text, measureGroup));
        //}

        /// <summary>
        /// Calls the FindDoublings Algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindDoublingsClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var doublings = Algorithms.Doublings.FindDoublings.Run(MainWindow.CurrentPiece, (Instrument)DoublingInstrument1.SelectedItem, (Instrument)DoublingInstrument2.SelectedItem);
                ShowParts(doublings);
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(@"Error, the " + exception.Message + " was not provided.", "Error");
            }

        }

        /// <summary>
        /// Extracts the lyrics from the selected symbols
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtractLyricsClick(object sender, RoutedEventArgs e)
        {
            if (UIHelper.SelectedUISymbols.IsNullOrEmpty())
            {
                MessageBox.Show(@"You have not selected any notes.", "Error");
                return;
            }

            var results = new List<Lyric>();
            // Handle incomplete first word
            var first = UIHelper.SelectedUISymbols.First().Symbol;
            if (first.Lyrics.Any() && first.Lyrics[0].Syllabic != Syllabic.Begin && first.Lyrics[0].Syllabic != Syllabic.Single)
            {
                var predecessor = first.Previous;
                while (predecessor.Lyrics[0].Syllabic != Syllabic.Begin)
                {
                    results.Add(predecessor.Lyrics[0]);
                    predecessor = predecessor.Previous;
                }
                results.Reverse(); // since the lyrics were added in the reverse order 
            }
            // Handle selected symbols
            foreach (var uiSymbol in UIHelper.SelectedUISymbols)
                if (uiSymbol.Symbol != null && uiSymbol.Symbol.Lyrics != null && uiSymbol.Symbol.Lyrics.Any())
                    results.Add(uiSymbol.Symbol.Lyrics[0]);

            // Handle incomplete last word
            var last = UIHelper.SelectedUISymbols.Last().Symbol;
            if (last.Lyrics.Any() && last.Lyrics[0].Syllabic != Syllabic.End && last.Lyrics[0].Syllabic != Syllabic.Single)
            {
                var follower = last.Next;
                while (follower.Lyrics[0].Syllabic != Syllabic.End)
                {
                    results.Add(follower.Lyrics[0]);
                    follower = follower.Next;
                }
            }

            // Add spaces after words
            var text = "";
            foreach (var lyric in results)
                if (lyric.Syllabic == Syllabic.End || lyric.Syllabic == Syllabic.Single)
                    text += lyric.Text + " ";
                else
                    text += lyric.Text;

            LyricsTextBox.Text = text;
        }

        private StackPanel _partsStack;
        /// <summary>
        /// Shows the given list of parts (most likely a result from an algorithm) in the sidebar
        /// </summary>
        /// <param name="parts"></param>
        public void ShowParts(List<Part> parts)
        {
            if (SidebarPanel.Children.Contains(_partsStack))
                SidebarPanel.Children.Remove(_partsStack);

            _partsStack = new StackPanel
            {
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Bottom
            };

            var partsTitle = new TextBlock
            {
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0),
                Text = "Results"
            };

            _partsStack.Children.Add(partsTitle);


            foreach (var part in parts)
                SidebarHelper.DrawPartBox(part, _partsStack);

            SidebarPanel.Children.Add(_partsStack);
        }
    }
}
