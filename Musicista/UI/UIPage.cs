using Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Musicista.UI
{
    public class UIPage : Canvas
    {
        public List<UISystem> Systems = new List<UISystem>();
        public UITitle Title { get; set; }
        public UISettings Settings { get; set; }
        public Piece Piece { get; set; }
        public UIPage(bool firstPage = false)
        {
            Settings = new UISettings(firstPage);

            Width = 841; // A0 in mm
            Height = 1189;
            Margin = new Thickness(0, 20, 0, 0);
            VerticalAlignment = VerticalAlignment.Top;
            Background = Brushes.White;
            LayoutTransform = new ScaleTransform(1, 1);
            Effect = new DropShadowEffect { RenderingBias = RenderingBias.Performance };
            SetZIndex(this, 0);

            MouseDown += delegate
            {
                if (MainWindow.SidebarInformation != null)
                    MainWindow.SidebarInformation.ShowPiece();
                if (MainWindow.SidebarView != null)
                    MainWindow.SidebarView.ShowPageSettings(this);
                foreach (var uiMeasure in UIHelper.SelectedUIMeasures)
                    uiMeasure.Background = Brushes.Transparent;
                UIHelper.SelectedUIMeasures.Clear();
            };
        }
    }
}
