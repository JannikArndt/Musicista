using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Musicista.Collection
{
    /// <summary>
    /// Interaction logic for RecentlyUsed.xaml
    /// </summary>
    public partial class RecentlyUsed
    {
        public RecentlyUsed()
        {
            InitializeComponent();

            RecentFilesListView.ItemsSource = MainWindow.ApplicationSettings.MostRecentlyUsed;
            var view = (CollectionView)CollectionViewSource.GetDefaultView(RecentFilesListView.ItemsSource);
            view.Filter = UserFilter;
        }

        private void CollectionItemClick(object sender, MouseButtonEventArgs e)
        {

            var stackpanel = (StackPanel)sender;
            if (stackpanel != null)
            {
                MainWindow.OpenFile(stackpanel.Tag.ToString());
                MainWindow.UICollection.Content = null;
                MainWindow.UIButtonPathCollection.Fill = Brushes.Black;
            }
        }

        private void CollectionItemMouseEnter(object sender, MouseEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;
            if (frameworkElement != null)
                InfoPanel.DataContext = frameworkElement.DataContext;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(RecentFilesFilterBox.Text))
                return true;
            var reference = item as DocumentReference;
            return reference != null
                && ((reference.TitleString.IndexOf(RecentFilesFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                || (reference.ComposerString.IndexOf(RecentFilesFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                || (reference.OpusString.IndexOf(RecentFilesFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0));
        }

        private void RecentFilesFilterBox_OnSearch(object sender, RoutedEventArgs routedEventArgs)
        {
            if (RecentFilesListView.ItemsSource != null)
                CollectionViewSource.GetDefaultView(RecentFilesListView.ItemsSource).Refresh();
        }
    }
}
