
using System.Linq;
using System.Windows.Controls;

namespace Musicista.UI
{
    public class UISettings
    {
        public double MarginTop { get; set; }
        public double MarginBelowTitle { get; set; }
        public double StaffSpacing
        {
            get { return _staffSpacing; }
            set
            {
                _staffSpacing = value;
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
            get { return _systemSpacing; }
            set
            {
                _systemSpacing = value;
                if (MainWindow.PageList == null || MainWindow.PageList.Count == 0) return;
                foreach (var uiSystem in MainWindow.PageList.SelectMany(page => page.Systems))
                    Canvas.SetTop(uiSystem, uiSystem.CalculateTop());
            }
        }

        public double SystemMarginLeft { get; set; }
        public double SystemMarginRight { get; set; }

        private double _systemSpacing;
        private double _staffSpacing;

        public UISettings(bool firstPage = false)
        {
            MarginTop = 60;
            MarginBelowTitle = 60;
            _staffSpacing = 50;
            _systemSpacing = 60;
            SystemMarginLeft = 50;
            SystemMarginRight = 50;
        }
    }
}
