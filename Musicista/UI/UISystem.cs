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
        public readonly UIPage ParentPage;
        private double _currentTop;
        public double Indent = 40;
        public Line BarlineFront { get; set; }
        public int MeasuresInSystem = 4;


        public UISystem(UIPage page, double top)
        {
            // Logical connection
            ParentPage = page;
            page.Systems.Add(this);

            // geometry
            Width = page.Width - page.Settings.SystemMarginLeft - page.Settings.SystemMarginRight;

            _staffSpacing = page.Settings.StaffSpacing;
            _additionalSystemSpacing = page.Settings.SystemSpacing;

            SetLeft(this, page.Settings.SystemMarginLeft);
            SetTop(this, top);


            // Line in front of the system
            BarlineFront = new Line
            {
                X1 = 0,
                Y1 = 0,
                X2 = 0,
                Y2 = 24,
                StrokeThickness = 2,
                Stroke = Brushes.DimGray
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

        public UISystem NextUISystem
        {
            get
            {
                if (ParentPage == null || ParentPage.Systems == null) return null;
                var index = ParentPage.Systems.IndexOf(this);
                if (index > -1 && ParentPage.Systems.Count > index + 1)
                    return ParentPage.Systems[index + 1];

                var pageIndex = MainWindow.PageList.IndexOf(ParentPage);
                if (MainWindow.PageList.Count > pageIndex + 1 && MainWindow.PageList[pageIndex + 1].Systems.Count > 0)
                    return MainWindow.PageList[pageIndex + 1].Systems[0];
                return null;
            }
        }
    }
}