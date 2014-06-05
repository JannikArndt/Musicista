using Model;
using Model.Meta;
using Musicista.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Musicista.Sidebar
{
    /// <summary>
    /// Interaction logic for SidebarInformation.xaml
    /// </summary>
    public partial class SidebarInformation
    {
        public SidebarInformation()
        {
            InitializeComponent();
        }

        public void ShowUIElement(object uiObject)
        {
            if (uiObject is TextBlock)
                Clicked.Text = (uiObject as TextBlock).Text;
            var measure = uiObject as UIMeasure;
            if (measure != null)
                ShowMeasure(measure);
        }

        private void ShowMeasure(UIMeasure measure)
        {

            TitleTextBlock.Text = measure.ToString();
            SidebarPanel.Children.Clear();

            // Display measure
            var page = new Canvas
            {
                Width = 280,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Top,
                Background = Brushes.White
            };
            var system = new UISystem(page, 0, 0, 0);
            system.Children.Remove(system.BarlineFront);
            var canvas = new UIMeasureGroup(system, 0);
            SidebarPanel.Children.Add(page);
            canvas.Children.Remove(canvas.Barline);

            var newMeasure = new UIMeasure(canvas, 0, 0, measure.InnerMeasure, suppressEventHandlers: true) { Width = 280 };

            foreach (var symbol in measure.InnerMeasure.Symbols)
                if (symbol.GetType() == typeof(Note))
                    new UINote((Note)symbol, newMeasure);
                else if (symbol.GetType() == typeof(Rest))
                    UIHelper.DrawRest((Rest)symbol, newMeasure);

            var instrument = new TextBlock
            {
                Text = "Instrument: " + measure.InnerMeasure.Instrument.Name,
                FontSize = 12
            };
            SidebarPanel.Children.Add(instrument);

        }

        public void ShowPiece()
        {
            if (MainWindow.CurrentPiece == null)
                return;
            var piece = MainWindow.CurrentPiece;

            TitleTextBlock.DataContext = piece;
            TitleTextBlock.SetBinding(TextBlock.TextProperty, new Binding("Title"));


            SidebarPanel.Children.Clear();

            var grid = new GridTable(60);
            grid.AddRowWithTextField("Title", "Title");

            if (piece.ListOfComposers != null && piece.ListOfComposers.Count > 0 && piece.ListOfComposers[0].FullName != null)
                foreach (var composer in piece.ListOfComposers)
                    if (composer.FullName != null)
                        grid.AddRowWithPerson("Composer", composer);

            //grid.AddRowWithComboBox("Opus", "Opus", typeof(OpusNumber));
            grid.AddRowWithComboBox("Epoch", "Epoch", Epoch.Classical);
            grid.AddRowWithComboBox("Form", "Form", Form.Other);


            SidebarPanel.Children.Add(grid);
        }
    }
}
