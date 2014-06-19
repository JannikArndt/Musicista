using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UISymbol
    {
        public UIMeasure ParentMeasure { get; set; }
        public double Top { get { return Canvas.GetTop(Path); } set { Canvas.SetTop(Path, value); } }
        public double Left { get { return Canvas.GetLeft(Path); } set { Canvas.SetLeft(Path, value); } }
        public Path Path = new Path
        {
            Fill = Brushes.Black,
            SnapsToDevicePixels = true
        };

        public int BeatsPerMeasure { get; set; }
        public UISymbol NextUISymbol
        {
            get
            {
                var index = ParentMeasure.Symbols.IndexOf(this);
                if (ParentMeasure.Symbols.Count > index + 1)
                    return ParentMeasure.Symbols[index + 1];
                return null;
            }
        }

        public UISymbol()
        {
            Path.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Unspecified);
            Path.SetValue(RenderOptions.ClearTypeHintProperty, ClearTypeHint.Enabled);
            Path.SetValue(RenderOptions.CachingHintProperty, CachingHint.Cache);
        }
    }
}
