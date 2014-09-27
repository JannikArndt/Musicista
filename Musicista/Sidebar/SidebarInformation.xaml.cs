using Model;
using Model.Meta;
using Model.Sections;
using Model.Sections.Attributes;
using Model.Sections.Notes;
using Musicista.UI;
using Musicista.UI.MeasureElements;
using Musicista.View;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Duration = Model.Sections.Notes.Duration;

namespace Musicista.Sidebar
{
    /// <summary>
    ///     Interaction logic for SidebarInformation.xaml
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
            var uiMeasure = uiObject as UIMeasure;
            if (uiMeasure != null)
                ShowMeasure(uiMeasure);
            var uiSymbol = uiObject as UISymbol;
            if (uiSymbol != null)
                ShowSymbol(uiSymbol);
        }

        private void ShowSymbol(UISymbol uiSymbol)
        {
            if (UIHelper.SelectedUISymbols.Count == 1)
            {
                TitleTextBlock.Text = uiSymbol.ToString();
                SidebarPanel.Children.Clear();

                // Draw note
                var selectedPassage = new Passage(UIHelper.SelectedUISymbols.Select(item => item.Symbol));
                SidebarPanel.Children.Add(SidebarHelper.DrawPassage(selectedPassage));

                // Display info about the uiSymbol
                var grid = new GridTable(70);
                grid.AddRowWithTextField("Measure No.", uiSymbol.Symbol.ParentMeasure.ParentMeasureGroup, "MeasureNumber");
                grid.AddRowWithTextField("Beat", uiSymbol.Symbol, "Beat");
                grid.AddRowWithComboBox("Duration", uiSymbol.Symbol, "Duration", Duration.Unknown);
                grid.AddRowWithTextField("Voice", uiSymbol.Symbol, "Voice");
                foreach (var lyric in uiSymbol.Symbol.Lyrics)
                    grid.AddRowWithTextField("Lyrics", lyric, "Text");


                var commentHeading = new TextBlock
                {
                    Text = "Comments",
                    FontSize = 16,
                    TextAlignment = TextAlignment.Center
                };

                // Display Comments
                var commentGrid = new GridTable(70);
                if (MainWindow.CurrentPiece.Comments != null)
                    foreach (var comment in MainWindow.CurrentPiece.Comments.Where(item => item.BelongsToMovement == uiSymbol.Symbol.ParentMeasure.ParentMeasureGroup.ParentPassage.ParentSegment.ParentMovement
                                       && item.NoteReference.PointsToSymbol(uiSymbol.Symbol)))
                        commentGrid.AddRowWithTextField(comment.Author + ":", comment, "CommentText");
                commentGrid.AddRowWithCommentBox(uiSymbol.Symbol);

                SidebarPanel.Children.Add(grid);
                SidebarPanel.Children.Add(commentHeading);
                SidebarPanel.Children.Add(commentGrid);
            }
            else if (UIHelper.SelectedUISymbols.Count > 1)
            {
                TitleTextBlock.Text = "Passage";
                SidebarPanel.Children.Clear();

                // Draw notes
                if (UIHelper.SelectedUISymbols.Count < 40)
                {
                    var selectedPassage = new Passage(UIHelper.SelectedUISymbols.Select(item => item.Symbol));
                    SidebarPanel.Children.Add(SidebarHelper.DrawPassage(selectedPassage));
                }

                var addToThemesButton = new Button
                {
                    Content = "Add to Themes",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 10, 0, 10),
                    Width = 100
                };
                addToThemesButton.Click += AddToThemes;
                SidebarPanel.Children.Add(addToThemesButton);

                ShowParts();
            }
        }

        public void AddToThemes(object sender, RoutedEventArgs routedEventArgs)
        {
            var part = new Part(new Passage(UIHelper.SelectedUISymbols.Select(item => item.Symbol)), UIHelper.SelectedUISymbols.First().Symbol.ParentMeasure.ParentMeasureGroup.ParentPassage.ParentSegment.ParentMovement);
            MainWindow.CurrentPiece.Parts.Add(part);

            if (_partsStack != null)
                SidebarHelper.DrawPartBox(part, _partsStack);
        }

        private void ShowMeasure(UIMeasure uiMeasure)
        {
            if (UIHelper.SelectedUIMeasures.Count == 1)
            {
                TitleTextBlock.Text = uiMeasure.ToString();
                SidebarPanel.Children.Clear();

                // Display selected passage
                if (UIHelper.SelectedUIMeasures.Count < 10)
                {
                    var selectedPassage = new Passage(UIHelper.SelectedUIMeasures.Select(item => item.InnerMeasure));
                    SidebarPanel.Children.Add(SidebarHelper.DrawPassage(selectedPassage));
                }

                // Display info about the uiMeasure
                var grid = new GridTable(60);
                grid.AddRowWithTextField("Instrument", uiMeasure.InnerMeasure.Instrument, "Name");
                grid.AddRowWithComboBox("Clef", uiMeasure.InnerMeasure, "Clef", Clef.Treble);
                grid.AddRowWithTwoComboBoxes("Key", uiMeasure.ParentUIMeasureGroup.InnerMeasureGroup.KeySignature, "Step", "Gender", Step.C, Gender.Major);
                grid.AddRowWithTimeSignature("Time", uiMeasure.ParentUIMeasureGroup.InnerMeasureGroup.TimeSignature);
                grid.AddRowWithCheckbox("Pickup", uiMeasure.ParentUIMeasureGroup.InnerMeasureGroup, "IsPickupMeasure");

                SidebarPanel.Children.Add(grid);
            }
            else if (UIHelper.SelectedUIMeasures.Count > 1)
            {
                TitleTextBlock.Text = "Measures #" + UIHelper.NumbersToString(UIHelper.SelectedUIMeasures.Select(item => item.InnerMeasure.ParentMeasureGroup.MeasureNumber).ToList());
                SidebarPanel.Children.Clear();

                // Display selected passage
                var selectedPassage = new Passage(UIHelper.SelectedUIMeasures.Select(item => item.InnerMeasure));
                SidebarPanel.Children.Add(SidebarHelper.DrawPassage(selectedPassage));

                // Display info about the uiMeasure(s)
                var grid = new GridTable(60);
                var keys = UIHelper.SelectedUIMeasures.Select(item => item.InnerMeasure.ParentMeasureGroup.KeySignature).Distinct().ToList();
                if (keys.Count() == 1)
                    grid.AddRowWithTwoComboBoxes("Key", uiMeasure.ParentUIMeasureGroup.InnerMeasureGroup.KeySignature, "Step", "Gender", Step.C, Gender.Major);
                else
                    grid.AddRowWithReadonlyTextField("Keys", string.Join(", ", keys));


                SidebarPanel.Children.Add(grid);

                ShowParts();
            }
        }

        public void ShowPiece()
        {
            if (MainWindow.CurrentPiece == null)
                return;
            var piece = MainWindow.CurrentPiece;

            TitleTextBlock.DataContext = piece.Meta;
            TitleTextBlock.SetBinding(TextBlock.TextProperty, new Binding("Title"));

            SidebarPanel.Children.Clear();

            var grid = new GridTable(60);
            grid.AddRowWithTextField("Title", MainWindow.CurrentPiece.Meta, "Title");


            foreach (var person in piece.Meta.People.Persons)
                grid.AddRowWithPerson(person.GetType().Name, person);
            grid.AddRowWithAddPerson(piece.Meta.People.Persons);


            grid.AddRowWithComboBox("Epoch", MainWindow.CurrentPiece.Meta, "Epoch", Epoch.Classical);
            grid.AddRowWithComboBox("Form", MainWindow.CurrentPiece.Meta, "Form", Form.Other);

            SidebarPanel.Children.Add(grid);


            var gridView = new GridView
            {
                ColumnHeaderContainerStyle = new Style { TargetType = typeof(GridViewColumnHeader) }
            };
            gridView.ColumnHeaderContainerStyle.Setters.Add(new Setter(VisibilityProperty, Visibility.Collapsed));

            var gridViewColumn1 = new GridViewColumn { DisplayMemberBinding = new Binding("Key") };
            var gridViewColumn2 = new GridViewColumn { DisplayMemberBinding = new Binding("Value") };
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
                    {"Typesetter", piece.Meta.Dates.Engraving.Typesetter},
                    {"Date of typesetting", piece.Meta.Dates.Engraving.Date.ToShortDateString()},
                    {"Copyright", piece.Meta.Copyright},
                    {"Software", piece.Meta.Software},
                    {"Notes", piece.Meta.Notes}
                }
            };
            SidebarPanel.Children.Add(listView);

            ShowParts();
        }

        private StackPanel _partsStack;
        public void ShowParts()
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
                Text = "Parts"
            };

            _partsStack.Children.Add(partsTitle);

            foreach (var part in MainWindow.CurrentPiece.Parts)
                SidebarHelper.DrawPartBox(part, _partsStack);

            SidebarPanel.Children.Add(_partsStack);
        }
    }
}