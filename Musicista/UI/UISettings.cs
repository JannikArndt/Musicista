using Model.View;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Musicista.UI
{
    public class UISettings
    {
        public readonly Metrics Metrics = new Metrics();

        public UISettings()
        {
            Metrics = new Metrics
            {
                Width = 841, // A0 in mm
                Height = 1189,
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

        public int Width
        {
            get { return Metrics.Width; }
            set { Metrics.Width = value; }
        }

        public int Height
        {
            get { return Metrics.Height; }
            set { Metrics.Height = value; }
        }

        public double MarginTop
        {
            get { return Metrics.MarginTop; }
            set { Metrics.MarginTop = value; }
        }

        public double MarginBelowTitle
        {
            get { return Metrics.MarginBelowTitle; }
            set { Metrics.MarginBelowTitle = value; }
        }

        public double StaffSpacing
        {
            get { return Metrics.StaffSpacing; }
            set
            {
                Metrics.StaffSpacing = value;
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
            get { return Metrics.SystemSpacing; }
            set
            {
                Metrics.SystemSpacing = value;
                if (MainWindow.PageList == null || MainWindow.PageList.Count == 0) return;
                foreach (var uiPage in MainWindow.PageList)
                    foreach (var uiSystem in uiPage.Systems)
                        Canvas.SetTop(uiSystem, uiSystem.CalculateTop(uiPage));
            }
        }

        public double SystemMarginLeft
        {
            get { return Metrics.SystemMarginLeft; }
            set { Metrics.SystemMarginLeft = value; }
        }

        public double SystemMarginRight
        {
            get { return Metrics.SystemMarginRight; }
            set { Metrics.SystemMarginRight = value; }
        }
    }
}