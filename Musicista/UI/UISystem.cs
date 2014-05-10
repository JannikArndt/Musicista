using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UISystem : Canvas
    {
        private readonly double _additionalSystemSpacing;
        private readonly double _staffSpacing;
        public List<UIStaff> Staves = new List<UIStaff>();
        private double _currentTop;

        public UISystem(Panel page, int top, int left, int right, double staffSpacing = 55, double systemSpacing = 40)
        {
            Width = (int)page.Width - left - right;

            _staffSpacing = staffSpacing;
            _additionalSystemSpacing = systemSpacing;

            SetLeft(this, left);
            SetTop(this, top);

            page.Children.Add(this);
        }

        public double Bottom
        {
            get { return _currentTop + _additionalSystemSpacing; }
        }

        public void AddStaff(UIStaff staff)
        {
            Staves.Add(staff);
            SetLeft(staff, 0);
            SetTop(staff, _currentTop);
            _currentTop += staff.ActualHeight + _staffSpacing;

            Children.Add(staff);
        }

        public void ConnectStaves()
        {
            if (Staves == null || Staves.Count == 0)
                return;

            // Left side, top, bottom
            var x = (int)GetLeft(Staves.First());
            var y1 = (int)GetTop(Staves.First());
            var y2 = (int)GetTop(Staves.Last()) + 24;

            // First line
            var line = new Line
            {
                X1 = x,
                Y1 = y1,
                X2 = x,
                Y2 = y2,
                StrokeThickness = 2,
                Stroke = Brushes.Black,
                SnapsToDevicePixels = true
            };
            line.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            Children.Add(line);

            // Barlines
            foreach (var measure in Staves.First().Measures)
            {
                x = (int)GetLeft(Staves.First()) + (int)GetLeft(measure) + (int)measure.Width;
                line = new Line
                {
                    X1 = x,
                    Y1 = y1,
                    X2 = x,
                    Y2 = y2,
                    StrokeThickness = 2,
                    Stroke = Brushes.Black,
                    SnapsToDevicePixels = true
                };
                line.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                Children.Add(line);
            }
        }
    }
}