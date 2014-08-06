


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

            RecentlyUsedContentControl.Content = new RecentlyUsed();
            ComposersContentControl.Content = new Composers();
            MuseScoreContentControl.Content = new SearchMuseScore();
        }

        public void UpdateRecentlyUsed()
        {
            RecentlyUsedContentControl.Content = new RecentlyUsed();
        }
    }
}
