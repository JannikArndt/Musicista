using Model;
using Musicista.Sidebar;
using Musicista.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Musicista
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private List<Canvas> pageList;
        private Piece currentPiece;
        public static SidebarInformation SidebarInformation;
        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseWheel += Zoom;

            SidebarInformation = new SidebarInformation();
            Sidebar.Content = SidebarInformation;

            var serializer = new XmlSerializer(typeof(scorepartwise));
            using (var fileStream = new FileStream("score.xml", FileMode.Open))
            {
                var result = (scorepartwise)serializer.Deserialize(fileStream);

                currentPiece = Mapper.MapMusicXMLPartwiseToMusicistaPiece(result);
                pageList = UIHelper.DrawPiece(currentPiece);

                var pages = new StackPanel();
                foreach (var page in pageList)
                    pages.Children.Add(page);
                pages.Children.Add(new Canvas { Height = 200 });
                CanvasScrollViewer.Content = pages;
            }

            /*

            pageList = UIHelper.DrawPiece(Examples.ExampleData.GetBeethoven7());

            var pages = new StackPanel();
            foreach (var page in pageList)
                pages.Children.Add(page);
            pages.Children.Add(new Canvas { Height = 200 });
            CanvasScrollViewer.Content = pages;
             */

        }

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
            Sidebar.Content = new SidebarInformation();
        }

        private void ShowSidebarView(object sender, RoutedEventArgs e)
        {
            Sidebar.Content = new SidebarView();
        }

        private void ShowSidebarAlgorithms(object sender, RoutedEventArgs e)
        {
            Sidebar.Content = new SidebarAlgorithms();
        }

        public void Zoom(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Alt))
            {
                Point currentMousePosition = Mouse.GetPosition(CanvasScrollViewer);
                (CanvasScrollViewer.LayoutTransform as ScaleTransform).CenterX = currentMousePosition.X;
                (CanvasScrollViewer.LayoutTransform as ScaleTransform).CenterY = currentMousePosition.Y;
                (CanvasScrollViewer.LayoutTransform as ScaleTransform).ScaleX *= 1 + (e.Delta / 1000.0);
                (CanvasScrollViewer.LayoutTransform as ScaleTransform).ScaleY *= 1 + (e.Delta / 1000.0);
                e.Handled = true;

                if ((CanvasScrollViewer.LayoutTransform as ScaleTransform).ScaleX > 1.05)
                    CanvasScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                else
                    CanvasScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
        }

        private void Print(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new PrintDialog();

                if (dialog.ShowDialog() != true)
                    return;
                dialog.PrintVisual(CanvasScrollViewer.Content as Canvas, "Drawing");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while printing", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            /*
            string filepath = "";
            var openFileDialog1 = new OpenFileDialog {Filter = "MusicXML (*.xml)|*.xml|All files (*.*)|*.*"};
            if (openFileDialog1.ShowDialog() == true)
                filepath = openFileDialog1.FileName;
            */
            var serializer = new XmlSerializer(typeof(scorepartwise));
            using (var fileStream = new FileStream("score.xml", FileMode.Open))
            {
                var result = (scorepartwise)serializer.Deserialize(fileStream);
                UIHelper.DrawTitle(result.work.worktitle, pageList.First());

                currentPiece = Mapper.MapMusicXMLPartwiseToMusicistaPiece(result);
                pageList = UIHelper.DrawPiece(currentPiece);

                var pages = new StackPanel();
                foreach (var page in pageList)
                    pages.Children.Add(page);
                pages.Children.Add(new Canvas { Height = 200 });
                CanvasScrollViewer.Content = pages;
            }
        }
    }
}