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
            if (uiObject is UIMeasure)
                ShowMeasure((UIMeasure)uiObject);
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

            foreach (var symbol in measure.InnerMeasure.ListOfSymbols)
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
    }
}
