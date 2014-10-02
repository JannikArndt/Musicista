using Model.Instruments;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.Sidebar
{
    /// <summary>
    ///     Interaction logic for SidebarInstruments.xaml
    /// </summary>
    public partial class SidebarInstruments
    {
        public SidebarInstruments()
        {
            InitializeComponent();

            foreach (var instrumentGroup in MainWindow.CurrentPiece.InstrumentGroups)
                SidebarPanel.Children.Add(DrawInstrumentGroup(instrumentGroup));
        }

        private static Grid DrawInstrumentGroup(InstrumentGroup instrumentGroup)
        {
            var groupGrid = new Grid();
            groupGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
            groupGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
            groupGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength() });
            groupGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            groupGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            groupGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength() });
            groupGrid.DataContext = instrumentGroup;

            // Line 1
            var groupNameTitle = new TextBlock
            {
                Text = "Group Name",
                Width = 100,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Grid.SetRow(groupNameTitle, 0);
            Grid.SetColumn(groupNameTitle, 0);
            Grid.SetColumnSpan(groupNameTitle, 2);
            groupGrid.Children.Add(groupNameTitle);

            var groupNameBox = new EditableTextBox
            {
                Width = 180,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            groupNameBox.SetBinding(TextBox.TextProperty, new Binding("Name"));
            Grid.SetRow(groupNameBox, 0);
            Grid.SetColumn(groupNameBox, 2);
            groupGrid.Children.Add(groupNameBox);

            // Line 2
            var braceTypeTitle = new TextBlock
            {
                Text = "Brace Type",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Grid.SetRow(braceTypeTitle, 1);
            Grid.SetColumn(braceTypeTitle, 0);
            Grid.SetColumnSpan(braceTypeTitle, 2);
            groupGrid.Children.Add(braceTypeTitle);

            var braceTypeComboBox = new ComboBox
            {
                ItemsSource = Enum.GetValues(typeof(BraceType)),
                Width = 100,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            braceTypeComboBox.SetBinding(Selector.SelectedItemProperty, new Binding("BraceType"));
            Grid.SetRow(braceTypeComboBox, 1);
            Grid.SetColumn(braceTypeComboBox, 2);
            groupGrid.Children.Add(braceTypeComboBox);

            // Instruments
            var separator = new Rectangle
            {
                Width = 1,
                VerticalAlignment = VerticalAlignment.Stretch,
                Stroke = Brushes.SlateGray
            };
            Grid.SetRow(separator, 2);
            Grid.SetColumn(separator, 0);
            groupGrid.Children.Add(separator);

            var instrumentsPanel = new StackPanel
            {
                Orientation = Orientation.Vertical
            };
            Grid.SetRow(instrumentsPanel, 2);
            Grid.SetColumn(instrumentsPanel, 1);
            Grid.SetColumnSpan(instrumentsPanel, 2);
            groupGrid.Children.Add(instrumentsPanel);

            foreach (var instrument in instrumentGroup.Instruments)
                instrumentsPanel.Children.Add(DrawInstrumentGrid(instrument));

            return groupGrid;
        }

        private static Grid DrawInstrumentGrid(Instrument instrument)
        {
            var instrumentGrid = new Grid();
            instrumentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
            instrumentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength() });
            instrumentGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            instrumentGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            instrumentGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            instrumentGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            instrumentGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(5) });
            instrumentGrid.DataContext = instrument;

            // Line 1
            var instrumentNameTitle = new TextBlock
            {
                Text = "Name",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Grid.SetRow(instrumentNameTitle, 0);
            Grid.SetColumn(instrumentNameTitle, 0);
            instrumentGrid.Children.Add(instrumentNameTitle);

            var instrumentNameBox = new EditableTextBox
            {
                Width = 150,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            instrumentNameBox.SetBinding(TextBox.TextProperty, new Binding("Name"));
            Grid.SetRow(instrumentNameBox, 0);
            Grid.SetColumn(instrumentNameBox, 1);
            instrumentGrid.Children.Add(instrumentNameBox);

            // Line 2
            var instrumentShortNameTitle = new TextBlock
            {
                Text = "Short Name",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Grid.SetRow(instrumentShortNameTitle, 1);
            Grid.SetColumn(instrumentShortNameTitle, 0);
            instrumentGrid.Children.Add(instrumentShortNameTitle);

            var instrumentShortNameBox = new EditableTextBox
            {
                Width = 150,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            instrumentShortNameBox.SetBinding(TextBox.TextProperty, new Binding("Shortname"));
            Grid.SetRow(instrumentShortNameBox, 1);
            Grid.SetColumn(instrumentShortNameBox, 1);
            instrumentGrid.Children.Add(instrumentShortNameBox);

            // Line 3
            var numberOfStavesTitle = new TextBlock
            {
                Text = "Staves",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Grid.SetRow(numberOfStavesTitle, 2);
            Grid.SetColumn(numberOfStavesTitle, 0);
            instrumentGrid.Children.Add(numberOfStavesTitle);

            var numberOfStavesTextBox = new EditableTextBox
            {
                Width = 150,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                Text = instrument.Staves.Count.ToString(CultureInfo.InvariantCulture)
            };

            Grid.SetRow(numberOfStavesTextBox, 2);
            Grid.SetColumn(numberOfStavesTextBox, 1);
            instrumentGrid.Children.Add(numberOfStavesTextBox);

            // Line 4
            var transpositionTitle = new TextBlock
            {
                Text = "Transposition",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Grid.SetRow(transpositionTitle, 3);
            Grid.SetColumn(transpositionTitle, 0);
            instrumentGrid.Children.Add(transpositionTitle);

            var transpositionTextBox = new EditableTextBox
            {
                Width = 150,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            transpositionTextBox.SetBinding(TextBox.TextProperty, new Binding("Transposition"));
            Grid.SetRow(transpositionTextBox, 3);
            Grid.SetColumn(transpositionTextBox, 1);
            instrumentGrid.Children.Add(transpositionTextBox);

            // Separator
            var separator = new Rectangle
            {
                Height = 1,
                Fill = Brushes.SlateGray,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            Grid.SetRow(separator, 4);
            Grid.SetColumn(separator, 0);
            Grid.SetColumnSpan(separator, 2);
            instrumentGrid.Children.Add(separator);

            return instrumentGrid;
        }

        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            MainWindow.UISidebar.Content = MainWindow.SidebarInformation;
        }
    }
}