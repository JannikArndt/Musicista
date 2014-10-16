using Musicista.Properties;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Musicista.View
{
    /// <summary>
    /// Interaction logic for FeedbackWindow.xaml
    /// </summary>
    public partial class FeedbackWindow
    {
        public FeedbackWindow()
        {
            InitializeComponent();
            NameTextBox.Text = Settings.Default.Username;
            MailTextBox.Text = Settings.Default.EMail;
        }

        /// <summary>
        /// Send the Feedback via the Tracer to MixPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendFeedback(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(NameTextBox.Text))
                Settings.Default.Username = NameTextBox.Text;
            if (!String.IsNullOrEmpty(MailTextBox.Text))
                Settings.Default.EMail = MailTextBox.Text;

            if (!MainWindow.IsConnectedToTheInternet())
            {
                MessageBox.Show("Feedback", "You need to be connected to the internet to send feedback!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MainWindow.Tracker.Track("Feedback", new Dictionary<string, object> {
                {"Username", Settings.Default.Username},
                {"Name", NameTextBox.Text},
                {"EMail", MailTextBox.Text},
                {"Feedback", FeedbackTextBox.Text},
                {"Version", AboutWindow.GetPublishedVersion().ToString()}
            });

            Close();
        }
    }
}
