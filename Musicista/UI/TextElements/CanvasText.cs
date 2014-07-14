using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Musicista.UI.TextElements
{
    public class CanvasText : TextBlock
    {
        public UIPage ParentPage { get; set; }

        public CanvasText(UIPage page)
        {
            ParentPage = page;
        }

        public double Left
        {
            get { return Canvas.GetLeft(this); }
            set { Canvas.SetLeft(this, value); }
        }

        public double Right
        {
            get { return Canvas.GetRight(this); }
            set { Canvas.SetRight(this, value); }
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