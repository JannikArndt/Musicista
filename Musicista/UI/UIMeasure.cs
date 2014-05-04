using Model;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UIMeasure
    {
        private int _top;
        private int _left;
        private int _width;
        private int _height = 40;

        public int Top
        {
            get { return _top; }
            set
            {
                this._top = value;
                Canvas.SetTop(MeasureBox, value);
            }
        }
        public int Left
        {
            get { return _left; }
            set
            {
                this._left = value;
                Canvas.SetLeft(MeasureBox, value);
                Barline.X1 = Barline.X2 = value + Width;
            }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                this._width = value;
                MeasureBox.Width = value;
                Barline.X1 = Barline.X2 = Left + value;
            }
        }
        public Rectangle MeasureBox { get; set; }
        public Line Barline { get; set; }
        public readonly Measure Measure = new Measure();

        public UIMeasure(Canvas canvas, int top, int left, int width, Measure measure = null)
        {
            MeasureBox = new Rectangle
            {
                Width = width,
                Height = _height,
                //Fill = Brushes.Yellow,
                Opacity = 0.5
            };

            Canvas.SetTop(MeasureBox, top);
            Canvas.SetLeft(MeasureBox, left);

            Barline = new Line { X1 = left + width, Y1 = top + 10, X2 = left + width, Y2 = top + 35, StrokeThickness = 2, Stroke = Brushes.Black, SnapsToDevicePixels = true };
            Barline.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

            canvas.Children.Add(MeasureBox);
            canvas.Children.Add(Barline);

            Left = left;
            Top = top;
            Width = width;
            Measure = measure;
        }

        public override string ToString()
        {
            return "Measure #" + Measure.MeasureNumber;
        }
    }
}
