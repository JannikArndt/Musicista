using Model;
using Musicista.Sidebar;
using Musicista.UI;
using MusicXML;
using System;
using System.Collections.Generic;
using System.IO;
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
        private static List<Canvas> _pageList;
        public static SidebarInformation SidebarInformation;
        private Piece _currentPiece;

        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseWheel += Zoom;

            SidebarInformation = new SidebarInformation();
            Sidebar.Content = SidebarInformation;

            var serializer = new XmlSerializer(typeof(ScorePartwise));
            using (var fileStream = new FileStream("score.xml", FileMode.Open))
            {
                var result = (ScorePartwise)serializer.Deserialize(fileStream);

                _currentPiece = Mapper.MapMusicXMLPartwiseToMusicistaPiece(result);
                _pageList = UIHelper.DrawPiece(_currentPiece);

                var pages = new StackPanel();
                foreach (var page in _pageList)
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
                var currentMousePosition = Mouse.GetPosition(CanvasScrollViewer);
                var scaleTransform = CanvasScrollViewer.LayoutTransform as ScaleTransform;
                if (scaleTransform != null)
                {
                    scaleTransform.CenterX = currentMousePosition.X;
                    scaleTransform.CenterY = currentMousePosition.Y;
                    scaleTransform.ScaleX *= 1 + (e.Delta / 1000.0);
                    scaleTransform.ScaleY *= 1 + (e.Delta / 1000.0);

                    e.Handled = true;

                    CanvasScrollViewer.HorizontalScrollBarVisibility = scaleTransform.ScaleX > 1.05 ? ScrollBarVisibility.Visible : ScrollBarVisibility.Hidden;
                }
            }
        }

        private void Print(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new PrintDialog();

                if (dialog.ShowDialog() != true)
                    return;
                var stackPanel = CanvasScrollViewer.Content as StackPanel;
                if (stackPanel == null)
                    return;
                var visual = stackPanel.Children[0] as Canvas;
                if (visual != null)
                    dialog.PrintVisual(visual, "Drawing");
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
            var serializer = new XmlSerializer(typeof(ScorePartwise));
            using (var fileStream = new FileStream("score.xml", FileMode.Open))
            {
                var result = (ScorePartwise)serializer.Deserialize(fileStream);

                _currentPiece = Mapper.MapMusicXMLPartwiseToMusicistaPiece(result);
                _pageList = UIHelper.DrawPiece(_currentPiece);

                var pages = new StackPanel();
                foreach (var page in _pageList)
                    pages.Children.Add(page);
                pages.Children.Add(new Canvas { Height = 200 });
                CanvasScrollViewer.Content = pages;
            }
        }

        private void ClickSave(object sender, RoutedEventArgs e)
        {
            var serializer = new XmlSerializer(typeof(Piece));
            using (TextWriter writer = new StreamWriter(@"newFile.musicista"))
            {
                serializer.Serialize(writer, _currentPiece);
            }
        }

        private void ClickSaveAs(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}