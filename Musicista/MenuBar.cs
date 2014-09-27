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
        public static ToolKind SelectedTool;
        public static CollectionWindow CollectionWindow;

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

        private void SelectToolAdd(object sender, RoutedEventArgs e)
        {
            SetToolbarButtonPathFill(ToolKind.Add);
            SelectedTool = ToolKind.Add;
            var tinyEditor = new TinyEditor.TinyEditor();
            tinyEditor.Show();

        }

        private void SelectToolEdit(object sender, RoutedEventArgs e)
        {
            SetToolbarButtonPathFill(ToolKind.Edit);
            SelectedTool = ToolKind.Edit;
        }

        private void SelectToolSelect(object sender, RoutedEventArgs e)
        {
            //SetToolbarButtonPathFill(ToolKind.Select);
            SelectedTool = ToolKind.Select;
        }

        private void ShowSidebarInformation(object sender, RoutedEventArgs e)
        {
            Sidebar.Content = SidebarInformation;
            SetSidebarButtonPathFill(SidebarKind.Information);
        }

        private void ShowSidebarView(object sender, RoutedEventArgs e)
        {
            Sidebar.Content = SidebarView;
            SetSidebarButtonPathFill(SidebarKind.View);
        }

        private void ShowSidebarAlgorithms(object sender, RoutedEventArgs e)
        {
            Sidebar.Content = SidebarAlgorithms;
            SetSidebarButtonPathFill(SidebarKind.Algorithms);
        }

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

        private void SetToolbarButtonPathFill(ToolKind selected)
        {
            switch (selected)
            {
                case ToolKind.Add:
                    ButtonPathAdd.Fill = Brushes.DodgerBlue;
                    ButtonPathEdit.Fill = Brushes.Black;
                    ButtonPathSelect.Fill = Brushes.Black;
                    break;
                case ToolKind.Edit:
                    ButtonPathAdd.Fill = Brushes.Black;
                    ButtonPathEdit.Fill = Brushes.DodgerBlue;
                    ButtonPathSelect.Fill = Brushes.Black;
                    break;
                case ToolKind.Select:
                    ButtonPathAdd.Fill = Brushes.Black;
                    ButtonPathEdit.Fill = Brushes.Black;
                    ButtonPathSelect.Fill = Brushes.DodgerBlue;
                    break;
            }
        }

        private void ShowAboutWindow(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        private void ShowPreferences(object sender, RoutedEventArgs e)
        {
            var preferencesWindow = new PreferencesWindow();
            preferencesWindow.Show();
        }
    }
}
