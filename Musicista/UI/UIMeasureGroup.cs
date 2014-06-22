using Model;
using Musicista.UI.Converters;
using System.Collections.Generic;
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

        public List<UIMeasure> Measures = new List<UIMeasure>();

        public UIMeasureGroup(UISystem system, double left, MeasureGroup innerMeasureGroup = null)
        {
            InnerMeasureGroup = innerMeasureGroup;
            ParentSystem = system;

            Height = system.ActualHeight;
            Background = Brushes.Transparent;

            SetTop(this, 0);
            SetLeft(this, left);
            SetBinding(WidthProperty,
                new Binding { Path = new PropertyPath(WidthProperty), Source = system, Converter = new MeasureWidthConverter(), ConverterParameter = system });

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

            Children.Add(Barline);

            system.Children.Add(this);
        }

        public Line Barline { get; set; }

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
    }
}