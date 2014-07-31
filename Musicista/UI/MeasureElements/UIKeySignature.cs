
using Model;
using Model.Meta;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
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
            if ((musicalKey.Pitch == Pitch.G && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.E && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.GMajor); width = 60; }
            else if ((musicalKey.Pitch == Pitch.D && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.B && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.DMajor); width = 90; }
            else if ((musicalKey.Pitch == Pitch.A && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.FSharp && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.AMajor); width = 120; }
            else if ((musicalKey.Pitch == Pitch.E && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.CSharp && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.EMajor); width = 150; }
            else if ((musicalKey.Pitch == Pitch.B && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.GSharp && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.BMajor); width = 180; }
            else if ((musicalKey.Pitch == Pitch.FSharp && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.DSharp && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.FSharpMajor); width = 210; }
            else if ((musicalKey.Pitch == Pitch.CSharp && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.ASharp && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.CSharpMajor); width = 260; }
            else if ((musicalKey.Pitch == Pitch.F && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.D && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.FMajor); width = 60; }
            else if ((musicalKey.Pitch == Pitch.BFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.G && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.BFlatMajor); width = 120; }
            else if ((musicalKey.Pitch == Pitch.EFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.C && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.EFlatMajor); width = 180; }
            else if ((musicalKey.Pitch == Pitch.AFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.F && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.AFlatMajor); width = 210; }
            else if ((musicalKey.Pitch == Pitch.DFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.BFlat && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.DFlatMajor); width = 240; }
            else if ((musicalKey.Pitch == Pitch.GFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.EFlat && musicalKey.Gender == Gender.Minor))
            { KeyPath.Data = Geometry.Parse(Engraving.GFlatMajor); width = 270; }
            else if ((musicalKey.Pitch == Pitch.CFlat && musicalKey.Gender == Gender.Major) || (musicalKey.Pitch == Pitch.AFlat && musicalKey.Gender == Gender.Minor))
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
