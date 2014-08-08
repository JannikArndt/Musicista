using Model.Extensions;
using Model.Sections.Notes;
using Model.Sections.Notes.Articulation;
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
        public UIMeasure ParentUIMeasure { get; set; }
        public Symbol Symbol { get; set; }
        public double CanvasLeft { get { return GetLeft(this); } set { SetLeft(this, value); } }

        public double TopRelativeToMeasure = -20;

        public FontFamily EmmentalerFont = new FontFamily(new Uri("pack://application:,,,/"), "./UI/MeasureElements/#Emmentaler 26");

        public double BeatsPerMeasure { get { return ParentUIMeasure.ParentUIMeasureGroup.BeatsPerMeasure; } }
        public UISymbol NextUISymbol
        {
            get
            {
                var index = ParentUIMeasure.Symbols.IndexOf(this);
                if (ParentUIMeasure.Symbols.Count > index + 1)
                    return ParentUIMeasure.Symbols[index + 1];
                if (ParentUIMeasure.NextUIMeasure != null && ParentUIMeasure.NextUIMeasure.Symbols != null && ParentUIMeasure.NextUIMeasure.Symbols.Count > 0)
                    return ParentUIMeasure.NextUIMeasure.Symbols[0];
                return null;
            }
        }

        public UISymbol(Symbol symbol, UIMeasure parentUIMeasure, bool hasMouseDown = true)
        {
            Symbol = symbol;
            ParentUIMeasure = parentUIMeasure;
            ParentUIMeasure.Symbols.Add(this);

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
                if (next != null && (ParentUIMeasure.MeasureNumber > next.ParentUIMeasure.MeasureNumber
                    || (ParentUIMeasure.MeasureNumber == next.ParentUIMeasure.MeasureNumber && Symbol.Beat > next.Symbol.Beat)))
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

        public void HandleArticulation(Articulation articulation)
        {
            if (articulation.Dynamics != Dynamics.None)
                DrawDynamics(articulation.Dynamics);
            if (articulation.Accent != Accent.None)
                DrawAccent(articulation.Accent);
            if (articulation.Trill)
                DrawTrill();
            if (articulation.Bowing != Bowing.None)
                DrawBowing(articulation.Bowing);
            if (articulation.Fermata != Fermata.None)
                DrawFermata(articulation.Fermata);
            if (articulation.Ornament != Ornament.None)
                DrawOrnament(articulation.Ornament);
            if (articulation.Dolce)
                WriteArticulationText("dolce");
            if (articulation.Espressivo)
                WriteArticulationText("espress.");
            if (articulation.Legato)
                WriteArticulationText("legato");
            if (articulation.Tremolo)
                WriteArticulationText("tremolo");
            if (!string.IsNullOrEmpty(articulation.Other))
                WriteArticulationText(articulation.Other);
            if (articulation.Arpeggiate || articulation.Caesura || articulation.Damping || articulation.MuteForSerializationSpecified
                || articulation.Sliding != Sliding.None || articulation.Slur != Slur.None)
            {
                // TODO
            }
        }

        private void WriteArticulationText(string text)
        {
            var textBlock = new TextBlock
            {
                FontSize = 60,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextAlignment = TextAlignment.Left,
                FontFamily = new FontFamily("Times New Roman"),
                FontStyle = FontStyles.Italic,
                Text = text
            };

            var point = GetFreePoint(Direction.Below);

            SetTop(textBlock, point.Y);
            SetLeft(textBlock, -10);
            Children.Add(textBlock);
        }

        private void DrawAccent(Accent accent)
        {
            var accentText = new TextBlock
            {
                FontSize = 130,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextAlignment = TextAlignment.Left,
                FontFamily = EmmentalerFont
            };

            switch (accent)
            {
                case Accent.Standard:
                    accentText.Text = Char.ConvertFromUtf32(0xE16A); break;
                case Accent.Staccato:
                    accentText.Text = Char.ConvertFromUtf32(0xE16C); break;
                case Accent.Staccatissimo:
                    accentText.Text = Char.ConvertFromUtf32(0xE16D); break;
                case Accent.Tenuto:
                    accentText.Text = Char.ConvertFromUtf32(0xE16F); break;
                case Accent.Marcato:
                    accentText.Text = Char.ConvertFromUtf32(0xE172); break;
                case Accent.Portato:
                    accentText.Text = Char.ConvertFromUtf32(0xE171); break;
            }

            var point = GetFreePoint(Direction.Above);

            SetTop(accentText, point.Y - 160);
            SetLeft(accentText, 30);
            Children.Add(accentText);
        }

        private void DrawBowing(Bowing bowing)
        {
            TextBlock bowingText;
            if (bowing == Bowing.Arco || bowing == Bowing.Pizzicato)
            {
                bowingText = new TextBlock
                {
                    FontSize = 60,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    TextAlignment = TextAlignment.Left,
                    FontStyle = FontStyles.Italic,
                    FontFamily = new FontFamily("Times New Roman"),
                    Text = bowing == Bowing.Arco ? "arco" : "pizz."
                };
                var point = GetFreePoint(Direction.Above);

                SetTop(bowingText, point.Y - 50);
                SetLeft(bowingText, 20);
            }
            else
            {
                bowingText = new TextBlock
                {
                    FontSize = 130,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    TextAlignment = TextAlignment.Left,
                    FontFamily = EmmentalerFont
                };

                switch (bowing)
                {
                    case Bowing.Down:
                        bowingText.Text = Char.ConvertFromUtf32(0xE176);
                        break;
                    case Bowing.Up:
                        bowingText.Text = Char.ConvertFromUtf32(0xE177);
                        break;
                    case Bowing.OpenString:
                        bowingText.Text = Char.ConvertFromUtf32(0xE174);
                        break;
                    case Bowing.Spiccato:
                        bowingText.Text = Char.ConvertFromUtf32(0xE12F);
                        break;
                }

                var point = GetFreePoint(Direction.Above);

                SetTop(bowingText, point.Y - 160);
                SetLeft(bowingText, 40);
            }
            Children.Add(bowingText);
        }

        private void DrawTrill()
        {
            var trillText = new TextBlock
            {
                FontSize = 140,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextAlignment = TextAlignment.Left,
                FontFamily = EmmentalerFont,
                Text = Char.ConvertFromUtf32(0xE17A)
            };

            var point = GetFreePoint(Direction.Above);

            SetTop(trillText, point.Y - 160);
            SetLeft(trillText, 40);
            Children.Add(trillText);
        }

        private void DrawFermata(Fermata fermata)
        {
            var fermataText = new TextBlock
            {
                FontSize = 130,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextAlignment = TextAlignment.Left,
                FontFamily = EmmentalerFont
            };

            switch (fermata)
            {
                case Fermata.Standard:
                    fermataText.Text = Char.ConvertFromUtf32(0xE161); break;
                case Fermata.Short:
                    fermataText.Text = Char.ConvertFromUtf32(0xE163); break;
                case Fermata.Long:
                    fermataText.Text = Char.ConvertFromUtf32(0xE165); break;
            }

            var point = GetFreePoint(Direction.Above);

            SetTop(fermataText, point.Y - 160);
            SetLeft(fermataText, 40);
            Children.Add(fermataText);
        }

        public void DrawDynamics(Dynamics dynamics)
        {
            var scale = 1.1 - (dynamics.GetDescription().Count() / 10.0);
            var dynamicsText = new TextBlock
            {
                FontSize = 140 * scale,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextAlignment = TextAlignment.Left,
                FontFamily = EmmentalerFont,
                Text = dynamics.GetDescription()
            };

            var point = GetFreePoint(Direction.Below);

            SetTop(dynamicsText, point.Y - 210 + (90 / (scale)));
            SetLeft(dynamicsText, -10 * (1 / (2 * scale)));
            Children.Add(dynamicsText);
        }

        private void DrawOrnament(Ornament ornament)
        {
            var ornamentText = new TextBlock
            {
                FontSize = 130,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextAlignment = TextAlignment.Left,
                FontFamily = EmmentalerFont
            };
            var left = 40;

            switch (ornament)
            {
                case Ornament.Turn:
                    ornamentText.Text = Char.ConvertFromUtf32(0xE179); break;
                case Ornament.InvertedTurn:
                    ornamentText.Text = Char.ConvertFromUtf32(0xE178); break;
                case Ornament.DelayedTurn:
                    ornamentText.Text = Char.ConvertFromUtf32(0xE179);
                    left += 50; break;
                case Ornament.DelayedInvertedTurn:
                    ornamentText.Text = Char.ConvertFromUtf32(0xE178);
                    left += 50; break;
                case Ornament.Mordent:
                    ornamentText.Text = Char.ConvertFromUtf32(0xE18D); break;
                case Ornament.InvertedMordent:
                    ornamentText.Text = Char.ConvertFromUtf32(0xE18C); break;
                //case Ornament.WavyLine:
                //    ornamentText.Text = Char.ConvertFromUtf32(0xE18E) + Char.ConvertFromUtf32(0xE18E); break;
            }

            var point = GetFreePoint(Direction.Above);

            SetTop(ornamentText, point.Y - 160);
            SetLeft(ornamentText, left);
            Children.Add(ornamentText);
        }
    }
}
