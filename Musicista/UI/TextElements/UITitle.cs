using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Musicista.UI.TextElements
{
    public class UITitle : CanvasText
    {
        public UITitle(UIPage page)
            : base(page)
        {
            DataContext = ParentPage;
            SetBinding(TextProperty, "Piece.Meta.Title");
            FontSize = page.Settings.Metrics.Fontsize.Title;
            SetBinding(Canvas.TopProperty, "Settings.MarginTop");
            Left = (page.Settings.Metrics.Margin.Left + page.Settings.Metrics.Margin.Right) / 2;
            Width = ParentPage.Width - (page.Settings.Metrics.Margin.Left + page.Settings.Metrics.Margin.Right);
            Canvas.SetTop(this, ParentPage.Settings.Metrics.Margin.Top);
            TextWrapping = TextWrapping.Wrap;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            TextAlignment = TextAlignment.Center;

            PreviewMouseDown += delegate(object sender, MouseButtonEventArgs args)
            {
                if (MainWindow.SidebarInformation != null)
                    MainWindow.SidebarInformation.ShowUIElement(sender);
            };

            ParentPage.Children.Add(this);
        }
    }
}