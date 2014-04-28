using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UIStaff
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public Line line1 { get; set; }
        public Line line2 { get; set; }
        public Line line3 { get; set; }
        public Line line4 { get; set; }
        public Line line5 { get; set; }
        public List<UIMeasure> Measures = new List<UIMeasure>();
        public UIStaff(int top, int left, int width)
        {
            int spacing = 6;
            Left = left;
            Top = top;
            Width = width;

            line1 = new Line { X1 = left, Y1 = top + 0 * spacing, X2 = left + width, Y2 = top + 0 * spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };
            line2 = new Line { X1 = left, Y1 = top + 1 * spacing, X2 = left + width, Y2 = top + 1 * spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };
            line3 = new Line { X1 = left, Y1 = top + 2 * spacing, X2 = left + width, Y2 = top + 2 * spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };
            line4 = new Line { X1 = left, Y1 = top + 3 * spacing, X2 = left + width, Y2 = top + 3 * spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };
            line5 = new Line { X1 = left, Y1 = top + 4 * spacing, X2 = left + width, Y2 = top + 4 * spacing, StrokeThickness = 1, Stroke = Brushes.Black, SnapsToDevicePixels = true };

            line1.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            line2.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            line3.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            line4.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            line5.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
        }
    }
}
