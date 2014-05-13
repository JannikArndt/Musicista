using Musicista.Sidebar;
using System.Windows;
using System.Windows.Media;

namespace Musicista
{
    public partial class MainWindow
    {
        public static SidebarInformation SidebarInformation;
        public static SidebarView SidebarView;
        public static SidebarAlgorithms SidebarAlgorithms;

        private void ShowCollection(object sender, RoutedEventArgs e)
        {
        }

        private void SelectToolAdd(object sender, RoutedEventArgs e)
        {
        }

        private void SelectToolEdit(object sender, RoutedEventArgs e)
        {
        }

        private void SelectToolSelect(object sender, RoutedEventArgs e)
        {
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

        private void SetSidebarButtonPathFill(SidebarKind selected)
        {
            switch (selected)
            {
                case SidebarKind.Information:
                    ButtonPathInformation.Fill = Brushes.DodgerBlue;
                    ButtonPathView.Fill = Brushes.Black;
                    ButtonPathAlgorithms.Fill = Brushes.Black;
                    break;
                case SidebarKind.View:
                    ButtonPathInformation.Fill = Brushes.Black;
                    ButtonPathView.Fill = Brushes.DodgerBlue;
                    ButtonPathAlgorithms.Fill = Brushes.Black;
                    break;
                case SidebarKind.Algorithms:
                    ButtonPathInformation.Fill = Brushes.Black;
                    ButtonPathView.Fill = Brushes.Black;
                    ButtonPathAlgorithms.Fill = Brushes.DodgerBlue;
                    break;
            }
        }
    }
}
