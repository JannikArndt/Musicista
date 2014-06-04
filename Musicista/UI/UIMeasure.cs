using Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UIMeasure : Canvas
    {
        public readonly Measure InnerMeasure = new Measure();
        public readonly UISystem ParentSystem;
        public readonly UIStaff ParentStaff;
        public readonly UIMeasureGroup ParentMeasureGroup;
        public readonly int Part;
        public readonly int Indent = 60;
        public readonly int ScaleTransform = 5;

        public readonly List<Path> NotYetConnectedEigths = new List<Path>();
        public readonly List<Path> NotYetConnectedSixteenths = new List<Path>();
        public bool StemDirectionUp = true;
        public bool ConnectEigthsAtEndOfRun = false;
        public bool ConnectSixteenthsAtEndOfRun = false;

        public Line Line1 { get; set; }
        public Line Line2 { get; set; }
        public Line Line3 { get; set; }
        public Line Line4 { get; set; }
        public Line Line5 { get; set; }

        public UIMeasure(UIMeasureGroup parentMeasureGroup, double top, int part, Measure innerMeasure = null, UISystem system = null, UIStaff staff = null, bool suppressEventHandlers = false)
        {
            Height = 40 * ScaleTransform;
            Background = Brushes.Transparent;
            Part = part;
            ParentStaff = staff;
            ParentSystem = system;
            ParentMeasureGroup = parentMeasureGroup;
            RenderTransform = new ScaleTransform(1.0 / ScaleTransform, 1.0 / ScaleTransform);

            SetTop(this, top);
            SetLeft(this, 0);

            SetBinding(WidthProperty, new Binding { Path = new PropertyPath(WidthProperty), Source = parentMeasureGroup, Converter = new Multiplier(), ConverterParameter = ScaleTransform });

            InnerMeasure = innerMeasure;

            Barline = new Line
            {
                X1 = Width,
                Y1 = 50,
                X2 = Width,
                Y2 = 175,
                StrokeThickness = 2 * ScaleTransform,
                Stroke = Brushes.DimGray,
                SnapsToDevicePixels = true
            };
            Barline.SetBinding(Line.X1Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Barline.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            //Barline.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

            Children.Add(Barline);

            if (!suppressEventHandlers)
            {
                MouseLeftButtonDown += MainWindow.DragStart;
                MouseMove += MainWindow.Drag;
                MouseLeftButtonUp += MainWindow.DragEnd;

                PreviewMouseDown += delegate(object sender, MouseButtonEventArgs args)
                {
                    if (MainWindow.SidebarInformation != null)
                        MainWindow.SidebarInformation.ShowUIElement(sender);
                };
            }

            parentMeasureGroup.Children.Add(this);

            // Lines
            var spacing = 6 * ScaleTransform;
            Line1 = new Line { X1 = 0, Y1 = 50 + 0 * spacing, X2 = Width, Y2 = 50 + 0 * spacing, StrokeThickness = 1 * ScaleTransform, Stroke = Brushes.DimGray, SnapsToDevicePixels = true };
            Line2 = new Line { X1 = 0, Y1 = 50 + 1 * spacing, X2 = Width, Y2 = 50 + 1 * spacing, StrokeThickness = 1 * ScaleTransform, Stroke = Brushes.DimGray, SnapsToDevicePixels = true };
            Line3 = new Line { X1 = 0, Y1 = 50 + 2 * spacing, X2 = Width, Y2 = 50 + 2 * spacing, StrokeThickness = 1 * ScaleTransform, Stroke = Brushes.DimGray, SnapsToDevicePixels = true };
            Line4 = new Line { X1 = 0, Y1 = 50 + 3 * spacing, X2 = Width, Y2 = 50 + 3 * spacing, StrokeThickness = 1 * ScaleTransform, Stroke = Brushes.DimGray, SnapsToDevicePixels = true };
            Line5 = new Line { X1 = 0, Y1 = 50 + 4 * spacing, X2 = Width, Y2 = 50 + 4 * spacing, StrokeThickness = 1 * ScaleTransform, Stroke = Brushes.DimGray, SnapsToDevicePixels = true };

            Line1.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line2.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line3.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line4.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });
            Line5.SetBinding(Line.X2Property, new Binding { Path = new PropertyPath(WidthProperty), Source = this });

            Line1.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            Line2.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            Line3.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            Line4.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            Line5.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

            Children.Add(Line1);
            Children.Add(Line2);
            Children.Add(Line3);
            Children.Add(Line4);
            Children.Add(Line5);
        }

        public Line Barline { get; set; }

        public override string ToString()
        {
            if (InnerMeasure.ParentMeasureGroup != null)
                return "Measure #" + InnerMeasure.ParentMeasureGroup.MeasureNumber;
            return "Measure";
        }

        public void ConnectEigths()
        {
            var x1 = GetLeft(NotYetConnectedEigths.First());
            var y1 = GetTop(NotYetConnectedEigths.First());
            var x2 = GetLeft(NotYetConnectedEigths.Last());
            var y2 = GetTop(NotYetConnectedEigths.Last());

            if (StemDirectionUp)
            {
                x1 += 34;
                x2 += 38;
            }
            else
            {
                y1 += 225;
                x2 += 5;
                y2 += 225;
            }

            for (var count = 0; count < 25; count = count + 5)
            {
                var beam = new Line
                {
                    X1 = x1,
                    Y1 = y1 + count,
                    X2 = x2,
                    Y2 = y2 + count,
                    StrokeThickness = 5,
                    Stroke = Brushes.Black,
                    SnapsToDevicePixels = true
                };
                Children.Add(beam);
            }
            NotYetConnectedEigths.Clear();
        }

        public void ConnectSixteenths()
        {
            var x1 = GetLeft(NotYetConnectedSixteenths.First());
            var y1 = GetTop(NotYetConnectedSixteenths.First());
            var x2 = GetLeft(NotYetConnectedSixteenths.Last());
            var y2 = GetTop(NotYetConnectedSixteenths.Last());

            if (StemDirectionUp)
            {
                x1 += 34;
                x2 += 38;
            }
            else
            {
                y1 += 225;
                x2 += 5;
                y2 += 225;
            }

            for (var beamCount = 0; beamCount < 2; beamCount++)
            {
                for (var count = 0; count < 20; count = count + 5)
                {
                    var beam = new Line
                    {
                        X1 = x1,
                        Y1 = y1 + count,
                        X2 = x2,
                        Y2 = y2 + count,
                        StrokeThickness = 5,
                        Stroke = Brushes.Black,
                        SnapsToDevicePixels = true
                    };
                    Children.Add(beam);
                }
                if (StemDirectionUp)
                {
                    y1 += 25;
                    y2 += 25;
                }
                else
                {
                    y1 -= 25;
                    y2 -= 25;
                }
            }
            NotYetConnectedSixteenths.Clear();
        }
    }
}