using Model;
using Model.Meta;
using Musicista.UI.Converters;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Duration = Model.Duration;

namespace Musicista.UI
{
    public class UIMeasure : Canvas
    {
        public readonly Measure InnerMeasure = new Measure();
        public readonly UISystem ParentSystem;
        public readonly UIStaff ParentStaff;
        public readonly UIMeasureGroup ParentMeasureGroup;
        public List<UISymbol> Symbols = new List<UISymbol>();
        public int MeasureNumber { get { return ParentMeasureGroup.InnerMeasureGroup.MeasureNumber; } }

        public List<UINote> Notes
        {
            get { return Symbols.Where(item => item.GetType() == typeof(UINote)).Cast<UINote>().ToList(); }
        }

        public List<UIRest> Rests
        {
            get { return Symbols.Where(item => item.GetType() == typeof(UIRest)).Cast<UIRest>().ToList(); }
        }
        public readonly int Part;
        public int Indent = 60;
        public readonly int ScaleTransform = 5;

        public readonly List<UINote> NotYetConnectedNotes = new List<UINote>();
        public bool StemDirectionUp = true;
        public bool ConnectNotesAtEndOfRun = false;

        public readonly List<Pitch> AlteredKeys = new List<Pitch>();

        public Line Line1 { get; set; }
        public Line Line2 { get; set; }
        public Line Line3 { get; set; }
        public Line Line4 { get; set; }
        public Line Line5 { get; set; }

        public UIMeasure(UIMeasureGroup parentMeasureGroup, int part, Measure innerMeasure, UISystem system = null, UIStaff staff = null, double top = -1, bool suppressEventHandlers = false)
        {
            InnerMeasure = innerMeasure;
            ParentStaff = staff;
            ParentSystem = system;
            ParentMeasureGroup = parentMeasureGroup;

            Height = 54 * ScaleTransform;
            Background = Brushes.Transparent;
            Part = part;


            RenderTransform = new ScaleTransform(1.0 / ScaleTransform, 1.0 / ScaleTransform);

            if (top < 0)
                SetBinding(TopProperty, new Binding { Path = new PropertyPath(TopProperty), Source = ParentMeasureGroup.ParentSystem.Staves[part - 1], Converter = new Adder(), ConverterParameter = -10 });
            else
                SetTop(this, top);
            SetLeft(this, 0);

            SetBinding(WidthProperty, new Binding { Path = new PropertyPath(WidthProperty), Source = parentMeasureGroup, Converter = new Multiplier(), ConverterParameter = ScaleTransform });

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

                MouseDown += ClickToSelectMeasures;
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

        private void ClickToSelectMeasures(object sender, MouseButtonEventArgs args)
        {
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                if (UIHelper.SelectedUIMeasures.Contains(this))
                {
                    Background = Brushes.Transparent;
                    UIHelper.SelectedUIMeasures.Remove(this);
                }
                else
                {
                    UIHelper.SelectedUIMeasures.Add(this);
                    Background = UIHelper.SelectColor;
                }
            }
            else if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                var next = UIHelper.SelectedUIMeasures.FirstOrDefault();
                // first click on an earlier measure
                if (next != null && ParentMeasureGroup.InnerMeasureGroup.MeasureNumber > next.ParentMeasureGroup.InnerMeasureGroup.MeasureNumber)
                {
                    while (next != null && next != this)
                    {
                        next.Background = UIHelper.SelectColor;
                        UIHelper.SelectedUIMeasures.Add(next);
                        next = next.NextUIMeasure;
                    }
                    Background = UIHelper.SelectColor;
                    UIHelper.SelectedUIMeasures.Add(this);
                }
                // first click on a later measure
                else if (next != null)
                {
                    var final = next;
                    next = this;
                    while (next != null && next != final)
                    {
                        next.Background = UIHelper.SelectColor;
                        UIHelper.SelectedUIMeasures.Add(next);
                        next = next.NextUIMeasure;
                    }
                    final.Background = UIHelper.SelectColor;
                    UIHelper.SelectedUIMeasures.Add(final);
                }
                UIHelper.SelectedUIMeasures = UIHelper.SelectedUIMeasures.Distinct().ToList();
            }
            else
            {
                foreach (var uiMeasure in UIHelper.SelectedUIMeasures)
                    uiMeasure.Background = Brushes.Transparent;
                UIHelper.SelectedUIMeasures.Clear();
                Background = UIHelper.SelectColor;
                UIHelper.SelectedUIMeasures.Add(this);
            }
            args.Handled = true;

            foreach (var uiSymbol in UIHelper.SelectedUISymbols)
                uiSymbol.Background = Brushes.Transparent;
            UIHelper.SelectedUISymbols.Clear();

            if (MainWindow.SidebarInformation != null)
                MainWindow.SidebarInformation.ShowUIElement(sender);
        }

        public UIMeasure NextUIMeasure
        {
            get
            {
                if (ParentMeasureGroup == null || ParentMeasureGroup.NextUIMeasureGroup == null) return null;
                var currentIndex = ParentMeasureGroup.Measures.IndexOf(this);
                if (currentIndex > -1 && ParentMeasureGroup.NextUIMeasureGroup.Measures.Count > currentIndex)
                    return ParentMeasureGroup.NextUIMeasureGroup.Measures[currentIndex];
                return null;
            }
        }

        public Line Barline { get; set; }

        public override string ToString()
        {
            if (InnerMeasure.ParentMeasureGroup != null)
                return "Measure #" + InnerMeasure.ParentMeasureGroup.MeasureNumber;
            return "Measure";
        }

        public void ConnectNotes()
        {
            var onlyEights = NotYetConnectedNotes.All(item => item.Note.Duration == Duration.eigth);
            var onlySixteenths = NotYetConnectedNotes.All(item => item.Note.Duration == Duration.sixteenth);

            var shapeString = "";
            var c = CultureInfo.GetCultureInfo("en-US");

            int addToX, addToY, offsetSecondBeam = 0, strokeThickness;
            if (onlyEights)
            {
                addToX = StemDirectionUp ? 45 : 5; // 38 : 5;
                addToY = StemDirectionUp ? -15 : 200;
                strokeThickness = 15;
            }
            else
            {
                addToX = StemDirectionUp ? 45 : 5;
                addToY = StemDirectionUp ? -15 : 200;
                offsetSecondBeam = StemDirectionUp ? 25 : -25;
                strokeThickness = 13;
            }

            // Basic eigths-beam for eigths and sixteenths
            switch (NotYetConnectedNotes.Count)
            {
                case 2:
                    shapeString = "F0 M "
                        + (NotYetConnectedNotes[0].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[0].PathTop + addToY).ToString(c) + " L "
                        + (NotYetConnectedNotes[1].CanvasLeft + addToX + 5).ToString(c) + "," + (NotYetConnectedNotes[1].PathTop + addToY).ToString(c) + "";
                    break;
                case 3:
                    shapeString = "F0 M "
                        + (NotYetConnectedNotes[0].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[0].PathTop + addToY).ToString(c) + " C "
                        + (NotYetConnectedNotes[1].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[1].PathTop + addToY).ToString(c) + "  "
                        + (NotYetConnectedNotes[1].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[1].PathTop + addToY).ToString(c) + "  "
                        + (NotYetConnectedNotes[2].CanvasLeft + addToX + 5).ToString(c) + "," + (NotYetConnectedNotes[2].PathTop + addToY).ToString(c) + "";
                    break;
                case 4:
                    shapeString = "F0 M "
                        + (NotYetConnectedNotes[0].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[0].PathTop + addToY).ToString(c) + " C "
                        + (NotYetConnectedNotes[1].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[1].PathTop + addToY).ToString(c) + "  "
                        + (NotYetConnectedNotes[2].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[2].PathTop + addToY).ToString(c) + "  "
                        + (NotYetConnectedNotes[3].CanvasLeft + addToX + 5).ToString(c) + "," + (NotYetConnectedNotes[3].PathTop + addToY).ToString(c) + "";
                    break;
            }

            // If all nots are sixteenths, draw the second beam
            if (onlySixteenths)
            {
                strokeThickness = 10;
                switch (NotYetConnectedNotes.Count)
                {
                    case 2:
                        shapeString += " M "
                            + (NotYetConnectedNotes[0].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[0].PathTop + addToY + offsetSecondBeam).ToString(c) + " L "
                            + (NotYetConnectedNotes[1].CanvasLeft + addToX + 5).ToString(c) + "," + (NotYetConnectedNotes[1].PathTop + addToY + offsetSecondBeam).ToString(c) + "";
                        break;
                    case 3:
                        shapeString += " M "
                            + (NotYetConnectedNotes[0].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[0].PathTop + addToY + offsetSecondBeam).ToString(c) + " C "
                            + (NotYetConnectedNotes[1].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[1].PathTop + addToY + offsetSecondBeam).ToString(c) + "  "
                            + (NotYetConnectedNotes[1].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[1].PathTop + addToY + offsetSecondBeam).ToString(c) + "  "
                            + (NotYetConnectedNotes[2].CanvasLeft + addToX + 5).ToString(c) + "," + (NotYetConnectedNotes[2].PathTop + addToY + offsetSecondBeam).ToString(c) + "";
                        break;
                    case 4:
                        shapeString += " M "
                            + (NotYetConnectedNotes[0].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[0].PathTop + addToY + offsetSecondBeam).ToString(c) + " C "
                            + (NotYetConnectedNotes[1].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[1].PathTop + addToY + offsetSecondBeam).ToString(c) + "  "
                            + (NotYetConnectedNotes[2].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[2].PathTop + addToY + offsetSecondBeam).ToString(c) + "  "
                            + (NotYetConnectedNotes[3].CanvasLeft + addToX + 5).ToString(c) + "," + (NotYetConnectedNotes[3].PathTop + addToY + offsetSecondBeam).ToString(c) + "";
                        break;
                }
            }

            // mixed eigths and sixteenths
            if (!onlyEights && !onlySixteenths)
            {
                // find pairs of two
                foreach (var uiNote in NotYetConnectedNotes.Where(uiNote => uiNote.NextUINote != null))
                {
                    // two sixteenths and some eights
                    if (uiNote.Note.Duration == Duration.sixteenth && uiNote.NextUINote.Note.Duration == Duration.sixteenth)
                        shapeString += " M "
                                       + (uiNote.CanvasLeft + addToX).ToString(c) + "," + (uiNote.PathTop + addToY + offsetSecondBeam).ToString(c) + " L "
                                       + (uiNote.NextUINote.CanvasLeft + addToX).ToString(c) + "," + (uiNote.NextUINote.PathTop + addToY + offsetSecondBeam).ToString(c) + "";
                    // dotted eigth followed by a sixteenth
                    if (uiNote.Note.Duration == Duration.eigthDotted && uiNote.NextUINote.Note.Duration == Duration.sixteenth)
                        shapeString += " M "
                                       + (uiNote.CanvasLeft + addToX + (uiNote.NextUINote.CanvasLeft - uiNote.CanvasLeft) * 0.6).ToString(c) + ","
                                       + (uiNote.PathTop + addToY + (uiNote.NextUINote.PathTop - uiNote.PathTop) * 0.6 + offsetSecondBeam).ToString(c) + " L "
                                       + (uiNote.NextUINote.CanvasLeft + addToX).ToString(c) + "," + (uiNote.NextUINote.PathTop + addToY + offsetSecondBeam).ToString(c) + "";
                    // sixteenth followed by a dotted eigth
                    if (uiNote.Note.Duration == Duration.sixteenth && uiNote.NextUINote.Note.Duration == Duration.eigthDotted)
                        shapeString += " M "
                                       + (NotYetConnectedNotes[1].CanvasLeft + addToX + (NotYetConnectedNotes[0].CanvasLeft - NotYetConnectedNotes[1].CanvasLeft) * 0.4).ToString(c) + ","
                                       + (NotYetConnectedNotes[1].PathTop + addToY + (NotYetConnectedNotes[0].PathTop - NotYetConnectedNotes[1].PathTop) * 0.4 + offsetSecondBeam).ToString(c) + " L "
                                       + (NotYetConnectedNotes[0].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[0].PathTop + addToY + offsetSecondBeam).ToString(c) + "";
                }
                // 16th - 8th - 16th
                if (NotYetConnectedNotes.Count == 3
                    && NotYetConnectedNotes[0].Note.Duration == Duration.sixteenth
                    && NotYetConnectedNotes[1].Note.Duration == Duration.eigth
                    && NotYetConnectedNotes[2].Note.Duration == Duration.sixteenth)
                {
                    NotYetConnectedNotes[1].CanvasLeft = (NotYetConnectedNotes[0].CanvasLeft + NotYetConnectedNotes[2].CanvasLeft) / 2;
                    // First 16th to middle 8th
                    shapeString += " M "
                                       + (NotYetConnectedNotes[1].CanvasLeft + addToX + (NotYetConnectedNotes[0].CanvasLeft - NotYetConnectedNotes[1].CanvasLeft) * 0.5).ToString(c) + ","
                                       + (NotYetConnectedNotes[1].PathTop + addToY + (NotYetConnectedNotes[0].PathTop - NotYetConnectedNotes[1].PathTop) * 0.5 + offsetSecondBeam).ToString(c) + " L "
                                       + (NotYetConnectedNotes[0].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[0].PathTop + addToY + offsetSecondBeam).ToString(c) + "";
                    // Middle 8th to second 16th
                    shapeString += " M "
                                       + (NotYetConnectedNotes[1].CanvasLeft + addToX + (NotYetConnectedNotes[2].CanvasLeft - NotYetConnectedNotes[1].CanvasLeft) * 0.6).ToString(c) + ","
                                       + (NotYetConnectedNotes[1].PathTop + addToY + (NotYetConnectedNotes[2].PathTop - NotYetConnectedNotes[1].PathTop) * 0.6 + offsetSecondBeam).ToString(c) + " L "
                                       + (NotYetConnectedNotes[2].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[2].PathTop + addToY + offsetSecondBeam).ToString(c) + "";

                }
                // 16th - 16th rest - 8th
                if (NotYetConnectedNotes.Count == 2
                    && NotYetConnectedNotes[0].Note.Duration == Duration.sixteenth
                    && NotYetConnectedNotes[1].Note.Duration == Duration.eigth)
                    shapeString += " M "
                                       + (NotYetConnectedNotes[1].CanvasLeft + addToX + (NotYetConnectedNotes[0].CanvasLeft - NotYetConnectedNotes[1].CanvasLeft) * 0.5).ToString(c) + ","
                                       + (NotYetConnectedNotes[1].PathTop + addToY + (NotYetConnectedNotes[0].PathTop - NotYetConnectedNotes[1].PathTop) * 0.5 + offsetSecondBeam).ToString(c) + " L "
                                       + (NotYetConnectedNotes[0].CanvasLeft + addToX).ToString(c) + "," + (NotYetConnectedNotes[0].PathTop + addToY + offsetSecondBeam).ToString(c) + "";
            }

            var beam = new Path
            {
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                Data = Geometry.Parse(shapeString),
                StrokeThickness = strokeThickness
            };

            Children.Add(beam);
            NotYetConnectedNotes.Clear();
        }
    }
}