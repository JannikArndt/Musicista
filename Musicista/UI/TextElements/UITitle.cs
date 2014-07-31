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
            FontSize = 50;
            SetBinding(Canvas.TopProperty, "Settings.MarginTop");
            Left = 20;
            Width = ParentPage.Width - 40;
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