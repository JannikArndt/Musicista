using Model;
using Musicista.UI;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Duration = Model.Duration;

namespace Musicista
{
    public partial class MainWindow
    {
        private static bool _captured;
        private static double _left, _top, _canvasX, _canvasY;
        private static double _originalLeft;
        private static double _originalTop;
        private static UIElement _draggedElement;
        private static Canvas _draggedOverCanvas;
        private static Canvas _originalParentCanvas;
        private static Canvas _rootCanvas;
        private static Brush _originalBackground;

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
            if (_originalParentCanvas != null && !Equals(_originalParentCanvas, _rootCanvas) && _originalParentCanvas.Children.Contains(_draggedElement))
            {
                _originalParentCanvas.Children.Remove(_draggedElement);
                _rootCanvas.Children.Add(_draggedElement);
            }

            var tempCanvas = _originalParentCanvas;
            while (tempCanvas != null && (!(LogicalTreeHelper.GetParent(tempCanvas) is StackPanel)))
            {
                _left += Canvas.GetLeft(tempCanvas);
                _top += Canvas.GetTop(tempCanvas);
                tempCanvas = (Canvas)LogicalTreeHelper.GetParent(tempCanvas);
            }

            // Set HitTestVisible to false, otherwise this element would be it'
            _draggedElement.IsHitTestVisible = false;

            // Do not drag any other objects
            e.Handled = true;
            Console.WriteLine(@"Start dragging " + _draggedElement);
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
                    if (hit != null && !Equals(hit, _draggedOverCanvas) && !Equals(hit, _rootCanvas) && !Equals(hit, _draggedElement))
                    {
                        if (_draggedOverCanvas != null)
                            _draggedOverCanvas.Background = _originalBackground;
                        _draggedOverCanvas = hit;
                        _originalBackground = _draggedOverCanvas.Background;
                        hit.Background = Brushes.Yellow;
                    }
                }
                else
                {
                    if (_draggedOverCanvas != null)
                        _draggedOverCanvas.Background = _originalBackground;
                    _draggedOverCanvas = null;
                }
            }
            e.Handled = true;
        }

        public static void DragEnd(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            _captured = false;
            Console.WriteLine(@"End dragging");

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

                    // *** Update Model ***
                    var movedMeasure = ((UIMeasure)_draggedElement).InnerMeasure;
                    var overwrittenMeasure = ((UIMeasure)_draggedOverCanvas).InnerMeasure;

                    // Delete reference to overwritten measure
                    overwrittenMeasure.ParentMeasureGroup.Measures.Remove(overwrittenMeasure);

                    // Update references for moved measure
                    movedMeasure.ParentMeasureGroup.Measures.Remove(movedMeasure);
                    movedMeasure.Instrument = overwrittenMeasure.Instrument;
                    movedMeasure.ParentMeasureGroup = overwrittenMeasure.ParentMeasureGroup;
                    movedMeasure.ParentMeasureGroup.Measures.Add(movedMeasure);

                    // Reapply eventlisteners
                    _draggedElement.MouseLeftButtonDown += DragStart;
                    _draggedElement.MouseMove += Drag;
                    _draggedElement.MouseLeftButtonUp += DragEnd;

                    // Fill empty space with empty measure
                    var newMeasure = new Measure
                    {
                        Instrument = movedMeasure.Instrument,
                        ParentMeasureGroup = movedMeasure.ParentMeasureGroup,
                        ListOfSymbols = new List<Symbol> { new Rest { Beat = 1, Duration = Duration.whole } }
                    };
                    newMeasure.ParentMeasureGroup.Measures.Add(newMeasure);
                    UIHelper.DrawMeasure(((UIMeasure)_draggedElement).ParentMeasureGroup, newMeasure, ((UIMeasure)_draggedElement).Part);


                    // Update visual tree
                    var parentOfMeasureToBeReplaced = (Canvas)LogicalTreeHelper.GetParent(_draggedOverCanvas);
                    parentOfMeasureToBeReplaced.Children.Remove(_draggedOverCanvas);
                    parentOfMeasureToBeReplaced.Children.Add(_draggedElement);

                    // Delete all references
                    _draggedElement = null;
                    _draggedOverCanvas = null;
                    _originalParentCanvas = null;
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
        }
    }
}