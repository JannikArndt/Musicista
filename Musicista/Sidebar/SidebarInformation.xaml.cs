using Model;
using Model.Meta;
using Musicista.Exceptions;
using Musicista.UI;
using Musicista.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

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
                SidebarPanel.Children.Add(DrawPassage(selectedPassage));

                // Display info about the uiSymbol
                var grid = new GridTable(70);
                grid.AddRowWithTextField("Measure No.", uiSymbol.Symbol.ParentMeasure.ParentMeasureGroup, "MeasureNumber");
                grid.AddRowWithTextField("Beat", uiSymbol.Symbol, "Beat");
                grid.AddRowWithComboBox("Duration", uiSymbol.Symbol, "Duration", Model.Duration.unknown);
                grid.AddRowWithTextField("Voice", uiSymbol.Symbol, "Voice");
                grid.AddRowWithTextField("Text", uiSymbol.Symbol, "Text");


                SidebarPanel.Children.Add(grid);
            }
            else if (UIHelper.SelectedUISymbols.Count > 1)
            {
                TitleTextBlock.Text = "Passage";
                SidebarPanel.Children.Clear();

                // Draw notes
                if (UIHelper.SelectedUISymbols.Count < 40)
                {
                    var selectedPassage = new Passage(UIHelper.SelectedUISymbols.Select(item => item.Symbol));
                    SidebarPanel.Children.Add(DrawPassage(selectedPassage));
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
            var part = new Part(new Passage(UIHelper.SelectedUISymbols.Select(item => item.Symbol)));
            MainWindow.CurrentPiece.Parts.Add(part);

            if (_partsStack != null)
                DrawPartBox(part, _partsStack);
        }

        private UIPage DrawPassage(Passage passage)
        {
            var page = new UIPage(hasMouseDown: false)
            {
                Width = 280,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                Effect = null,
                Settings = new UISettings
                {
                    MarginTop = 10,
                    MarginBelowTitle = 0,
                    StaffSpacing = 0,
                    SystemSpacing = 0,
                    SystemMarginLeft = 0,
                    SystemMarginRight = 0
                }
            };

            page.Systems.Add(new UISystem(page, 1) { MeasuresInSystem = passage.ListOfMeasureGroups.Count });

            foreach (var measureGroup in passage.ListOfMeasureGroups)
                UIHelper.DrawMeasureGroup(page.Systems.Last(), measureGroup, hasMouseDown: false);

            return page;
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
                    SidebarPanel.Children.Add(DrawPassage(selectedPassage));
                }

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

                // Display selected passage
                var selectedPassage = new Passage(UIHelper.SelectedUIMeasures.Select(item => item.InnerMeasure));
                SidebarPanel.Children.Add(DrawPassage(selectedPassage));

                // Display info about the uiMeasure(s)
                var grid = new GridTable(60);
                var keys = UIHelper.SelectedUIMeasures.Select(item => item.InnerMeasure.ParentMeasureGroup.KeySignature).Distinct().ToList();
                if (keys.Count() == 1)
                    grid.AddRowWithTwoComboBoxes("Key", uiMeasure.ParentMeasureGroup.InnerMeasureGroup.KeySignature, "Pitch", "Gender", Pitch.C, Gender.Major);
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

            TitleTextBlock.DataContext = piece;
            TitleTextBlock.SetBinding(TextBlock.TextProperty, new Binding("Title"));

            SidebarPanel.Children.Clear();

            var grid = new GridTable(60);
            grid.AddRowWithTextField("Title", MainWindow.CurrentPiece, "Title");

            if (piece.ListOfComposers == null || piece.ListOfComposers.Count == 0)
                piece.ListOfComposers = new List<Composer> { new Composer() };
            foreach (var composer in piece.ListOfComposers)
                grid.AddRowWithPerson("Composer", composer);


            grid.AddRowWithComboBox("Epoch", MainWindow.CurrentPiece, "Epoch", Epoch.Classical);
            grid.AddRowWithComboBox("Form", MainWindow.CurrentPiece, "Form", Form.Other);

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
                    {"Typesetter", piece.TypeSetter},
                    {"Date of typesetting", piece.DateOfTypesetting.ToShortDateString()},
                    {"Copyright", piece.Copyright},
                    {"Software", piece.Software},
                    {"Notes", piece.Notes}
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
                DrawPartBox(part, _partsStack);

            SidebarPanel.Children.Add(_partsStack);
        }

        private void DrawPartBox(Part part, Panel stackPanel)
        {
            if (String.IsNullOrEmpty(part.Name))
                part.Name = "Part #" + (MainWindow.CurrentPiece.Parts.IndexOf(part) + 1);

            var namePanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 4, 0, -18),
                Width = 280,
            };

            var partTitle = new EditableTextBox
            {
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 160,
                DataContext = part
            };
            partTitle.SetBinding(TextBox.TextProperty, new Binding("Name"));

            var partStartAndEnd = new TextBlock
            {
                FontSize = 12,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                Width = 90,
                Text = "(" + part.Start + "-" + part.End + ")"
            };

            var deleteArea = new Border
            {
                Background = Brushes.Transparent,
                Margin = new Thickness(10, 10, 0, 0)
            };
            var deleteButton = new Path
            {
                Data = Geometry.Parse("F0 M 15,7C 15,11 12,15 8,15C 3,15 0,11 0,7C 0,3 3,0 8,0C 12,0 15,3 15,7 Z M 4,2L 8,5L 11,2L 12,4L 9,7L 12,10L 11,12L 8,9L 4,12L 3,10L 6,7L 3,4L 4,2 Z"),
                Fill = Brushes.LightGray,
                RenderTransform = new ScaleTransform(0.9, 0.9)
            };

            var preview = DrawPassage(part.Passage);
            preview.MouseDown += delegate
            {
                try
                {
                    UIHelper.SelectPassageInScore(part.Start, part.End);
                }
                catch (GUIException exception)
                {
                    MessageBox.Show(exception.Message, "Error");
                }
            };
            deleteArea.Child = deleteButton;

            namePanel.Children.Add(partTitle);
            namePanel.Children.Add(partStartAndEnd);
            namePanel.Children.Add(deleteArea);

            deleteArea.MouseEnter += (sender, args) => deleteButton.Fill = Brushes.Gray;
            deleteArea.MouseLeave += (sender, args) => deleteButton.Fill = Brushes.LightGray;
            deleteArea.MouseDown += delegate { DeletePart(part, namePanel, preview); };

            stackPanel.Children.Add(namePanel);
            stackPanel.Children.Add(preview);
        }

        private void DeletePart(Part part, StackPanel namePanel, Canvas preview)
        {
            MainWindow.CurrentPiece.Parts.Remove(part);
            _partsStack.Children.Remove(namePanel);
            _partsStack.Children.Remove(preview);
        }
    }
}