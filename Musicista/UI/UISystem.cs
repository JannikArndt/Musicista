using Model.View;
using System;
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
        public List<UIMeasureGroup> UIMeasureGroups = new List<UIMeasureGroup>();
        public UIPage ParentPage;
        public readonly Metrics Metrics;
        public Line BarlineFront { get; set; }
        public int MeasuresInSystem { get; set; }
        public int SystemNumber { get; set; }


        public UISystem(Metrics metrics, int staves, int systemNumber, int measuresInSystem)
        {
            // Logical connection
            Metrics = metrics;
            SystemNumber = systemNumber;
            MeasuresInSystem = measuresInSystem;

            // geometry
            Width = Metrics.Page.Width - Metrics.Margin.Left - Metrics.Margin.Right;

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
        }

        public double CalculateTop(UIPage parentPage)
        {
            if (parentPage.Systems.Count == 0 || parentPage.Systems.IndexOf(this) == 0)
                if (parentPage.Title != null)
                    return Math.Round(parentPage.Settings.Metrics.Margin.Top + parentPage.Title.DrawnHeight + parentPage.Title.DrawnHeight + parentPage.Settings.Metrics.Margin.BelowTitle);
                else
                    return Math.Round(parentPage.Settings.Metrics.Margin.Top);
            if (parentPage.Systems.Contains(this))
                return Math.Round(parentPage.Systems[parentPage.Systems.IndexOf(this) - 1].Bottom + parentPage.Settings.SystemSpacing);
            return Math.Round(parentPage.Systems.Last().Bottom + parentPage.Settings.SystemSpacing);

        }

        public double Bottom
        {
            get { return GetTop(this) + CalculatedHeight; }
        }

        public double CalculatedHeight
        {
            get { return ((6 * 5) + Metrics.Staff.Spacing) * Staves.Count - Metrics.Staff.Spacing; }
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