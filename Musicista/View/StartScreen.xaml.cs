using MuseScoreAPI.RESTObjects;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

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

            var scores = MuseScoreAPI.Search(OnlineSearchBox.Text);

            OnlineSearchStack.Children.Clear();

            foreach (var score in scores.Take(6))
            {
                var scoreTextBlock = new TextBlock
                {
                    FontSize = 12,
                    TextAlignment = TextAlignment.Left,
                    Margin = new Thickness(0, 8, 0, 0)
                };
                if (!string.IsNullOrEmpty(score.Metadata.Composer))
                    scoreTextBlock.Inlines.Add(new Run(score.Metadata.Composer + ": "));
                scoreTextBlock.Inlines.Add(new Run(score.Title) { FontStyle = FontStyles.Italic });
                scoreTextBlock.Inlines.Add(new Run("    MuseScore.com") { Foreground = Brushes.DarkGray });

                scoreTextBlock.MouseDown += (o, args) => DownloadScore(score);
                scoreTextBlock.Cursor = Cursors.Hand;

                OnlineSearchStack.Children.Add(scoreTextBlock);
            }
        }

        private void DownloadScore(Score score)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://static.musescore.com/" + score.ID + "/" + score.Secret + "/score.mxl", "tempDownloadMuseScore.mxl");
                MainWindow.OpenFile("tempDownloadMuseScore.mxl", score);
            }
            MainWindow.Tracker.Track("Download Score", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username }, { "Searchstring", OnlineSearchBox.Text }, { "Score Title", score.Metadata.Title }, { "Score URL", score.Permalink } });
        }

        private void OnlineSearchBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            MainWindow.Tracker.Track("Startscreen Searchfield got focus", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username } });
        }
    }
}