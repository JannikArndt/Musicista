using Model.Sections.Notes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI.MeasureElements
{
    public class UIClef : Canvas
    {
        public Path ClefPath = new Path
        {
            Fill = Brushes.Black,
        };
        public UIClef(Clef clefType, UIMeasure uiMeasure)
        {
            switch (clefType)
            {
                case Clef.Treble:
                    ClefPath.RenderTransform = new ScaleTransform(2.5, 2.5);
                    ClefPath.Data = Geometry.Parse(Engraving.TrebleClef);
                    SetTop(ClefPath, -5);
                    break;
                case Clef.Bass:
                    ClefPath.RenderTransform = new ScaleTransform(.7, .7);
                    ClefPath.Data = Geometry.Parse(Engraving.BassClef);
                    SetTop(ClefPath, 50);
                    break;
            }

            SetLeft(ClefPath, uiMeasure.Indent);

            Children.Add(ClefPath);

            if (uiMeasure.ParentUIMeasureGroup.ParentSystem.MeasureGroups.IndexOf(uiMeasure.ParentUIMeasureGroup) > 0)
            {
                SetLeft(this, -120);
                switch (clefType)
                {
                    case Clef.Treble:
                        ClefPath.RenderTransform = new ScaleTransform(2, 2);
                        SetTop(ClefPath, 25);
                        break;
                    case Clef.Bass:
                        ClefPath.RenderTransform = new ScaleTransform(.56, .56);
                        SetTop(ClefPath, 56);
                        break;
                }
                uiMeasure.PreviousUIMeasure.MarginRight += 120;
                uiMeasure.PreviousUIMeasure.ParentUIMeasureGroup.Redraw();
            }
            else
                uiMeasure.Indent += 120;
        }
    }
}
