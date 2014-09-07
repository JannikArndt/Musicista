using MuseScoreAPI.RESTObjects;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Input;

namespace Musicista.View
{
    /// <summary>
    ///     Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void OnlineSearchBox_OnTextChanged(object sender, RoutedEventArgs routedEventArgs)
        {
            if (OnlineSearchBox.Text.Length < 3)
                return;

            SearchResultsListView.ItemsSource = MuseScoreAPI.Search(OnlineSearchBox.Text);
        }

        private void SearchResultItemClick(object sender, MouseButtonEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;
            if (frameworkElement != null)
                DownloadScore((Score)frameworkElement.DataContext);
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

        private void OnlineSearchBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Tracker != null)
                MainWindow.Tracker.Track("Startscreen Searchfield got focus", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username } });
        }
    }
}