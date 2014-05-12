using Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UIMeasure : Canvas
    {
        public readonly Measure InnerMeasure = new Measure();
        public readonly UISystem ParentSystem;
        public readonly UIStaff ParentStaff;

        public UIMeasure(UIStaff staff, double top, double left, double width, Measure innerMeasure = null, UISystem system = null)
        {
            Width = width;
            Height = 40;
            Background = Brushes.Transparent;
            ParentStaff = staff;
            ParentSystem = system;

            SetTop(this, top);
            SetLeft(this, left);

            InnerMeasure = innerMeasure;

            Barline = new Line
            {
                X1 = Width,
                Y1 = 10,
                X2 = Width,
                Y2 = 35,
                StrokeThickness = 2,
                Stroke = Brushes.Black,
                SnapsToDevicePixels = true
            };
            Barline.SetBinding(Line.X1Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Barline.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Barline.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

            Children.Add(Barline);

            MouseLeftButtonDown += MainWindow.DragStart;
            MouseMove += MainWindow.Drag;
            MouseLeftButtonUp += MainWindow.DragEnd;

            staff.Children.Add(this);
        }

        public Line Barline { get; set; }

        public override string ToString()
        {
            return "Measure #" + InnerMeasure.MeasureNumber;
        }
    }
}