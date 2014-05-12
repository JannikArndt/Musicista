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
        private static Brush originalBackground;

        public static void DragStart(object sender, MouseButtonEventArgs e)
        {

            if (_captured)
                DragEnd(sender, e);

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
            }

            var tempCanvas = _originalParentCanvas;
            while (tempCanvas != _rootCanvas && tempCanvas != null)
            {
                _left += Canvas.GetLeft(tempCanvas);
                _top += Canvas.GetTop(tempCanvas);
                tempCanvas = (Canvas)LogicalTreeHelper.GetParent(tempCanvas);
            }

            // Set HitTestVisible to false, otherwise this element would be it'
            _draggedElement.IsHitTestVisible = false;

            // Do not drag any other objects
            e.Handled = true;
            Console.WriteLine("Start dragging " + _draggedElement);
        }

        public static void Drag(object sender, MouseEventArgs e)
        {
            if (_captured && Mouse.LeftButton == MouseButtonState.Pressed)
            {
                // Get new mouse position relative to root canvas
                var x = e.GetPosition(_rootCanvas).X;
                var y = e.GetPosition(_rootCanvas).Y;
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
                    if (hit != null && hit != _draggedOverCanvas && hit != _rootCanvas && hit != _draggedElement)
                    {
                        if (_draggedOverCanvas != null)
                            _draggedOverCanvas.Background = originalBackground;
                        _draggedOverCanvas = hit;
                        originalBackground = _draggedOverCanvas.Background;
                        hit.Background = Brushes.Yellow;
                    }

                }
                else
                {
                    if (_draggedOverCanvas != null)
                        _draggedOverCanvas.Background = originalBackground;
                    _draggedOverCanvas = null;
                }
            }
            e.Handled = true;
        }

        public static void DragEnd(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            _captured = false;
            Console.WriteLine("End dragging");

            if (_draggedElement != null && _draggedElement.GetType() == typeof(UIMeasure))

                // if there is a target canvas
                if (_draggedOverCanvas != null)
                {
                    // and you are not dragging a canvas itself
                    // add the element to the new canvas
                    var parent = (Canvas)LogicalTreeHelper.GetParent(_draggedElement);
                    if (parent != null)
                        parent.Children.Remove(_draggedElement);


                    // and update its coordinates
                    Canvas.SetLeft(_draggedElement, Canvas.GetLeft(_draggedOverCanvas));
                    Canvas.SetTop(_draggedElement, Canvas.GetTop(_draggedOverCanvas));

                    var parentOfMeasureToBeReplaced = (Canvas)LogicalTreeHelper.GetParent(_draggedOverCanvas);
                    parentOfMeasureToBeReplaced.Children.Remove(_draggedOverCanvas);
                    _draggedOverCanvas = null;

                    parentOfMeasureToBeReplaced.Children.Add(_draggedElement);
                }
                // otherwise reset the element to its original position
                else
                {
                    // add the element to the original canvas
                    var parent = (Canvas)LogicalTreeHelper.GetParent(_draggedElement);
                    parent.Children.Remove(_draggedElement);
                    if (_originalParentCanvas != null)
                        _originalParentCanvas.Children.Add(_draggedElement);

                    // and restore its coordinates
                    Canvas.SetLeft(_draggedElement, _originalLeft);
                    Canvas.SetTop(_draggedElement, _originalTop);
                }

            if (e != null)
                e.Handled = true;
        }
        #endregion
    }
}