using Model.Meta;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI.MeasureElements
{
    public class UITimeSignature : Canvas
    {
        public Path Sign = new Path
        {
            Fill = Brushes.Black,
            RenderTransform = new ScaleTransform(2.2, 2.2)
        };

        public TextBlock Meter1 = new TextBlock
        {
            FontSize = 82,
            TextAlignment = TextAlignment.Center,
            FontWeight = FontWeights.Bold,
            Width = 100
        };
        public TextBlock Meter2 = new TextBlock
        {
            FontSize = 82,
            TextAlignment = TextAlignment.Center,
            FontWeight = FontWeights.Bold,
            Width = 100
        };

        public UITimeSignature(TimeSignature timeSignature, UIMeasure uiMeasure)
        {
            if (timeSignature.IsCommon || timeSignature.IsCutCommon)
            {
                Sign.Data = timeSignature.IsCommon ? Geometry.Parse(Engraving.CommonTime) : Geometry.Parse(Engraving.CutTime);
                SetTop(Sign, 50);
                SetLeft(Sign, uiMeasure.Indent);
                Children.Add(Sign);
            }
            else
            {
                Meter1.Text = timeSignature.Beats.ToString(CultureInfo.InvariantCulture);
                Meter2.Text = timeSignature.BeatUnit.ToString(CultureInfo.InvariantCulture);
                SetTop(Meter1, 18);
                SetLeft(Meter1, uiMeasure.Indent - 10);
                SetTop(Meter2, 80);
                SetLeft(Meter2, uiMeasure.Indent - 10);
                Children.Add(Meter1);
                Children.Add(Meter2);
            }

            uiMeasure.Indent += 110;
        }
    }
}
