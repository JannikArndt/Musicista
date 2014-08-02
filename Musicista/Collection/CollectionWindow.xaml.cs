

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
    }
}
