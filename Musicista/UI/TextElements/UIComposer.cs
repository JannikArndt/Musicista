using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Musicista.UI.TextElements
{
    public class UIComposer : CanvasText
    {
        public UIComposer(UIPage page)
            : base(page)
        {
            DataContext = ParentPage;
            SetBinding(TextProperty, "Piece.Meta.People.ComposersAsString");
            FontSize = ParentPage.Settings.Metrics.Fontsize.Composer;

            Canvas.SetTop(this, 150);
            Canvas.SetRight(this, 50);

            Width = 200;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            TextAlignment = TextAlignment.Right;
            TextWrapping = TextWrapping.WrapWithOverflow;

            PreviewMouseDown += delegate(object sender, MouseButtonEventArgs args)
            {
                if (MainWindow.SidebarInformation != null)
                    MainWindow.SidebarInformation.ShowUIElement(sender);
            };

            ParentPage.Children.Add(this);
        }
    }
}