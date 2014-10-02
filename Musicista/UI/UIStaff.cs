using System.Collections.Generic;
using System.Linq;
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
        public UISystem ParentSystem { get; set; }
        public UIStaff(UISystem system)
        {
            ParentSystem = system;
            const int spacing = 6;

            Width = system.Width;

            SetLeft(this, 0);
            SetTop(this, CalculateStaffTop());

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

            Children.Add(Line1);
            Children.Add(Line2);
            Children.Add(Line3);
            Children.Add(Line4);
            Children.Add(Line5);
        }

        public double CalculateStaffTop()
        {
            if (ParentSystem.Staves.Contains(this))
                if (ParentSystem.Staves.IndexOf(this) == 0)
                    return 0;
                else
                    return GetTop(ParentSystem.Staves[ParentSystem.Staves.IndexOf(this) - 1]) + 24 + ParentSystem.Metrics.StaffSpacing;
            if (ParentSystem.Staves.Count == 0)
                return 0;
            return GetTop(ParentSystem.Staves.Last()) + 24 + ParentSystem.Metrics.StaffSpacing;
        }
    }
}
