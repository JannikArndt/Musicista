using Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    /// <summary>
    /// A UI class for systems, containing several UIMeasureGroups and Staves as well as the bar line in front of the system.
    /// </summary>
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

        /// <summary>
        /// Calculates the top position on the UIPage by looking at its contents.
        /// </summary>
        /// <param name="parentPage"></param>
        /// <returns></returns>
        public double CalculateTop(UIPage parentPage)
        {
            if (parentPage.UISystems.Count == 0 || parentPage.UISystems.IndexOf(this) == 0)
                if (parentPage.Title != null)
                    return Math.Round(parentPage.Settings.Metrics.Margin.Top + parentPage.Title.DrawnHeight + parentPage.Title.DrawnHeight + parentPage.Settings.Metrics.Margin.BelowTitle);
                else
                    return Math.Round(parentPage.Settings.Metrics.Margin.Top);
            if (parentPage.UISystems.Contains(this))
                return Math.Round(parentPage.UISystems[parentPage.UISystems.IndexOf(this) - 1].Bottom + parentPage.Settings.SystemSpacing);
            return Math.Round(parentPage.UISystems.Last().Bottom + parentPage.Settings.SystemSpacing);

        }

        public double Bottom
        {
            get { return GetTop(this) + CalculatedHeight; }
        }

        public double CalculatedHeight
        {
            get { return ((6 * 5) + Metrics.Staff.Spacing) * Staves.Count - Metrics.Staff.Spacing; }
        }

        /// <summary>
        /// Adds a staff and adjusts the bar line
        /// </summary>
        /// <param name="staff"></param>
        public void AddStaff(UIStaff staff)
        {
            Staves.Add(staff);
            SetLeft(staff, 0);
            Children.Add(staff);

            BarlineFront.Y2 = GetTop(staff) + 24;
        }

        /// <summary>
        /// Returns the next UISystem, even if it is on the next page.
        /// </summary>
        public UISystem NextUISystem
        {
            get
            {
                if (ParentPage == null || ParentPage.UISystems == null) return null;
                var index = ParentPage.UISystems.IndexOf(this);
                if (index > -1 && ParentPage.UISystems.Count > index + 1)
                    return ParentPage.UISystems[index + 1];

                if (MainWindow.PageList == null) return null;
                var pageIndex = MainWindow.PageList.IndexOf(ParentPage);
                if (MainWindow.PageList.Count > pageIndex + 1 && MainWindow.PageList[pageIndex + 1].UISystems.Count > 0)
                    return MainWindow.PageList[pageIndex + 1].UISystems[0];
                return null;
            }
        }

        /// <summary>
        /// Returns the previous UISystem, even if it is on the previous page.
        /// </summary>
        public UISystem PreviousUISystem
        {
            get
            {
                if (ParentPage == null || ParentPage.UISystems == null) return null;
                var index = ParentPage.UISystems.IndexOf(this);
                if (index > 0)
                    return ParentPage.UISystems[index - 1];

                if (MainWindow.PageList == null) return null;
                var pageIndex = MainWindow.PageList.IndexOf(ParentPage);
                if (pageIndex > 0 && MainWindow.PageList[pageIndex - 1].UISystems.Count > 0)
                    return MainWindow.PageList[pageIndex - 1].UISystems.Last();
                return null;
            }
        }
    }
}