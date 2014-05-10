using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Musicista.UI
{
    public class UITitle : TextBlock
    {
        private int _left;
        private int _top;

        public UITitle(string text, int top, Canvas page)
        {
            Text = text;
            FontSize = 50;

            Top = top;
            // center title
            Left = (int)((page.Width / 2) - (DrawnWidth / 2));

            PreviewMouseDown += delegate(object sender, MouseButtonEventArgs args)
            {
                if (MainWindow.SidebarInformation != null)
                    MainWindow.SidebarInformation.ShowUIElement(sender);
            };

            page.Children.Add(this);
        }

        public int Top
        {
            get { return _top; }
            set
            {
                _top = value;
                Canvas.SetTop(this, value);
            }
        }

        public int Left
        {
            get { return _left; }
            set
            {
                _left = value;
                Canvas.SetLeft(this, value);
            }
        }

        public int DrawnWidth
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
                return (int)formattedText.Width;
            }
        }

        public int DrawnHeight
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
                return (int)formattedText.Height;
            }
        }
    }
}