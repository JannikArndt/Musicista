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

        /// <summary>
        /// Calls the MuseScore API and displays the search results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="routedEventArgs"></param>
        private void OnlineSearchBox_OnTextChanged(object sender, RoutedEventArgs routedEventArgs)
        {
            if (OnlineSearchBox.Text.Length < 3)
                return;

            SearchResultsListView.ItemsSource = MuseScoreAPI.Search(OnlineSearchBox.Text);
        }

        /// <summary>
        /// Downloads a score and opens it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchResultItemClick(object sender, MouseButtonEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;
            if (frameworkElement == null) return;
            var score = (Score)frameworkElement.DataContext;

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