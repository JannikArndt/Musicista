﻿using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Musicista.UI
{
    public class UITitle
    {
        string Text { get; set; }
        public TextBlock TitleTextBlock { get; set; }

        private int _top;
        private int _left;

        public int Top
        {
            get { return _top; }
            set
            {
                this._top = value;
                Canvas.SetTop(TitleTextBlock, value);
            }
        }
        public int Left
        {
            get { return _left; }
            set
            {
                this._left = value;
                Canvas.SetLeft(TitleTextBlock, value);
            }
        }
        public int Width
        {
            get
            {
                var formattedText = new FormattedText(
                   Text,
                   CultureInfo.CurrentUICulture,
                   FlowDirection.LeftToRight,
                   new Typeface(TitleTextBlock.FontFamily, TitleTextBlock.FontStyle, TitleTextBlock.FontWeight, TitleTextBlock.FontStretch),
                   TitleTextBlock.FontSize,
                   Brushes.Black);
                return (int)formattedText.Width;
            }
        }
        public int Height
        {
            get
            {
                var formattedText = new FormattedText(
                   Text,
                   CultureInfo.CurrentUICulture,
                   FlowDirection.LeftToRight,
                   new Typeface(TitleTextBlock.FontFamily, TitleTextBlock.FontStyle, TitleTextBlock.FontWeight, TitleTextBlock.FontStretch),
                   TitleTextBlock.FontSize,
                   Brushes.Black);
                return (int)formattedText.Height;
            }
        }

        public UITitle(string text, int top, int left)
        {
            Text = text;

            TitleTextBlock = new TextBlock
            {
                Text = text,
                FontSize = 50
            };

            Canvas.SetTop(TitleTextBlock, top);
            Canvas.SetLeft(TitleTextBlock, left);
        }
    }
}
