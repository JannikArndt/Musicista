using Model;
using Musicista.Sidebar;
using Musicista.UI;
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

                _currentPiece = Mapper.MapMusicXMLPartwiseToMusicistaPiece(result);
                _pageList = UIHelper.DrawPiece(_currentPiece);

                var pages = new StackPanel();
                foreach (var page in _pageList)
                    pages.Children.Add(page);
                pages.Children.Add(new Canvas { Height = 200 });
                CanvasScrollViewer.Content = pages;
            }
        }

        #region Drag and Drop

        static bool _captured;
        static double _left, _top, _canvasX, _canvasY;
        static double _originalLeft;
        static double _originalTop;
        static UIElement _draggedElement;
        private static Canvas _draggedOverCanvas;
        private static Canvas _originalParentCanvas;
        private static Canvas _rootCanvas;

        public static void DragStart(object sender, MouseButtonEventArgs e)
        {
            _rootCanvas = _pageList[0];
            _draggedElement = (UIElement)sender;
            Mouse.Capture(_draggedElement);
            _captured = true;

            // Store original situation for possible reset
            _originalParentCanvas = (Canvas)LogicalTreeHelper.GetParent(_draggedElement);
            _originalLeft = Canvas.GetLeft(_draggedElement);
            _originalTop = Canvas.GetTop(_draggedElement);

            // store coordinates
            _left = _originalLeft;
            _top = _originalTop;
            _canvasX = e.GetPosition(_rootCanvas).X;
            _canvasY = e.GetPosition(_rootCanvas).Y;

            // For objects in another canvas, check if it is not the root canvas, than change the parent to the root canvas and update coordinates.
            // While in drag-mode, the element belongs to the root canvas.
            if (_originalParentCanvas != null && _originalParentCanvas != _rootCanvas && _originalParentCanvas.Children.Contains(_draggedElement))
            {
                _originalParentCanvas.Children.Remove(_draggedElement);
                _rootCanvas.Children.Add(_draggedElement);

                _left += Canvas.GetLeft(_originalParentCanvas);
                _top += Canvas.GetTop(_originalParentCanvas);
            }

            // Do not drag any other objects
            e.Handled = true;
        }

        public static void Drag(object sender, MouseEventArgs e)
        {
            if (_captured)
            {
                // Get new mouse position relative to root canvas
                double x = e.GetPosition(_rootCanvas).X;
                double y = e.GetPosition(_rootCanvas).Y;
                // Change left and top of UIElement by the mouse-movement (new position - old position)
                _left += x - _canvasX;
                _top += y - _canvasY;
                Canvas.SetLeft(_draggedElement, _left);
                Canvas.SetTop(_draggedElement, _top);
                // Store new mouse position
                _canvasX = x;
                _canvasY = y;

                // Highlight (or UNhighlight) the canvas you are dragging over. Also: Store it (as a future target).
                var hitTestResult = VisualTreeHelper.HitTest(_rootCanvas, e.GetPosition(_rootCanvas));
                if (hitTestResult != null && hitTestResult.VisualHit != null)
                {
                    var hit = hitTestResult.VisualHit as Canvas;
                    if (hit != null && hit != _draggedOverCanvas)
                    {
                        if (_draggedOverCanvas != null)
                            _draggedOverCanvas.Background = Brushes.Aquamarine;
                        _draggedOverCanvas = hit;
                        hit.Background = Brushes.Yellow;
                    }

                }
                else
                {
                    if (_draggedOverCanvas != null)
                        _draggedOverCanvas.Background = Brushes.Aquamarine;
                    _draggedOverCanvas = null;
                }
            }
            e.Handled = true;
        }

        public static void DragEnd(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            _captured = false;

            // if there is a target canvas
            if (_draggedOverCanvas != null)
            {
                _draggedOverCanvas.Background = Brushes.Aquamarine;
                // and you are not dragging a canvas itself
                if (_draggedElement.GetType() != typeof(Canvas))
                {
                    // add the element to the new canvas
                    _rootCanvas.Children.Remove(_draggedElement);
                    _draggedOverCanvas.Children.Add(_draggedElement);

                    // and update its coordinates
                    var newLeft = _left - Canvas.GetLeft(_draggedOverCanvas);
                    var newTop = _top - Canvas.GetTop(_draggedOverCanvas);
                    Canvas.SetLeft(_draggedElement, newLeft);
                    Canvas.SetTop(_draggedElement, newTop);
                }
                _draggedOverCanvas = null;
            }
            // otherwise reset the element to its original position
            else
            {
                if (_draggedElement.GetType() != typeof(Canvas))
                {
                    // add the element to the original canvas
                    _rootCanvas.Children.Remove(_draggedElement);
                    _originalParentCanvas.Children.Add(_draggedElement);

                    // and restore its coordinates
                    Canvas.SetLeft(_draggedElement, _originalLeft);
                    Canvas.SetTop(_draggedElement, _originalTop);
                }
            }
        }
        #endregion
    }
}