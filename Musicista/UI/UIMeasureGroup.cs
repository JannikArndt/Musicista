using Model.Extensions;
using Model.Sections;
using Model.Sections.Attributes;
using Model.Sections.Notes;
using Musicista.UI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Duration = Model.Sections.Notes.Duration;

namespace Musicista.UI
{
    public class UIMeasureGroup : Canvas
    {
        public readonly MeasureGroup InnerMeasureGroup = new MeasureGroup();
        public readonly UISystem ParentUISystem;

        private double _indent = 10;
        private double _marginRight = 4;
        public double Indent
        {
            get { return _indent; }
            set { _indent = value; }
        }
        public double MarginRight
        {
            get { return _marginRight; }
            set { _marginRight = value; }
        }
        public double BeatsPerMeasure { get { return (4.0 / InnerMeasureGroup.TimeSignature.BeatUnit) * InnerMeasureGroup.TimeSignature.Beats; } }

        private readonly bool _hasMouseDown = true;

        private Line _barline1;
        private Line _barline2;

        public TextBlock MeasureNumberTextBlock = new TextBlock
        {
            FontSize = 10,
            Width = 20,
            HorizontalAlignment = HorizontalAlignment.Left,
            TextAlignment = TextAlignment.Left
        };

        public List<UIMeasure> UIMeasures = new List<UIMeasure>();

        public FontFamily EmmentalerFont = new FontFamily(new Uri("pack://application:,,,/"), "./UI/MeasureElements/#Emmentaler 26");
        public FontFamily TimesFont = new FontFamily("Times New Roman");

        public UIMeasureGroup(UISystem uiSystem, MeasureGroup innerMeasureGroup, bool hasMouseDown = true)
        {
            if (innerMeasureGroup == null)
                throw new ArgumentException(@"No innerMeasureGroup given", "innerMeasureGroup");

            InnerMeasureGroup = innerMeasureGroup;
            ParentUISystem = uiSystem;
            ParentUISystem.UIMeasureGroups.Add(this);
            _hasMouseDown = hasMouseDown;


            Height = ParentUISystem.ActualHeight;
            Background = Brushes.Transparent;

            SetTop(this, 0);
            SetLeft(this, PreviousUIMeasureGroupInSystem != null ? PreviousUIMeasureGroupInSystem.Right : 0);

            SetBinding(WidthProperty,
                new Binding
                {
                    Path = new PropertyPath(WidthProperty),
                    Source = ParentUISystem,
                    Converter = new MeasureWidthConverter(),
                    ConverterParameter = ParentUISystem
                });

            // Measure number
            if (ParentUISystem.UIMeasureGroups.IndexOf(this) == 0 && InnerMeasureGroup.MeasureNumber > 1)
            {
                MeasureNumberTextBlock.Text = "" + InnerMeasureGroup.MeasureNumber;
                SetTop(MeasureNumberTextBlock, -16);
                SetLeft(MeasureNumberTextBlock, 0);
                Children.Add(MeasureNumberTextBlock);
            }

            // Rehearsal Mark
            if (InnerMeasureGroup.RehearsalMarkSpecified)
                DrawRehearsalMark(InnerMeasureGroup.RehearsalMark);

            // Repetition signs (segno, coda, D.S. al Fine, ...)
            if (InnerMeasureGroup.Repetition != Repetition.None)
                DrawRepetition(InnerMeasureGroup.Repetition);

            // Tempo markings
            foreach (var tempo in InnerMeasureGroup.Tempi)
                DrawTempo(tempo);

            // PropertyChangedEvent
            InnerMeasureGroup.PropertyChanged += (sender, args) => Redraw();

            // edit Buttons
            if (hasMouseDown)
                DrawEditButtons();

            ParentUISystem.Children.Add(this);

            Draw();
        }

        private void DrawTempo(Tempo tempo)
        {
            var textBlock = new TextBlock
                {
                    FontSize = 18,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    TextAlignment = TextAlignment.Center,
                    FontFamily = TimesFont,
                    FontWeight = FontWeights.Bold,
                    Text = tempo.TempoText
                };

            var left = ((Width - Indent - MarginRight) / BeatsPerMeasure * (tempo.Beat - 1)) + Indent;

            // for the first measure of a system
            if (ParentUISystem.UIMeasureGroups.IndexOf(this) == 0)
                left = 30;

            SetTop(textBlock, -30);
            SetLeft(textBlock, left);
            Children.Add(textBlock);
        }

        private void DrawRepetition(Repetition repetition)
        {
            TextBlock textBlock;
            if (repetition == Repetition.SegnoSign || repetition == Repetition.CodaSign)
            {
                textBlock = new TextBlock
                {
                    FontSize = repetition == Repetition.SegnoSign ? 25 : 30,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    TextAlignment = TextAlignment.Center,
                    FontFamily = EmmentalerFont,
                    FontWeight = FontWeights.Bold,
                    Text = repetition == Repetition.SegnoSign ? Char.ConvertFromUtf32(0xE180) : Char.ConvertFromUtf32(0xE181)
                };

                SetTop(textBlock, repetition == Repetition.SegnoSign ? -48 : -54);
                SetLeft(textBlock, 0);

                // for the first measure of a system
                if (ParentUISystem.UIMeasureGroups.IndexOf(this) == 0)
                    SetLeft(textBlock, 30);
            }
            else
            {
                textBlock = new TextBlock
                {
                    FontSize = 12,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    TextAlignment = TextAlignment.Center,
                    FontFamily = TimesFont,
                    FontStyle = FontStyles.Italic,
                    Text = repetition.GetDescription(),
                    TextWrapping = TextWrapping.WrapWithOverflow,
                    Width = 50
                };

                SetTop(textBlock, 30);
                SetLeft(textBlock, Width - 40);
            }
            Children.Add(textBlock);

        }

        private void DrawRehearsalMark(string text)
        {
            var border = new Border
            {
                BorderThickness = new Thickness(2),
                Width = 25,
                Height = 25,
                BorderBrush = Brushes.Black
            };

            if (text.Count() > 1)
                border.Width = 40;

            var textBlock = new TextBlock
            {
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                FontFamily = TimesFont,
                FontWeight = FontWeights.Bold,
                Text = text
            };
            border.Child = textBlock;
            SetTop(border, -35);
            SetLeft(border, -14);

            // for the first measure of a system
            if (ParentUISystem.UIMeasureGroups.IndexOf(this) == 0)
                SetLeft(border, 25);

            Children.Add(border);
        }

        public double Right
        {
            get { return GetLeft(this) + Width; }
        }

        public UIMeasureGroup NextUIMeasureGroup
        {
            get
            {
                var index = ParentUISystem.UIMeasureGroups.IndexOf(this);
                if (index > -1 && ParentUISystem.UIMeasureGroups.Count > index + 1)
                    return ParentUISystem.UIMeasureGroups[index + 1];
                if (ParentUISystem.NextUISystem != null && ParentUISystem.NextUISystem.UIMeasureGroups != null &&
                    ParentUISystem.NextUISystem.UIMeasureGroups.Count > 0 && ParentUISystem.NextUISystem.UIMeasureGroups[0] != null)
                    return ParentUISystem.NextUISystem.UIMeasureGroups[0];
                return null;
            }
        }

        public UIMeasureGroup PreviousUIMeasureGroup
        {
            get
            {
                var index = ParentUISystem.UIMeasureGroups.IndexOf(this);
                if (index > 0)
                    return ParentUISystem.UIMeasureGroups[index - 1];
                if (ParentUISystem.PreviousUISystem != null && ParentUISystem.PreviousUISystem.UIMeasureGroups != null &&
                    ParentUISystem.PreviousUISystem.UIMeasureGroups.Count > 0 && ParentUISystem.PreviousUISystem.UIMeasureGroups.Last() != null)
                    return ParentUISystem.PreviousUISystem.UIMeasureGroups.Last();
                return null;
            }
        }

        private UIMeasureGroup PreviousUIMeasureGroupInSystem
        {
            get
            {
                var index = ParentUISystem.UIMeasureGroups.IndexOf(this);
                if (index > 0)
                    return ParentUISystem.UIMeasureGroups[index - 1];
                return null;
            }
        }

        public void Draw()
        {
            if (InnerMeasureGroup.Barlines.Any(item => item.Type == BarlineType.StartRepeat))
                Indent += 10;

            // Correct parent-relations
            foreach (var measure in InnerMeasureGroup.Measures)
                measure.ParentMeasureGroup = InnerMeasureGroup;

            for (var part = 0; part < InnerMeasureGroup.Measures.Count; part++)
                UIMeasures.Add(new UIMeasure(this, part + 1, InnerMeasureGroup.Measures[part], hasMouseDown: _hasMouseDown));

            // set connecting barlines
            foreach (var barline in InnerMeasureGroup.Barlines)
                DrawBarline(barline);
            if (InnerMeasureGroup.Barlines.All(item => item.Location != BarlineLocation.Right))
                DrawBarline(new Barline { Location = BarlineLocation.Right, Type = BarlineType.Single });
        }

        private void DrawBarline(Barline barline)
        {
            double x1;
            double x2;
            var thickness1 = 1.5;
            var thickness2 = 1.5;
            var show1 = true;
            var show2 = true;

            switch (barline.Location)
            {
                case BarlineLocation.Right:
                    x1 = Width - 5;
                    x2 = Width - 1;
                    break;
                case BarlineLocation.Beat:
                    x1 = ((Width - Indent - MarginRight) / BeatsPerMeasure * (barline.Beat - 1)) + Indent;
                    x2 = 0;
                    break;
                default:
                    x1 = 0;
                    x2 = 4;
                    break;
            }

            switch (barline.Type)
            {
                case BarlineType.Single:
                    show1 = false;
                    break;
                case BarlineType.StartRepeat:
                    thickness1 = 3.5;
                    DrawRepeatDots(x2 + 3);
                    break;
                case BarlineType.EndRepeat:
                    thickness2 = 3.5;
                    x1 -= 0.7;
                    x2 -= 0.7;
                    DrawRepeatDots(x1 - 5);
                    break;
                case BarlineType.Double:
                    thickness1 = 1.2;
                    thickness2 = 1.2;
                    x1 += 1;
                    break;
                case BarlineType.Final:
                    thickness2 = 3.5;
                    x1 -= 0.7;
                    x2 -= 0.7;
                    break;
                case BarlineType.Invisible:
                    show1 = show2 = false;
                    break;
                case BarlineType.Dashed:
                    show1 = false;
                    break;
                default:
                    show1 = false;
                    break;
            }

            _barline1 = new Line
            {
                X1 = x1,
                Y1 = 0,
                X2 = x1,
                Y2 = GetTop(UIMeasures.Last()) + 34,
                StrokeThickness = thickness1,
                Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x30, 0x30)),
                SnapsToDevicePixels = Properties.Settings.Default.SnapsToDevicePixels
            };

            _barline2 = new Line
            {
                X1 = x2,
                Y1 = 0,
                X2 = x2,
                Y2 = GetTop(UIMeasures.Last()) + 34,
                StrokeThickness = thickness2,
                Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x30, 0x30)),
                SnapsToDevicePixels = Properties.Settings.Default.SnapsToDevicePixels
            };

            if (barline.Type == BarlineType.Dashed)
                _barline2.StrokeDashArray = new DoubleCollection { 4, 0 };

            if (show1) Children.Add(_barline1);
            if (show2) Children.Add(_barline2);
        }

        private void DrawRepeatDots(double x)
        {
            var dot1 = new Ellipse
            {
                Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x30, 0x30)),
                Width = 3,
                Height = 3
            };

            var dot2 = new Ellipse
            {
                Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x30, 0x30)),
                Width = 3,
                Height = 3
            };

            SetTop(dot1, 7.5);
            SetLeft(dot1, x);

            SetTop(dot2, 13.5);
            SetLeft(dot2, x);

            Children.Add(dot1);
            Children.Add(dot2);
        }

        private void DrawEditButtons()
        {
            var delete = new Path
            {
                Data = Geometry.Parse("F0 M 16,8 C 16,12 12,16 8,16 C 4,16 0,12 0,8 C 0,4 4,0 8,0 C 12,0 16,4 16,8 Z M 4,3 L 3,4 L 7,8 L 3,12 L 4,13 L 8,9 L 12,13 L 13,12 L 9,8 L 13,4 L 12,3 L 8,7 L 4,3 Z "),
                Fill = Brushes.PaleVioletRed,
                RenderTransform = new ScaleTransform(0.9, 0.9),
                Cursor = Cursors.Hand
            };

            var add = new Path
            {
                Data = Geometry.Parse("F0 M 16,8 C 16,12 12,16 8,16 C 4,16 0,12 0,8 C 0,4 4,0 8,0 C 12,0 16,4 16,8 Z M 7,3 L 9,3 L 9,7 L 13,7 L 13,9 L 9,9 L 9,13 L 7,13 L 7,9 L 3,9 L 3,7 L 7,7 Z "),
                Fill = Brushes.LightGreen,
                RenderTransform = new ScaleTransform(0.9, 0.9),
                Cursor = Cursors.Hand
            };

            delete.MouseDown += DeleteMeasureGroup;
            add.MouseDown += AddMeasureGroup;

            delete.SetBinding(VisibilityProperty, new Binding { Path = new PropertyPath(VisibilityProperty), Source = MainWindow.TinyNotationTextBox });
            add.SetBinding(VisibilityProperty, new Binding { Path = new PropertyPath(VisibilityProperty), Source = MainWindow.TinyNotationTextBox });

            SetTop(delete, -22);
            SetLeft(delete, Width - 25);

            SetTop(add, -22);
            SetLeft(add, Width - 8);

            Children.Add(delete);
            Children.Add(add);
        }

        public void DeleteMeasureGroup(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            InnerMeasureGroup.ParentPassage.MeasureGroups.Remove(InnerMeasureGroup);

            // Correct measure numbers
            var measureNumber = InnerMeasureGroup.ParentPassage.ParentSegment.ParentMovement.MeasureGroups[0].MeasureNumber;
            foreach (var measureGroup in InnerMeasureGroup.ParentPassage.ParentSegment.ParentMovement.MeasureGroups)
                measureGroup.MeasureNumber = measureNumber++;

            // Redraw whole piece 
            MainWindow.ReDrawPiece();
        }

        public void AddMeasureGroup(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var index = InnerMeasureGroup.ParentPassage.MeasureGroups.IndexOf(InnerMeasureGroup);
            var newMeasureGroup = new MeasureGroup
            {
                MeasureNumber = InnerMeasureGroup.MeasureNumber + 1,
                KeySignature = InnerMeasureGroup.KeySignature,
                TimeSignature = InnerMeasureGroup.TimeSignature,
                ParentPassage = InnerMeasureGroup.ParentPassage,
                Measures = new List<Measure>()
            };
            foreach (var measure in InnerMeasureGroup.Measures)
            {
                newMeasureGroup.Measures.Add(new Measure
                {
                    Instrument = measure.Instrument,
                    Clef = measure.Clef,
                    ParentMeasureGroup = measure.ParentMeasureGroup,
                    Staff = measure.Staff,
                    Symbols = new List<Symbol> { new Rest { Beat = 1.0, Duration = Duration.Whole } }
                });
            }

            var finalBarline = InnerMeasureGroup.Barlines.FirstOrDefault(bl => bl.Type == BarlineType.Final);
            if (finalBarline != null)
            {
                InnerMeasureGroup.Barlines.Remove(finalBarline);
                newMeasureGroup.Barlines.Add(finalBarline);
            }

            InnerMeasureGroup.ParentPassage.MeasureGroups.Insert(index + 1, newMeasureGroup);

            // Correct measure numbers
            var measureNumber = InnerMeasureGroup.ParentPassage.ParentSegment.ParentMovement.MeasureGroups[0].MeasureNumber;
            foreach (var measureGroup in InnerMeasureGroup.ParentPassage.ParentSegment.ParentMovement.MeasureGroups)
                measureGroup.MeasureNumber = measureNumber++;

            // Redraw whole piece 
            MainWindow.ReDrawPiece();

        }

        public void Redraw()
        {
            // Save selection
            var selectedUIMeasure = UIHelper.SelectedUIMeasures.FirstOrDefault();
            var part = 0;
            if (selectedUIMeasure != null)
                part = selectedUIMeasure.ParentUIMeasureGroup.UIMeasures.IndexOf(selectedUIMeasure);

            foreach (var child in Children.OfType<UIMeasure>().ToList())
                Children.Remove(child);

            // TODO remove barline as well

            UIMeasures.Clear();
            Draw();

            // Restore selection
            if (UIMeasures.Count > part && part > -1)
            {
                UIMeasures[part].Background = UIHelper.SelectColor;
                UIHelper.SelectedUIMeasures.Clear();
                UIHelper.SelectedUIMeasures.Add(UIMeasures[part]);
            }
        }
    }
}