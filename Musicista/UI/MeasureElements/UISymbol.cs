using Model;
using Musicista.UI.Enums;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Musicista.UI.MeasureElements
{
    public class UISymbol : Canvas
    {
        public UIMeasure ParentMeasure { get; set; }
        public Symbol Symbol { get; set; }
        public double CanvasLeft { get { return GetLeft(this); } set { SetLeft(this, value); } }

        public double TopRelativeToMeasure = -20;

        public double BeatsPerMeasure { get; set; }
        public UISymbol NextUISymbol
        {
            get
            {
                var index = ParentMeasure.Symbols.IndexOf(this);
                if (ParentMeasure.Symbols.Count > index + 1)
                    return ParentMeasure.Symbols[index + 1];
                if (ParentMeasure.NextUIMeasure != null && ParentMeasure.NextUIMeasure.Symbols != null && ParentMeasure.NextUIMeasure.Symbols.Count > 0)
                    return ParentMeasure.NextUIMeasure.Symbols[0];
                return null;
            }
        }

        public UISymbol(Symbol symbol, UIMeasure parentUIMeasure, bool hasMouseDown = true)
        {
            Symbol = symbol;
            ParentMeasure = parentUIMeasure;
            ParentMeasure.Symbols.Add(this);

            Background = Brushes.Transparent;
            SetTop(this, TopRelativeToMeasure);
            Height = 300;
            Width = 100;
            if (hasMouseDown)
                MouseDown += ClickToSelectSymbols;

            if (Symbol.Lyrics.Count > 0)
            {
                Text.Inlines.Add(String.Join(Environment.NewLine, Symbol.Lyrics.Select(item => item.Text)));
                SetTop(Text, 260);
                SetLeft(Text, 0);
                Children.Add(Text);
            }
        }

        public TextBlock Text = new TextBlock
        {
            FontSize = 60,
            Width = 200,
            HorizontalAlignment = HorizontalAlignment.Left,
            TextAlignment = TextAlignment.Left
        };

        public void ClickToSelectSymbols(object sender, MouseButtonEventArgs args)
        {
            if (UIHelper.SelectedUISymbols.Contains(this) || UIHelper.SelectionModeIsMeasures)
                return;

            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                if (UIHelper.SelectedUISymbols.Contains(this))
                {
                    Background = Brushes.Transparent;
                    UIHelper.SelectedUISymbols.Remove(this);
                }
                else
                {
                    UIHelper.SelectedUISymbols.Add(this);
                    Background = UIHelper.SelectColor;
                }
            }
            else if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                var next = UIHelper.SelectedUISymbols.FirstOrDefault();
                // first click on an earlier symbol
                if (next != null && (ParentMeasure.MeasureNumber > next.ParentMeasure.MeasureNumber
                    || (ParentMeasure.MeasureNumber == next.ParentMeasure.MeasureNumber && Symbol.Beat > next.Symbol.Beat)))
                {
                    while (next != null && !Equals(next, this))
                    {
                        next.Background = UIHelper.SelectColor;
                        UIHelper.SelectedUISymbols.Add(next);
                        next = next.NextUISymbol;
                    }
                    Background = UIHelper.SelectColor;
                    UIHelper.SelectedUISymbols.Add(this);
                }
                // first click on a later symbol
                else if (next != null)
                {
                    var final = next;
                    next = this;
                    while (next != null && !Equals(next, final))
                    {
                        next.Background = UIHelper.SelectColor;
                        UIHelper.SelectedUISymbols.Add(next);
                        next = next.NextUISymbol;
                    }
                    final.Background = UIHelper.SelectColor;
                    UIHelper.SelectedUISymbols.Add(final);
                }
                UIHelper.SelectedUISymbols = UIHelper.SelectedUISymbols.Distinct().ToList();
            }
            else
            {
                foreach (var uiSymbol in UIHelper.SelectedUISymbols)
                    uiSymbol.Background = Brushes.Transparent;
                UIHelper.SelectedUISymbols.Clear();
                Background = UIHelper.SelectColor;
                UIHelper.SelectedUISymbols.Add(this);
            }
            args.Handled = true;

            if (MainWindow.SidebarInformation != null)
                MainWindow.SidebarInformation.ShowUIElement(sender);

            foreach (var uiMeasure in UIHelper.SelectedUIMeasures)
                uiMeasure.Background = Brushes.Transparent;
            UIHelper.SelectedUIMeasures.Clear();
        }

        public Point GetFreePoint(Direction direction)
        {
            var left = GetLeft(this) + 10;

            if (GetType() == typeof(UIRest))
            {
                if (direction == Direction.Below)
                    return new Point(left, 200);
                return new Point(left, 0);

            }

            var thisNote = (UINote)this;
            if (direction == Direction.Above)
                if (thisNote.StemDirection == StemDirection.Up)
                    return new Point(left, Math.Min(0, thisNote.Stem.Y2 - 60));
                else
                    return new Point(left, Math.Min(0, GetTop(thisNote.NoteHead) - 60));

            if (direction == Direction.Below)
                if (thisNote.StemDirection == StemDirection.Down)
                    return new Point(left, Math.Max(220, thisNote.Stem.Y2 + 40));
                else
                    return new Point(left, Math.Max(100, GetTop(thisNote.NoteHead) + 60));

            return new Point(left, 0);
        }

        public Direction BestFreeSpot()
        {
            if (GetType() == typeof(UIRest))
                return Direction.Above;

            var thisNote = (UINote)this;

            if (thisNote.StemDirection == StemDirection.Up)
                if (thisNote.Stem.Y2 > 140)
                    return Direction.Below;
                else
                    return Direction.Above;

            if (thisNote.StemDirection == StemDirection.Down)
                if (thisNote.Stem.Y2 < 100)
                    return Direction.Above;
                else
                    return Direction.Below;

            return Direction.Above;
        }
    }
}
