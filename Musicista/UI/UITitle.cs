using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Musicista.UI
{
    public class UITitle : TextBlock
    {
        public UIPage ParentPage { get; set; }

        public UITitle(UIPage page)
        {
            ParentPage = page;

            DataContext = ParentPage;
            SetBinding(TextProperty, "Piece.Title");
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

        public double Left
        {
            get { return Canvas.GetLeft(this); }
            set { Canvas.SetLeft(this, value); }
        }

        public double DrawnWidth
        {
            get
            {
                var formattedText = new FormattedText(
                    Text,
                    CultureInfo.CurrentUICulture,
                    FlowDirection.LeftToRight,
                    new Typeface(FontFamily, FontStyle, FontWeight, FontStretch),
                    FontSize,
                    Brushes.Black);
                return formattedText.Width;
            }
        }

        public double DrawnHeight
        {
            get
            {
                var formattedText = new FormattedText(
                    Text,
                    CultureInfo.CurrentUICulture,
                    FlowDirection.LeftToRight,
                    new Typeface(FontFamily, FontStyle, FontWeight, FontStretch),
                    FontSize,
                    Brushes.Black);
                return formattedText.Height;
            }
        }
    }
}