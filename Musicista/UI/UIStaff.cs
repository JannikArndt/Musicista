using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UIStaff : Canvas
    {
        public Line Line1 { get; set; }
        public Line Line2 { get; set; }
        public Line Line3 { get; set; }
        public Line Line4 { get; set; }
        public Line Line5 { get; set; }
        public List<UIMeasure> Measures = new List<UIMeasure>();
        public UIStaff(Panel system, double top)
        {
            const int spacing = 6;

            Width = system.Width;

            SetLeft(this, 0);
            SetTop(this, top);

            Line1 = new Line { X1 = 0, Y1 = 0 * spacing, X2 = Width, Y2 = 0 * spacing, StrokeThickness = 1, Stroke = Brushes.DimGray, SnapsToDevicePixels = true };
            Line2 = new Line { X1 = 0, Y1 = 1 * spacing, X2 = Width, Y2 = 1 * spacing, StrokeThickness = 1, Stroke = Brushes.DimGray, SnapsToDevicePixels = true };
            Line3 = new Line { X1 = 0, Y1 = 2 * spacing, X2 = Width, Y2 = 2 * spacing, StrokeThickness = 1, Stroke = Brushes.DimGray, SnapsToDevicePixels = true };
            Line4 = new Line { X1 = 0, Y1 = 3 * spacing, X2 = Width, Y2 = 3 * spacing, StrokeThickness = 1, Stroke = Brushes.DimGray, SnapsToDevicePixels = true };
            Line5 = new Line { X1 = 0, Y1 = 4 * spacing, X2 = Width, Y2 = 4 * spacing, StrokeThickness = 1, Stroke = Brushes.DimGray, SnapsToDevicePixels = true };

            Line1.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line2.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line3.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line4.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line5.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });

            //Line1.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            //Line2.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            //Line3.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            //Line4.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            //Line5.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

            Children.Add(Line1);
            Children.Add(Line2);
            Children.Add(Line3);
            Children.Add(Line4);
            Children.Add(Line5);
        }
    }
}
