using Model;
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
        public Line Barline { get; set; }

        public List<UIMeasure> Measures = new List<UIMeasure>();

        public UIMeasureGroup(UISystem system, double left, MeasureGroup innerMeasureGroup = null)
        {
            Height = system.ActualHeight;
            Background = Brushes.Transparent;
            ParentSystem = system;

            SetTop(this, 0);
            SetLeft(this, left);

            SetBinding(WidthProperty, new Binding { Path = new PropertyPath(WidthProperty), Source = system, Converter = new MeasureWidthConverter(), ConverterParameter = system });

            InnerMeasureGroup = innerMeasureGroup;

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

            /*
            MouseLeftButtonDown += MainWindow.DragStart;
            MouseMove += MainWindow.Drag;
            MouseLeftButtonUp += MainWindow.DragEnd;
            */

            system.Children.Add(this);
        }
    }
}
