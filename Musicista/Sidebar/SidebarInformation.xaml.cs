using Model;
using Musicista.UI;
using System.Windows;
using System.Windows.Controls;
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
                    UIHelper.DrawNote((Note)symbol, newMeasure);
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
            TitleTextBlock.Text = piece.Title;
            SidebarPanel.Children.Clear();

            var grid = new Grid { Margin = new Thickness(10) };
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            var tbTitle = new TextBlock { Text = "Title" };
            Grid.SetRow(tbTitle, 0);
            Grid.SetColumn(tbTitle, 0);

            var txTitle = new TextBox { Text = piece.Title };
            Grid.SetRow(txTitle, 0);
            Grid.SetColumn(txTitle, 1);

            var tbComposer = new TextBlock { Text = "Composer" };
            Grid.SetRow(tbComposer, 1);
            Grid.SetColumn(tbComposer, 0);

            var txComposer = new TextBox();
            if (piece.ListOfComposers != null && piece.ListOfComposers.Count > 0 && piece.ListOfComposers[0].FullName != null)
                txComposer.Text = piece.ListOfComposers[0].FullName;
            Grid.SetRow(txComposer, 1);
            Grid.SetColumn(txComposer, 1);

            grid.Children.Add(tbTitle);
            grid.Children.Add(txTitle);
            grid.Children.Add(tbComposer);
            grid.Children.Add(txComposer);

            SidebarPanel.Children.Add(grid);
        }
    }
}
