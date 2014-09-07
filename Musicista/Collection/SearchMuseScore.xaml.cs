using MuseScoreAPI.RESTObjects;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Musicista.Collection
{
    /// <summary>
    /// Interaction logic for RecentlyUsed.xaml
    /// </summary>
    public partial class SearchMuseScore
    {
        public SearchMuseScore()
        {
            InitializeComponent();
        }

        private void CollectionItemClick(object sender, MouseButtonEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;
            if (frameworkElement != null)
            {
                InfoPanel.DataContext = frameworkElement.DataContext;
                DownloadScore((Score)frameworkElement.DataContext);
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

        private void OnlineSearchBox_OnTextChanged(object sender, RoutedEventArgs routedEventArgs)
        {
            if (OnlineSearchBox.Text.Length < 3)
                return;

            var scores = MuseScoreAPI.Search(OnlineSearchBox.Text);

            SearchResultsListView.ItemsSource = scores;
        }

        private void DownloadScore(Score score)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://static.musescore.com/" + score.ID + "/" + score.Secret + "/score.mxl", "tempDownloadMuseScore.mxl");
                MainWindow.OpenFile("tempDownloadMuseScore.mxl", score);
            }
            if (MainWindow.Tracker != null)
                MainWindow.Tracker.Track("Download Score", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username }, { "Searchstring", OnlineSearchBox.Text }, { "Score Title", score.Metadata.Title }, { "Score URL", score.Permalink } });
        }
    }
}
