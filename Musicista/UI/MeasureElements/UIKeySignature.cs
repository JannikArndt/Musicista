
using Model;
using Model.Meta;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Model.Sections.Attributes;
using Model.Sections.Notes;

namespace Musicista.UI.MeasureElements
{
    public class UIKeySignature : Canvas
    {
        Path KeyPath = new Path
        {
            Fill = Brushes.Black,
            RenderTransform = new ScaleTransform(1.6, 1.6)
        };
        public UIKeySignature(MusicalKey musicalKey, Clef clef, UIMeasure uiMeasure)
        {
            var width = .0;
            if ((musicalKey.Step == Step.G && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.E && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.GMajor); width = 60; }
            else if ((musicalKey.Step == Step.D && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.B && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.DMajor); width = 90; }
            else if ((musicalKey.Step == Step.A && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.FSharp && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.AMajor); width = 120; }
            else if ((musicalKey.Step == Step.E && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.CSharp && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.EMajor); width = 150; }
            else if ((musicalKey.Step == Step.B && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.GSharp && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.BMajor); width = 180; }
            else if ((musicalKey.Step == Step.FSharp && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.DSharp && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.FSharpMajor); width = 210; }
            else if ((musicalKey.Step == Step.CSharp && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.ASharp && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.CSharpMajor); width = 260; }
            else if ((musicalKey.Step == Step.F && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.D && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.FMajor); width = 60; }
            else if ((musicalKey.Step == Step.BFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.G && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.BFlatMajor); width = 120; }
            else if ((musicalKey.Step == Step.EFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.C && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.EFlatMajor); width = 180; }
            else if ((musicalKey.Step == Step.AFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.F && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.AFlatMajor); width = 210; }
            else if ((musicalKey.Step == Step.DFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.BFlat && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.DFlatMajor); width = 240; }
            else if ((musicalKey.Step == Step.GFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.EFlat && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.GFlatMajor); width = 270; }
            else if ((musicalKey.Step == Step.CFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Step == Step.AFlat && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.CFlatMajor); width = 300; }

            switch (clef)
            {
                case Clef.Treble:
                    SetTop(KeyPath, -10);
                    break;
                case Clef.Bass:
                    SetTop(KeyPath, 25);
                    break;
            }
            SetLeft(KeyPath, uiMeasure.Indent);
            Children.Add(KeyPath);
            uiMeasure.Indent += width;
        }
    }
}
