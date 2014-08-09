using Model.View;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Musicista.UI
{
    public class UISettings
    {
        private readonly Metrics _metrics = new Metrics();

        public UISettings()
        {
            _metrics = new Metrics
            {
                MarginTop = 60,
                MarginBelowTitle = 60,
                StaffSpacing = 50,
                SystemSpacing = 60,
                SystemMarginLeft = 50,
                SystemMarginRight = 50,
                MeasuresPerSystemThreshold = 60,
                MeasuresPerSystem = new List<int>()
            };
        }

        public double MarginTop
        {
            get { return _metrics.MarginTop; }
            set { _metrics.MarginTop = value; }
        }

        public double MarginBelowTitle
        {
            get { return _metrics.MarginBelowTitle; }
            set { _metrics.MarginBelowTitle = value; }
        }

        public double StaffSpacing
        {
            get { return _metrics.StaffSpacing; }
            set
            {
                _metrics.StaffSpacing = value;
                if (MainWindow.PageList == null || MainWindow.PageList.Count == 0) return;
                foreach (var uiSystem in MainWindow.PageList.SelectMany(page => page.Systems))
                {
                    foreach (var uiStaff in uiSystem.Staves)
                        Canvas.SetTop(uiStaff, uiStaff.CalculateStaffTop());
                    Canvas.SetTop(uiSystem, uiSystem.CalculateTop());
                }
            }
        }

        public double SystemSpacing
        {
            get { return _metrics.SystemSpacing; }
            set
            {
                _metrics.SystemSpacing = value;
                if (MainWindow.PageList == null || MainWindow.PageList.Count == 0) return;
                foreach (var uiSystem in MainWindow.PageList.SelectMany(page => page.Systems))
                    Canvas.SetTop(uiSystem, uiSystem.CalculateTop());
            }
        }

        public double SystemMarginLeft
        {
            get { return _metrics.SystemMarginLeft; }
            set { _metrics.SystemMarginLeft = value; }
        }

        public double SystemMarginRight
        {
            get { return _metrics.SystemMarginRight; }
            set { _metrics.SystemMarginRight = value; }
        }
    }
}