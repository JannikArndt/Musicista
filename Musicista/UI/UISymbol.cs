using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UISymbol
    {
        public UIMeasure ParentMeasure { get; set; }
        public double Top { get; set; }
        public double Left { get; set; }
        public Path Path { get; set; }
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
    }
}
