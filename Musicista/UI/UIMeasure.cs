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
        public readonly UIMeasureGroup ParentMeasureGroup;

        public Line Line1 { get; set; }
        public Line Line2 { get; set; }
        public Line Line3 { get; set; }
        public Line Line4 { get; set; }
        public Line Line5 { get; set; }

        public UIMeasure(UIMeasureGroup parentMeasureGroup, double top, double left, Measure innerMeasure = null, UISystem system = null, UIStaff staff = null)
        {
            Height = 40;
            Background = Brushes.Transparent;
            ParentStaff = staff;
            ParentSystem = system;
            ParentMeasureGroup = parentMeasureGroup;

            SetTop(this, top);
            SetLeft(this, left);

            SetBinding(WidthProperty, new Binding { Path = new PropertyPath(WidthProperty), Source = parentMeasureGroup });

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

            parentMeasureGroup.Children.Add(this);

            // Lines
            const int spacing = 6;
            Line1 = new Line { X1 = 0, Y1 = 10 + 0 * spacing, X2 = Width, Y2 = 10 + 0 * spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };
            Line2 = new Line { X1 = 0, Y1 = 10 + 1 * spacing, X2 = Width, Y2 = 10 + 1 * spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };
            Line3 = new Line { X1 = 0, Y1 = 10 + 2 * spacing, X2 = Width, Y2 = 10 + 2 * spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };
            Line4 = new Line { X1 = 0, Y1 = 10 + 3 * spacing, X2 = Width, Y2 = 10 + 3 * spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };
            Line5 = new Line { X1 = 0, Y1 = 10 + 4 * spacing, X2 = Width, Y2 = 10 + 4 * spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };

            Line1.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line2.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line3.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line4.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line5.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });

            Line1.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            Line2.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            Line3.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            Line4.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            Line5.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

            Children.Add(Line1);
            Children.Add(Line2);
            Children.Add(Line3);
            Children.Add(Line4);
            Children.Add(Line5);
        }

        public Line Barline { get; set; }

        public override string ToString()
        {
            return "Measure #" + InnerMeasure.ParentMeasureGroup.MeasureNumber;
        }
    }
}