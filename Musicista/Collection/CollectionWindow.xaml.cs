

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Musicista.Collection
{
    /// <summary>
    /// Interaction logic for CollectionWindow.xaml
    /// </summary>
    public partial class CollectionWindow
    {
        public CollectionWindow()
        {
            InitializeComponent();

            RecentFilesListView.ItemsSource = MainWindow.ApplicationSettings.MostRecentlyUsed;
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
            var reference = (sender as FrameworkElement).DataContext;
            InfoPanel.DataContext = reference;
        }
    }
}
