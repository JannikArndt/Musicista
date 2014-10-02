using Model.Instruments;
using Model.Meta.People;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Musicista.View
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class EditInstruments
    {
        public static Person Person { get; set; }
        public EditInstruments(IEnumerable<InstrumentGroup> list)
        {
            InitializeComponent();

            GroupListBox.ItemsSource = list;

            PreviewKeyDown += (sender, args) =>
            {
                if (args.Key == Key.Enter || args.Key == Key.Escape)
                {
                    CloseButton.Focus(); // to un-focus text fields and write the values
                    CloseClick(null, null);
                }
            };

        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            MainWindow.SidebarInformation.ShowPiece();
            MainWindow.ReDrawPiece();
            Close();
        }

        private void GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            var group = (InstrumentGroup)GroupListBox.SelectedItems[0];
            if (group != null)
            {
                InstrumentGroupGrid.DataContext = group;
                InstrumentListBox.ItemsSource = group.Instruments;
                BraceTypeComboBox.ItemsSource = Enum.GetValues(typeof(BraceType));
            }
        }

        private void InstrumentChanged(object sender, SelectionChangedEventArgs e)
        {
            var inst = (Instrument)InstrumentListBox.SelectedItems[0];
            if (inst != null)
            {
                InstrumentNameTextBox.DataContext = inst;
            }
        }

        private void AddInstrument(object sender, RoutedEventArgs e)
        {
            var group = (InstrumentGroup)GroupListBox.SelectedItems[0];
            if (group != null)
            {
                group.Instruments.Add(new Instrument());
            }
        }

        private void DeleteInstrument(object sender, RoutedEventArgs e)
        {
            var group = (InstrumentGroup)GroupListBox.SelectedItem;
            var inst = (Instrument)InstrumentListBox.SelectedItem;
            if (group != null && inst != null)
            {
                group.Instruments.Remove(inst);
            }
        }
    }
}
