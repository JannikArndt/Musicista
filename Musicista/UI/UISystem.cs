using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UISystem : Canvas
    {
        public List<UIStaff> Staves = new List<UIStaff>();
        public List<UIMeasureGroup> MeasureGroups = new List<UIMeasureGroup>();
        public readonly UIPage ParentPage;
        public Line BarlineFront { get; set; }
        public int MeasuresInSystem = 4;


        public UISystem(UIPage page, int staves)
        {
            // Logical connection
            ParentPage = page;

            // geometry
            Width = page.Width - page.Settings.SystemMarginLeft - page.Settings.SystemMarginRight;

            SetLeft(this, page.Settings.SystemMarginLeft);
            SetTop(this, CalculateTop());


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

            // Add staves
            for (var i = 0; i < staves; i++)
                AddStaff(new UIStaff(this));

            page.Children.Add(this);
        }

        public double CalculateTop()
        {
            if (ParentPage.Systems.Count == 0 || ParentPage.Systems.IndexOf(this) == 0)
                if (ParentPage.Title != null)
                    return ParentPage.Settings.MarginTop + ParentPage.Title.DrawnHeight + ParentPage.Settings.MarginBelowTitle;
                else
                    return ParentPage.Settings.MarginTop;
            if (ParentPage.Systems.Contains(this))
                return ParentPage.Systems[ParentPage.Systems.IndexOf(this) - 1].Bottom + ParentPage.Settings.SystemSpacing;
            return ParentPage.Systems.Last().Bottom + ParentPage.Settings.SystemSpacing;

        }

        public double Bottom
        {
            get { return GetTop(this) + CalculatedHeight; }
        }

        public double CalculatedHeight
        {
            get { return ((6 * 5) + ParentPage.Settings.StaffSpacing) * Staves.Count - ParentPage.Settings.StaffSpacing; }
        }

        public void AddStaff(UIStaff staff)
        {
            Staves.Add(staff);
            SetLeft(staff, 0);
            Children.Add(staff);

            BarlineFront.Y2 = GetTop(staff) + 24;
        }

        public UISystem NextUISystem
        {
            get
            {
                if (ParentPage == null || ParentPage.Systems == null) return null;
                var index = ParentPage.Systems.IndexOf(this);
                if (index > -1 && ParentPage.Systems.Count > index + 1)
                    return ParentPage.Systems[index + 1];

                if (MainWindow.PageList == null) return null;
                var pageIndex = MainWindow.PageList.IndexOf(ParentPage);
                if (MainWindow.PageList.Count > pageIndex + 1 && MainWindow.PageList[pageIndex + 1].Systems.Count > 0)
                    return MainWindow.PageList[pageIndex + 1].Systems[0];
                return null;
            }
        }

        public UISystem PreviousUISystem
        {
            get
            {
                if (ParentPage == null || ParentPage.Systems == null) return null;
                var index = ParentPage.Systems.IndexOf(this);
                if (index > 0)
                    return ParentPage.Systems[index - 1];

                if (MainWindow.PageList == null) return null;
                var pageIndex = MainWindow.PageList.IndexOf(ParentPage);
                if (pageIndex > 0 && MainWindow.PageList[pageIndex - 1].Systems.Count > 0)
                    return MainWindow.PageList[pageIndex - 1].Systems.Last();
                return null;
            }
        }
    }
}