using Model;
using Model.Meta;
using System.Collections.Generic;
using System.Globalization;
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
        public int Indent = 60;
        public readonly int ScaleTransform = 5;

        public readonly List<Path> NotYetConnectedEigths = new List<Path>();
        public readonly List<Path> NotYetConnectedSixteenths = new List<Path>();
        public bool StemDirectionUp = true;
        public bool ConnectEigthsAtEndOfRun = false;
        public bool ConnectSixteenthsAtEndOfRun = false;

        public readonly List<Pitch> AlteredKeys = new List<Pitch>();

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

                    if (UIHelper.SelectedUIMeasure != null)
                        UIHelper.SelectedUIMeasure.Background = Brushes.Transparent;
                    Background = Brushes.SkyBlue;
                    UIHelper.SelectedUIMeasure = this;
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
            var shapeString = "";
            var addToX = StemDirectionUp ? 38 : 5;
            var addToY = StemDirectionUp ? 0 : 225;

            switch (NotYetConnectedEigths.Count)
            {
                case 2:
                    shapeString = "F0 M "
                        + (GetLeft(NotYetConnectedEigths[0]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedEigths[0]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + " L "
                        + (GetLeft(NotYetConnectedEigths[1]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedEigths[1]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + "";
                    break;
                case 4:
                    shapeString = "F0 M "
                        + (GetLeft(NotYetConnectedEigths[0]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedEigths[0]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + " C "
                        + (GetLeft(NotYetConnectedEigths[1]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedEigths[1]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + "  "
                        + (GetLeft(NotYetConnectedEigths[2]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedEigths[2]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + "  "
                        + (GetLeft(NotYetConnectedEigths[3]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedEigths[3]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + "";
                    break;
            }

            if (shapeString.Contains("F0 M 302,0"))
                shapeString += " ";

            var beam = new Path
            {
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                Data = Geometry.Parse(shapeString),
                StrokeThickness = 15
            };

            Children.Add(beam);
            NotYetConnectedEigths.Clear();
        }

        public void ConnectSixteenths()
        {
            var shapeString = "";
            var addToX = StemDirectionUp ? 34 : 5;
            var addToY = StemDirectionUp ? 0 : 225;
            var offsetSecondBeam = StemDirectionUp ? -25 : 25;

            switch (NotYetConnectedSixteenths.Count)
            {
                case 2:
                    shapeString = "F0 M "
                        + (GetLeft(NotYetConnectedSixteenths[0]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[0]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + " L "
                        + (GetLeft(NotYetConnectedSixteenths[1]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[1]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + " M "
                        + (GetLeft(NotYetConnectedSixteenths[0]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[0]) + addToY + offsetSecondBeam).ToString(CultureInfo.GetCultureInfo("en-US")) + " L "
                        + (GetLeft(NotYetConnectedSixteenths[1]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[1]) + addToY + offsetSecondBeam).ToString(CultureInfo.GetCultureInfo("en-US")) + "";
                    break;
                case 4:
                    shapeString = "F0 M "
                        + (GetLeft(NotYetConnectedSixteenths[0]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[0]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + " C "
                        + (GetLeft(NotYetConnectedSixteenths[1]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[1]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + "  "
                        + (GetLeft(NotYetConnectedSixteenths[2]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[2]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + "  "
                        + (GetLeft(NotYetConnectedSixteenths[3]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[3]) + addToY).ToString(CultureInfo.GetCultureInfo("en-US")) + " M "
                        + (GetLeft(NotYetConnectedSixteenths[0]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[0]) + addToY + offsetSecondBeam).ToString(CultureInfo.GetCultureInfo("en-US")) + " C "
                        + (GetLeft(NotYetConnectedSixteenths[1]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[1]) + addToY + offsetSecondBeam).ToString(CultureInfo.GetCultureInfo("en-US")) + "  "
                        + (GetLeft(NotYetConnectedSixteenths[2]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[2]) + addToY + offsetSecondBeam).ToString(CultureInfo.GetCultureInfo("en-US")) + "  "
                        + (GetLeft(NotYetConnectedSixteenths[3]) + addToX).ToString(CultureInfo.GetCultureInfo("en-US")) + "," + (GetTop(NotYetConnectedSixteenths[3]) + addToY + offsetSecondBeam).ToString(CultureInfo.GetCultureInfo("en-US")) + "";
                    break;
            }

            var beam = new Path
            {
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                Data = Geometry.Parse(shapeString),
                StrokeThickness = 10
            };

            Children.Add(beam);
            NotYetConnectedSixteenths.Clear();
        }
    }
}