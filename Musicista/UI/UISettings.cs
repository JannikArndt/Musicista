using Model.View;
using System.Windows.Controls;

namespace Musicista.UI
{
    /// <summary>
    /// The UI class that handles the metrics
    /// </summary>
    public class UISettings
    {
        public readonly Metrics Metrics = new Metrics();

        public UISettings()
        {
            Metrics = new Metrics(width: 794, height: 1122, marginLeft: 50, marginTop: 60, marginRight: 50, marginBottom: 0, marginBelowTitle: 60,
                staffSpacing: 50, systemSpacing: 60, titleSize: 50, movementSize: 30, composerSize: 16);
        } //794*1122   841*1189

        public double StaffSpacing
        {
            get { return Metrics.Staff.Spacing; }
            set
            {
                Metrics.Staff.Spacing = value;
                if (MainWindow.PageList == null || MainWindow.PageList.Count == 0) return;
                foreach (var uiPage in MainWindow.PageList)
                    foreach (var uiSystem in uiPage.UISystems)
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
                    foreach (var uiSystem in uiPage.UISystems)
                        Canvas.SetTop(uiSystem, uiSystem.CalculateTop(uiPage));
            }
        }
    }
}