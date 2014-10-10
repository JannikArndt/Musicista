using Model.View;
using System.Windows.Controls;

namespace Musicista.UI
{
    public class UISettings
    {
        public readonly Metrics Metrics = new Metrics();

        public UISettings()
        {
            Metrics = new Metrics(841, 1189, 50, 60, 50, 0, 60, 50, 60);
        }

        public double Width
        {
            get { return Metrics.Page.Width; }
            set { Metrics.Page.Width = value; }
        }

        public double Height
        {
            get { return Metrics.Page.Height; }
            set { Metrics.Page.Height = value; }
        }

        public double MarginTop
        {
            get { return Metrics.Margin.Top; }
            set { Metrics.Margin.Top = value; }
        }

        public double MarginBelowTitle
        {
            get { return Metrics.Margin.BelowTitle; }
            set { Metrics.Margin.BelowTitle = value; }
        }

        public double StaffSpacing
        {
            get { return Metrics.Staff.Spacing; }
            set
            {
                Metrics.Staff.Spacing = value;
                if (MainWindow.PageList == null || MainWindow.PageList.Count == 0) return;
                foreach (var uiPage in MainWindow.PageList)
                    foreach (var uiSystem in uiPage.Systems)
                    {
                        foreach (var uiStaff in uiSystem.Staves)
                            Canvas.SetTop(uiStaff, uiStaff.CalculateStaffTop());
                        Canvas.SetTop(uiSystem, uiSystem.CalculateTop(uiPage));
                    }
            }
        }

        public double SystemSpacing
        {
            get { return Metrics.System.Spacing; }
            set
            {
                Metrics.System.Spacing = value;
                if (MainWindow.PageList == null || MainWindow.PageList.Count == 0) return;
                foreach (var uiPage in MainWindow.PageList)
                    foreach (var uiSystem in uiPage.Systems)
                        Canvas.SetTop(uiSystem, uiSystem.CalculateTop(uiPage));
            }
        }

        public double SystemMarginLeft
        {
            get { return Metrics.Margin.Left; }
            set { Metrics.Margin.Left = value; }
        }

        public double SystemMarginRight
        {
            get { return Metrics.Margin.Right; }
            set { Metrics.Margin.Right = value; }
        }
    }
}