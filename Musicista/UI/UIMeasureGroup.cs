using Model;
using Musicista.UI.Converters;
using Musicista.UI.MeasureElements;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UIMeasureGroup : Canvas
    {
        public readonly MeasureGroup InnerMeasureGroup = new MeasureGroup();
        public readonly UISystem ParentSystem;

        private readonly bool _hasMouseDown = true;

        public TextBlock MeasureNumberTextBlock = new TextBlock
        {
            FontSize = 10,
            Width = 20,
            HorizontalAlignment = HorizontalAlignment.Left,
            TextAlignment = TextAlignment.Left
        };

        public List<UIMeasure> Measures = new List<UIMeasure>();

        public UIMeasureGroup(UISystem system, MeasureGroup innerMeasureGroup = null, bool hasMouseDown = true)
        {
            InnerMeasureGroup = innerMeasureGroup;
            ParentSystem = system;
            ParentSystem.MeasureGroups.Add(this);
            _hasMouseDown = hasMouseDown;


            Height = ParentSystem.ActualHeight;
            Background = Brushes.Transparent;

            SetTop(this, 0);
            SetLeft(this, PreviousUIMeasureGroupInSystem != null ? PreviousUIMeasureGroupInSystem.Right : 0);

            SetBinding(WidthProperty,
                new Binding
                {
                    Path = new PropertyPath(WidthProperty),
                    Source = ParentSystem,
                    Converter = new MeasureWidthConverter(),
                    ConverterParameter = ParentSystem
                });

            Barline = new Line
            {
                X1 = Width,
                Y1 = 0,
                X2 = Width,
                Y2 = 24,
                StrokeThickness = 2,
                Stroke = Brushes.DimGray
            };
            Barline.SetBinding(Line.X1Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Barline.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });

            // Measure number
            if (InnerMeasureGroup != null && ParentSystem.MeasureGroups.IndexOf(this) == 0 && InnerMeasureGroup.MeasureNumber > 1)
            {
                MeasureNumberTextBlock.Text = "" + InnerMeasureGroup.MeasureNumber;
                SetTop(MeasureNumberTextBlock, -16);
                SetLeft(MeasureNumberTextBlock, 0);
                Children.Add(MeasureNumberTextBlock);
            }

            // PropertyChangedEvent
            if (InnerMeasureGroup != null)
                InnerMeasureGroup.PropertyChanged += (sender, args) => Redraw();

            Children.Add(Barline);
            ParentSystem.Children.Add(this);
        }

        public Line Barline { get; set; }

        public double Right
        {
            get { return GetLeft(this) + Width; }
        }

        public UIMeasureGroup NextUIMeasureGroup
        {
            get
            {
                var index = ParentSystem.MeasureGroups.IndexOf(this);
                if (index > -1 && ParentSystem.MeasureGroups.Count > index + 1)
                    return ParentSystem.MeasureGroups[index + 1];
                if (ParentSystem.NextUISystem != null && ParentSystem.NextUISystem.MeasureGroups != null &&
                    ParentSystem.NextUISystem.MeasureGroups.Count > 0 && ParentSystem.NextUISystem.MeasureGroups[0] != null)
                    return ParentSystem.NextUISystem.MeasureGroups[0];
                return null;
            }
        }

        public UIMeasureGroup PreviousUIMeasureGroup
        {
            get
            {
                var index = ParentSystem.MeasureGroups.IndexOf(this);
                if (index > 0)
                    return ParentSystem.MeasureGroups[index - 1];
                if (ParentSystem.PreviousUISystem != null && ParentSystem.PreviousUISystem.MeasureGroups != null &&
                    ParentSystem.PreviousUISystem.MeasureGroups.Count > 0 && ParentSystem.PreviousUISystem.MeasureGroups.Last() != null)
                    return ParentSystem.PreviousUISystem.MeasureGroups.Last();
                return null;
            }
        }

        private UIMeasureGroup PreviousUIMeasureGroupInSystem
        {
            get
            {
                var index = ParentSystem.MeasureGroups.IndexOf(this);
                if (index > 0)
                    return ParentSystem.MeasureGroups[index - 1];
                return null;
            }
        }

        public void Draw()
        {
            for (var part = 0; part < InnerMeasureGroup.Measures.Count; part++)
                DrawMeasure(InnerMeasureGroup.Measures[part], part + 1);
            // set connecting barlines
            if (Measures.Count > 0)
                Barline.Y2 = GetTop(Measures.Last()) + 36;
        }

        public void Redraw()
        {
            Children.Clear();
            Draw();
        }

        public void DrawMeasure(Measure measure, int part)
        {
            if (measure.Symbols == null || measure.Symbols.Count <= 0)
                return;

            var measureGroup = InnerMeasureGroup;

            var newMeasure = new UIMeasure(this, part, measure, hasMouseDown: _hasMouseDown);
            Measures.Add(newMeasure);

            // Draw clef changes
            if (measure.Previous == null || !Equals(measure.Clef, measure.Previous.Clef) || ParentSystem.MeasureGroups.IndexOf(this) == 0)
                newMeasure.Children.Add(new UIClef(measure.Clef, newMeasure));

            // Draw key signature changes
            if (measureGroup.Previous == null || !Equals(measureGroup.KeySignature, measureGroup.Previous.KeySignature) ||
                ParentSystem.MeasureGroups.IndexOf(this) == 0)
                newMeasure.Children.Add(new UIKeySignature(measureGroup.KeySignature, measure.Clef, newMeasure));

            // Draw meter changes
            if (measureGroup.Previous == null || !Equals(measureGroup.Previous.TimeSignature, measureGroup.TimeSignature))
                newMeasure.Children.Add(new UITimeSignature(measureGroup.TimeSignature, newMeasure));

            // If the width is smaller than the indent, there is no room for any notes. Return without drawing
            if (newMeasure.Width - newMeasure.Indent < 1)
                return;

            // Draw tied notes
            if (newMeasure.PreviousUIMeasure != null)
                foreach (var symbol in newMeasure.PreviousUIMeasure.TiedNotes.OfType<Note>())
                    new UINote(symbol, newMeasure, _hasMouseDown, true);

            // Draw notes
            foreach (var symbol in measure.Symbols)
                if (symbol.GetType() == typeof(Note))
                    new UINote((Note)symbol, newMeasure, _hasMouseDown);
                else if (symbol.GetType() == typeof(Rest))
                    new UIRest((Rest)symbol, newMeasure, _hasMouseDown);

            newMeasure.CorrectTextVerticalAlignment();
        }
    }
}