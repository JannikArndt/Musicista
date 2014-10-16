using Model;
using Musicista.UI.TextElements;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Musicista.UI
{
    /// <summary>
    /// The top UI class which represents one page with several UISystems, title and composer on it.
    /// </summary>
    public class UIPage : Canvas
    {
        public List<UISystem> UISystems = new List<UISystem>();

        public UIPage(bool hasMouseDown = true)
        {
            Settings = new UISettings();

            Width = Settings.Metrics.Page.Width;
            Height = Settings.Metrics.Page.Height;
            Margin = new Thickness(0, 20, 0, 0);
            VerticalAlignment = VerticalAlignment.Top;
            Background = Brushes.White;
            LayoutTransform = new ScaleTransform(1, 1);
            Effect = new DropShadowEffect { RenderingBias = RenderingBias.Performance };
            SetZIndex(this, 0);

            if (hasMouseDown)
                MouseDown += delegate
                {
                    if (MainWindow.SidebarInformation != null)
                        MainWindow.SidebarInformation.ShowPiece();
                    if (MainWindow.SidebarView != null)
                        MainWindow.SidebarView.ShowPageSettings(this);

                    UIHelper.UnselectAll();
                };
        }

        public UITitle Title { get; set; }
        public UIComposer Composer { get; set; }
        public UISettings Settings { get; set; }
        public Piece Piece { get; set; }
    }
}