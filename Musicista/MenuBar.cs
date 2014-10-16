using Musicista.Collection;
using Musicista.Sidebar;
using Musicista.View;
using System.Windows;
using System.Windows.Media;

namespace Musicista
{
    public partial class MainWindow
    {
        public static SidebarInformation SidebarInformation;
        public static SidebarView SidebarView;
        public static SidebarAlgorithms SidebarAlgorithms;
        public static ToolKind SelectedTool = ToolKind.Select;
        public static CollectionWindow CollectionWindow;
        public static bool UpdateTinyNotationBox = true;

        /// <summary>
        /// Toggles the Collection view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowCollection(object sender, RoutedEventArgs e)
        {

            if (UICollection.Content != null)
            {
                UICollection.Content = null;
                UIButtonPathCollection.Fill = Brushes.Black;
            }
            else
            {
                CollectionWindow.Margin = new Thickness(0);
                CollectionWindow.UpdateRecentlyUsed();
                UICollection.Content = CollectionWindow;
                UIButtonPathCollection.Fill = Brushes.DodgerBlue;
            }
        }

        /// <summary>
        /// Select the Edit tool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectToolEdit(object sender, RoutedEventArgs e)
        {
            SetToolbarButtonPathFill(ToolKind.Edit);
            SelectedTool = ToolKind.Edit;
            TinyNotationBox.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Select the Select tool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectToolSelect(object sender, RoutedEventArgs e)
        {
            SetToolbarButtonPathFill(ToolKind.Select);
            SelectedTool = ToolKind.Select;
        }

        /// <summary>
        /// Show the Information view in the sidebar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowSidebarInformation(object sender, RoutedEventArgs e)
        {
            Sidebar.Content = SidebarInformation;
            SetSidebarButtonPathFill(SidebarKind.Information);
        }

        /// <summary>
        /// Show the View view in the sidebar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowSidebarView(object sender, RoutedEventArgs e)
        {
            Sidebar.Content = SidebarView;
            SetSidebarButtonPathFill(SidebarKind.View);
        }

        /// <summary>
        /// Show the Algorithms view in the sidebar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowSidebarAlgorithms(object sender, RoutedEventArgs e)
        {
            Sidebar.Content = SidebarAlgorithms;
            SetSidebarButtonPathFill(SidebarKind.Algorithms);
        }

        /// <summary>
        /// Set the menu button for the sidebar to the given kind
        /// </summary>
        /// <param name="selected"></param>
        private static void SetSidebarButtonPathFill(SidebarKind selected)
        {
            switch (selected)
            {
                case SidebarKind.Information:
                    UIButtonPathInformation.Fill = Brushes.DodgerBlue;
                    UIButtonPathView.Fill = Brushes.Black;
                    UIButtonPathAlgorithms.Fill = Brushes.Black;
                    break;
                case SidebarKind.View:
                    UIButtonPathInformation.Fill = Brushes.Black;
                    UIButtonPathView.Fill = Brushes.DodgerBlue;
                    UIButtonPathAlgorithms.Fill = Brushes.Black;
                    break;
                case SidebarKind.Algorithms:
                    UIButtonPathInformation.Fill = Brushes.Black;
                    UIButtonPathView.Fill = Brushes.Black;
                    UIButtonPathAlgorithms.Fill = Brushes.DodgerBlue;
                    break;
            }
        }

        /// <summary>
        /// Set the menu button for the tool to the given kind
        /// </summary>
        /// <param name="selected"></param>
        private void SetToolbarButtonPathFill(ToolKind selected)
        {
            switch (selected)
            {
                case ToolKind.Edit:
                    ButtonPathEdit.Fill = Brushes.DodgerBlue;
                    ButtonPathSelect.Fill = Brushes.Black;
                    break;
                case ToolKind.Select:
                    ButtonPathEdit.Fill = Brushes.Black;
                    ButtonPathSelect.Fill = Brushes.DodgerBlue;
                    break;
            }
            TinyNotationBox.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Display the Feedback window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowFeedbackWindow(object sender, RoutedEventArgs e)
        {
            if (!IsConnectedToTheInternet())
            {
                MessageBox.Show("Feedback", "You need to be connected to the internet to send feedback!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var feedbackWindow = new FeedbackWindow();
            feedbackWindow.Show();
        }

        /// <summary>
        ///  Display the About window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAboutWindow(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        /// <summary>
        /// Display the Preferences window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPreferences(object sender, RoutedEventArgs e)
        {
            var preferencesWindow = new PreferencesWindow();
            preferencesWindow.Show();
        }
    }
}
