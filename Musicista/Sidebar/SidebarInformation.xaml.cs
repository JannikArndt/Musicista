using Model;
using Model.Meta;
using Musicista.UI;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

        private void ShowMeasure(UIMeasure uiMeasure)
        {
            if (UIHelper.SelectedUIMeasures.Count == 1)
            {
                TitleTextBlock.Text = uiMeasure.ToString();
                SidebarPanel.Children.Clear();

                // Display uiMeasure
                var page = new UIPage
                {
                    Width = 280,
                    Height = 50,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Effect = null
                };
                var system = new UISystem(page, 0, 0, 0) { MeasuresInSystem = 1 };
                system.Children.Remove(system.BarlineFront);
                var canvas = new UIMeasureGroup(system, 0);
                canvas.Children.Remove(canvas.Barline);

                SidebarPanel.Children.Add(page);

                var newMeasure = new UIMeasure(canvas, 0, 0, uiMeasure.InnerMeasure, suppressEventHandlers: true);

                // Clef and key
                UIHelper.DrawClef(newMeasure, uiMeasure.InnerMeasure.Clef);
                UIHelper.DrawKey(newMeasure, uiMeasure.InnerMeasure.ParentMeasureGroup.KeySignature, uiMeasure.InnerMeasure.Clef);

                // Notes and rests
                foreach (var symbol in uiMeasure.InnerMeasure.Symbols)
                    if (symbol.GetType() == typeof(Note))
                        new UINote((Note)symbol, newMeasure);
                    else if (symbol.GetType() == typeof(Rest))
                        new UIRest((Rest)symbol, newMeasure);

                // Display info about the uiMeasure
                var grid = new GridTable(60);
                grid.AddRowWithTextField("Instrument", uiMeasure.InnerMeasure.Instrument, "Name");
                grid.AddRowWithComboBox("Clef", uiMeasure.InnerMeasure, "Clef", Clef.Treble);
                grid.AddRowWithTwoComboBoxes("Key", uiMeasure.ParentMeasureGroup.InnerMeasureGroup.KeySignature, "Pitch", "Gender", Pitch.C, Gender.Major);
                grid.AddRowWithTimeSignature("Time", uiMeasure.ParentMeasureGroup.InnerMeasureGroup.TimeSignature);

                SidebarPanel.Children.Add(grid);
            }
            else if (UIHelper.SelectedUIMeasures.Count > 1)
            {
                TitleTextBlock.Text = "Measures #" + UIHelper.NumbersToString(UIHelper.SelectedUIMeasures.Select(item => item.InnerMeasure.ParentMeasureGroup.MeasureNumber).ToList());
                SidebarPanel.Children.Clear();

                // Display info about the uiMeasure(s)
                var grid = new GridTable(60);
                var keys = UIHelper.SelectedUIMeasures.Select(item => item.InnerMeasure.ParentMeasureGroup.KeySignature).Distinct().ToList();
                if (keys.Count() == 1)
                    grid.AddRowWithTwoComboBoxes("Key", uiMeasure.ParentMeasureGroup.InnerMeasureGroup.KeySignature, "Pitch", "Gender", Pitch.C, Gender.Major);
                else
                    grid.AddRowWithReadonlyTextField("Keys", string.Join(", ", keys));


                SidebarPanel.Children.Add(grid);
            }
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
            grid.AddRowWithTextField("Title", MainWindow.CurrentPiece, "Title");

            if (piece.ListOfComposers != null && piece.ListOfComposers.Count > 0 && piece.ListOfComposers[0].FullName != null)
                foreach (var composer in piece.ListOfComposers)
                    if (composer.FullName != null)
                        grid.AddRowWithPerson("Composer", composer);

            //grid.AddRowWithComboBox("Opus", "Opus", typeof(OpusNumber));
            grid.AddRowWithComboBox("Epoch", MainWindow.CurrentPiece, "Epoch", Epoch.Classical);
            grid.AddRowWithComboBox("Form", MainWindow.CurrentPiece, "Form", Form.Other);


            SidebarPanel.Children.Add(grid);




            var gridView = new GridView
            {
                ColumnHeaderContainerStyle = new Style
                {
                    TargetType = typeof(GridViewColumnHeader),
                }
            };
            gridView.ColumnHeaderContainerStyle.Setters.Add(new Setter(VisibilityProperty, Visibility.Collapsed));

            var gridViewColumn1 = new GridViewColumn
            {
                DisplayMemberBinding = new Binding("Key"),
            };
            var gridViewColumn2 = new GridViewColumn
            {
                DisplayMemberBinding = new Binding("Value"),
            };
            gridView.Columns.Add(gridViewColumn1);
            gridView.Columns.Add(gridViewColumn2);

            var listView = new ListView
            {
                Margin = new Thickness(0, 10, 0, 0),
                Width = 280,
                HorizontalAlignment = HorizontalAlignment.Center,
                View = gridView,
                ItemsSource = new Dictionary<string, string>
                {
                    {"Typesetter", piece.TypeSetter},
                    {"Date of typesetting", piece.DateOfTypesetting.ToShortDateString()},
                    {"Copyright", piece.Copyright},
                    {"Software", piece.Software},
                    {"Notes", piece.Notes}
                }
            };
            SidebarPanel.Children.Add(listView);
        }
    }
}
