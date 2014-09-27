
using Algorithms.HarmonicAnalysis;
using Model;
using Model.Instruments;
using Model.Sections.Notes;
using Model.Sections.Notes.Analysis;
using Musicista.UI;
using Musicista.UI.MeasureElements;
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



        private void ClickAnalyzeChords(object sender, RoutedEventArgs e)
        {
            foreach (var measureGroup in MainWindow.CurrentPiece.MeasureGroups)
                BasicAlgorithms.HarmonicAnalysis(measureGroup);
        }

        private void ClickAnalyzeSelectedChords(object sender, RoutedEventArgs e)
        {
            var selectedNotes = UIHelper.SelectedUISymbols.Select(uiNote => uiNote.Symbol).OfType<Note>().ToList();
            var allNotes = selectedNotes.SelectMany(note => note.ParentMeasure.ParentMeasureGroup.GetSymbolsAt(note.Beat).OfType<Note>()).ToList();
            AnalyzeSelectedResult.Text = "" + BasicAlgorithms.GetChordFromNotes(allNotes);
        }

        private void AddAnalysisText(object sender, RoutedEventArgs e)
        {
            var note = UIHelper.SelectedUISymbols.FirstOrDefault(item => item.GetType() == typeof(UINote));
            if (note == null) return;
            var measureNumber = note.Symbol.ParentMeasure.ParentMeasureGroup.MeasureNumber;
            var measureGroup = MainWindow.CurrentPiece.MeasureGroups.FirstOrDefault(item => item.MeasureNumber == measureNumber);

            if (measureGroup != null)
                measureGroup.Analysis.Add(new NoteAttribute(note.Symbol.Beat, TextToAdd.Text, measureGroup));
        }

        private void FindDoublingsClick(object sender, RoutedEventArgs e)
        {
            var doublings = Algorithms.Doublings.FindDoublings.Run(MainWindow.CurrentPiece, (Instrument)DoublingInstrument1.SelectedItem, (Instrument)DoublingInstrument2.SelectedItem);
            ShowParts(doublings);
        }

        private StackPanel _partsStack;
        public void ShowParts(List<Part> parts)
        {
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
