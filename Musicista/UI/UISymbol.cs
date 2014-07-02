using Model;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Musicista.UI
{
    public class UISymbol : Canvas
    {
        public UIMeasure ParentMeasure { get; set; }
        public Symbol Symbol { get; set; }
        public double CanvasLeft { get { return GetLeft(this); } set { SetLeft(this, value); } }

        public double TopRelativeToMeasure = -20;

        public int BeatsPerMeasure { get; set; }
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

        public UISymbol(bool hasMouseDown = true)
        {
            Background = Brushes.Transparent;
            SetTop(this, TopRelativeToMeasure);
            Height = 300;
            Width = 100;
            if (hasMouseDown)
                MouseDown += ClickToSelectSymbols;
        }

        private void ClickToSelectSymbols(object sender, MouseButtonEventArgs args)
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
    }
}
