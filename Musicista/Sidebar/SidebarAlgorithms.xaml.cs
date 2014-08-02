
using Model.Sections.Notes;
using Model.Sections.Notes.Analysis;
using Musicista.Algorithms;
using Musicista.UI;
using Musicista.UI.MeasureElements;
using System.Linq;
using System.Windows;

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
        }

        private void ClickAnalyseChords(object sender, RoutedEventArgs e)
        {
            foreach (var measureGroup in MainWindow.CurrentPiece.MeasureGroups)
            {
                BasicAlgorithms.HarmonicAnalysis(measureGroup);
            }
        }

        private void ClickAnalyseSelectedChords(object sender, RoutedEventArgs e)
        {
            var selectedNotes = UIHelper.SelectedUISymbols.Select(uiNote => uiNote.Symbol).OfType<Note>().ToList();
            var allNotes = selectedNotes.SelectMany(note => note.ParentMeasure.ParentMeasureGroup.GetSymbolsAt(note.Beat).OfType<Note>()).ToList();
            AnalyseSelectedResult.Text = "" + BasicAlgorithms.GetChordFromNotes(allNotes);
        }

        private void AddAnalysisText(object sender, RoutedEventArgs e)
        {
            var note = UIHelper.SelectedUISymbols.FirstOrDefault(item => item.GetType() == typeof(UINote));
            if (note == null) return;
            var measureNumber = note.Symbol.ParentMeasure.ParentMeasureGroup.MeasureNumber;
            var measureGroup = MainWindow.CurrentPiece.MeasureGroups.FirstOrDefault(item => item.MeasureNumber == measureNumber);

            measureGroup.Analysis.Add(new NoteAttribute(note.Symbol.Beat, TextToAdd.Text, measureGroup));
        }
    }
}
