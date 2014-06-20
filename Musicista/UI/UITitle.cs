using Model;
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

        public UITitle(Piece piece, double top, UIPage page)
        {
            ParentPage = page;
            DataContext = piece;
            SetBinding(TextProperty, "Title");
            FontSize = 50;

            Top = top;
            Left = 20;
            Width = page.Width - 40;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            TextAlignment = TextAlignment.Center;

            PreviewMouseDown += delegate(object sender, MouseButtonEventArgs args)
            {
                if (MainWindow.SidebarInformation != null)
                    MainWindow.SidebarInformation.ShowUIElement(sender);
            };

            page.Children.Add(this);
        }

        public double Top
        {
            get { return Canvas.GetTop(this); }
            set { Canvas.SetTop(this, value); }
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