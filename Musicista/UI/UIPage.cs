using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Musicista.UI
{
    public class UIPage : Canvas
    {
        public UIPage()
        {
            Width = 841; // A0 in mm
            Height = 1189;
            Margin = new Thickness(0, 20, 0, 0);
            VerticalAlignment = VerticalAlignment.Top;
            Background = Brushes.White;
            LayoutTransform = new ScaleTransform(1, 1);
            Effect = new DropShadowEffect { RenderingBias = RenderingBias.Performance };
            SetZIndex(this, 0);

            PreviewMouseDown += delegate
            {
                if (MainWindow.SidebarInformation != null)
                    MainWindow.SidebarInformation.ShowPiece();
                if (UIHelper.SelectedUIMeasure != null)
                    UIHelper.SelectedUIMeasure.Background = Brushes.Transparent;
            };
        }
    }
}
