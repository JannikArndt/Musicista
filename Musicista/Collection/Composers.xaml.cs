using Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Musicista.Collection
{
    /// <summary>
    /// Interaction logic for Composers.xaml
    /// </summary>
    public partial class Composers
    {
        public Composers()
        {
            InitializeComponent();
            if (MainWindow.CollectionBase.Composers.Count > 0)
                ComposersListView.ItemsSource = MainWindow.CollectionBase.Composers;
            else
            {
                var errorText = new TextBlock { Text = "Not available in offline mode" };
                ComposersGrid.Children.Add(errorText);
            }
        }

        private void ComposerMouseOver(object sender, MouseEventArgs mouseEventArgs)
        {
            var composer = sender as FrameworkElement;
            if (composer == null) return;
            var item = composer.DataContext as CollectionComposer;
            if (item == null) return;
            ComposerPanel.DataContext = item;
            InfoPanel.DataContext = null;
            WorksListView.ItemsSource = item.Categories.SelectMany(cat => cat.Works);

            var view = (CollectionView)CollectionViewSource.GetDefaultView(WorksListView.ItemsSource);
            view.Filter = UserFilter;
        }

        private void WorkMouseOver(object sender, MouseEventArgs mouseEventArgs)
        {
            var work = sender as FrameworkElement;
            if (work == null) return;
            var item = work.DataContext as CategoryWork;
            if (item == null) return;
            InfoPanel.DataContext = item;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(WorkFilterBox.Text))
                return true;
            var categoryWork = item as CategoryWork;
            return categoryWork != null
                && ((categoryWork.WorkName.IndexOf(WorkFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                || (categoryWork.MetaData.Opus.OpusString.IndexOf(WorkFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                || (categoryWork.MetaData.Title.IndexOf(WorkFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                || (categoryWork.MetaData.Subtitle.IndexOf(WorkFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0));
        }

        private void WorkFilterBox_OnTextChanged(object sender, RoutedEventArgs routedEventArgs)
        {
            if (WorksListView.ItemsSource != null)
                CollectionViewSource.GetDefaultView(WorksListView.ItemsSource).Refresh();
        }

        private void CollectionItemClick(object sender, MouseButtonEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;
            if (frameworkElement != null)
            {
                DownloadScore((CategoryWork)frameworkElement.DataContext);
                MainWindow.UICollection.Content = null;
                MainWindow.UIButtonPathCollection.Fill = Brushes.Black;
            }
        }

        private void DownloadScore(CategoryWork score)
        {
            using (var client = new WebClient())
            {
                var filename = score.MetaData.People.ComposersAsString + " - " + score.WorkName + ".musicista";
                client.DownloadFile(score.Filepath, "Collection/" + filename);
                MainWindow.OpenFile("Collection/" + filename);
            }
            if (MainWindow.Tracker != null)
                MainWindow.Tracker.Track("Download Score", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username }, { "Score Title", score.WorkName }, { "Score URL", score.Filepath } });
        }
    }
}
