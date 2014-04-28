using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UIPage
    {
        public Rectangle Page { get; set; }
        private int _top;
        private int _left;
        private int _width;
        private int _height;

        public int Top
        {
            get { return _top; }
            set
            {
                this._top = value;
                Canvas.SetTop(Page, value);
            }
        }
        public int Left
        {
            get { return _left; }
            set
            {
                this._left = value;
                Canvas.SetLeft(Page, value);
            }
        }
        public int Width
        {
            get { return _width; }
            set
            {
                this._width = value;
                Page.Width = value;
            }
        }
        public int Height
        {
            get { return _height; }
            set
            {
                this._height = value;
                Page.Height = value;
            }
        }

        public UIPage(int top, int left, int width, int height)
        {
            DropShadowEffect shadow = new DropShadowEffect
            {
                BlurRadius = 500,
                RenderingBias = RenderingBias.Performance,
                Opacity = .3,
                ShadowDepth = 20
            };

            Page = new Rectangle
            {
                Width = width,
                Height = height,
                Fill = Brushes.White,
                Effect = new DropShadowEffect()
            };

            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }
    }
}
