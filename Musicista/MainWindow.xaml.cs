using Microsoft.Win32;
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
        private Piece _currentPiece;
        private string fileName = "";

        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseWheel += Zoom;

            SidebarInformation = new SidebarInformation();
            SidebarView = new SidebarView();
            SidebarAlgorithms = new SidebarAlgorithms();
            Sidebar.Content = SidebarInformation;
            ButtonPathInformation.Fill = Brushes.DodgerBlue;
            ButtonPathSelect.Fill = Brushes.DodgerBlue;

            var serializer = new XmlSerializer(typeof(ScorePartwise));
            using (var fileStream = new FileStream("score.xml", FileMode.Open))
            {
                var result = (ScorePartwise)serializer.Deserialize(fileStream);
                DrawPiece(Mapper.MapMusicXMLPartwiseToMusicistaPiece(result));
            }
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
            var openFileDialog = new OpenFileDialog { Filter = "Supported Files|*.xml;*.musicista|MusicXML (*.xml)|*.xml|Musicista (*.musicista)|*.musicista|All files (*.*)|*.*" };
            if (openFileDialog.ShowDialog() != true)
                return;

            try
            {
                using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    switch (Path.GetExtension(openFileDialog.FileName))
                    {
                        case ".xml":
                            var xmlSerializer = new XmlSerializer(typeof(ScorePartwise));
                            var result = (ScorePartwise)xmlSerializer.Deserialize(fileStream);
                            DrawPiece(Mapper.MapMusicXMLPartwiseToMusicistaPiece(result));
                            break;
                        case ".musicista":
                            var musicistaSerializer = new XmlSerializer(typeof(Piece));
                            DrawPiece((Piece)musicistaSerializer.Deserialize(fileStream));
                            fileName = openFileDialog.FileName;
                            break;
                        default:
                            MessageBox.Show(@"Cannot open filetype " + Path.GetExtension(openFileDialog.FileName), "Error");
                            break;
                    }


                }
            }
            catch (IOException exception)
            {
                MessageBox.Show("Error while loading file: " + exception.Message, "Error");
            }
        }

        private void ClickSave(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(fileName))
                ClickSaveAs(sender, e);
            else
            {
                var serializer = new XmlSerializer(typeof(Piece));
                using (TextWriter writer = new StreamWriter(fileName))
                {
                    serializer.Serialize(writer, _currentPiece);
                }
            }
        }

        private void ClickSaveAs(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { DefaultExt = ".musicista", Filter = "Musicista (*.musicista)|*.musicista", OverwritePrompt = true, FileName = _currentPiece.Title };
            if (saveFileDialog.ShowDialog() != true)
                return;

            fileName = saveFileDialog.FileName;
            var serializer = new XmlSerializer(typeof(Piece));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, _currentPiece);
            }
        }

        private void DrawPiece(Piece piece)
        {
            _currentPiece = piece;
            _pageList = UIHelper.DrawPiece(_currentPiece);

            var pages = new StackPanel();
            foreach (var page in _pageList)
                pages.Children.Add(page);
            pages.Children.Add(new Canvas { Height = 200 });
            CanvasScrollViewer.Content = pages;
        }
    }
}