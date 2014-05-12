using System.Collections.Generic;
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
        public List<UIMeasureGroup> MeasureGroups = new List<UIMeasureGroup>();
        private double _currentTop;
        public double Indent = 40;
        public Line BarlineFront { get; set; }


        public UISystem(Panel page, double top, double left, double right, double staffSpacing = 55, double systemSpacing = 40)
        {
            Width = page.Width - left - right;

            _staffSpacing = staffSpacing;
            _additionalSystemSpacing = systemSpacing;

            SetLeft(this, left);
            SetTop(this, top);


            // Line in front of the system
            BarlineFront = new Line
            {
                X1 = 0,
                Y1 = 0,
                X2 = 0,
                Y2 = 24,
                StrokeThickness = 2,
                Stroke = Brushes.Black
            };

            Children.Add(BarlineFront);

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
    }
}