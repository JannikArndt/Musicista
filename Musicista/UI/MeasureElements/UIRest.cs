using Model.Sections.Notes;
using Musicista.Properties;
using System.Linq;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI.MeasureElements
{
    public class UIRest : UISymbol
    {
        public UIRest(Rest rest, UIMeasure parentMeasure, bool hasMouseDown = true)
            : base(rest, parentMeasure, hasMouseDown)
        {
            Rest = rest;

            ParentUIMeasure.ConnectNotesAtEndOfRun = false;

            SetTop(Path, 55 + -TopRelativeToMeasure);

            // Multiple Voices
            if (ParentUIMeasure.InnerMeasure.Voices.Count > 1)
                if (Rest.Voice == ParentUIMeasure.InnerMeasure.Voices.Min())
                    SetTop(Path, 55 + -TopRelativeToMeasure - 100);
                else if (Rest.Voice == ParentUIMeasure.InnerMeasure.Voices.Max())
                    SetTop(Path, 55 + -TopRelativeToMeasure + 100);

            SetLeft(Path, 10);
            CanvasLeft = ((ParentUIMeasure.Width - ParentUIMeasure.Indent - parentMeasure.MarginRight) / BeatsPerMeasure * (rest.Beat - 1)) + ParentUIMeasure.Indent;
            if (rest.Duration == Duration.Whole)
                CanvasLeft = ParentUIMeasure.Width / 2;
            SetDuration(rest, ParentUIMeasure);

            Children.Add(Path);
            ParentUIMeasure.Children.Add(this);


            if (ParentUIMeasure.ConnectNotesAtEndOfRun || ParentUIMeasure.NotYetConnectedNotes.Count == 4
                || (ParentUIMeasure.NotYetConnectedNotes.Any() && rest.Next == null)
                || (ParentUIMeasure.NotYetConnectedNotes.Any() && rest.Next != null && (rest.Next.Beat == 3 || rest.Next.Beat == 1))
                || (ParentUIMeasure.NotYetConnectedNotes.Any(item => item.Note.Duration == Duration.Sixteenth) && rest.Next != null && (rest.Next.Beat == 2 || rest.Next.Beat == 4)))
                ParentUIMeasure.ConnectNotes();

            // Handle triplets ( /tuplets)
            if (rest.IsTriplet)
                ParentUIMeasure.Tuplets.Add(this);
            if (ParentUIMeasure.Tuplets.Count > 2 || (ParentUIMeasure.Tuplets.Any() && !rest.IsTriplet))
                ParentUIMeasure.ConnectTuplets();
        }

        public Path Path = new Path
        {
            Fill = Brushes.Black,
            SnapsToDevicePixels = Settings.Default.SnapsToDevicePixels
        };

        public Rest Rest { get; set; }

        public UIRest NextUIRest
        {
            get
            {
                var index = ParentUIMeasure.Rests.IndexOf(this);
                if (ParentUIMeasure.Rests.Count > index + 1)
                    return ParentUIMeasure.Rests[index + 1];
                return null;
            }
        }

        public override string ToString()
        {
            return Rest.ToString();
        }

        private void SetDuration(Rest rest, UIMeasure measure)
        {
            switch (rest.Duration)
            {
                case Duration.Whole:
                    Path.Data = Geometry.Parse(Engraving.RestWhole);
                    break;
                case Duration.HalfDotted:
                    Path.Data = Geometry.Parse(Engraving.RestHalf);
                    DrawDot(measure);
                    break;
                case Duration.WholeTriplet:
                    Path.Data = Geometry.Parse(Engraving.RestWhole);
                    break;
                case Duration.Half:
                    Path.Data = Geometry.Parse(Engraving.RestHalf);
                    break;
                case Duration.QuarterDotted:
                    Path.Data = Geometry.Parse(Engraving.RestQuarter);
                    DrawDot(measure);
                    break;
                case Duration.HalfTriplet:
                    Path.Data = Geometry.Parse(Engraving.RestHalf);
                    break;
                case Duration.Quarter:
                    Path.Data = Geometry.Parse(Engraving.RestQuarter);
                    break;
                case Duration.EigthDotted:
                    Path.Data = Geometry.Parse(Engraving.RestEigth);
                    DrawDot(measure);
                    break;
                case Duration.QuarterTriplet:
                    Path.Data = Geometry.Parse(Engraving.RestQuarter);
                    break;
                case Duration.Eigth:
                    Path.Data = Geometry.Parse(Engraving.RestEigth);
                    break;
                case Duration.SixteenthDotted:
                    Path.Data = Geometry.Parse(Engraving.RestSixteenth);
                    DrawDot(measure);
                    break;
                case Duration.EigthTriplet:
                    Path.Data = Geometry.Parse(Engraving.RestEigth);
                    break;
                case Duration.Sixteenth:
                    Path.Data = Geometry.Parse(Engraving.RestSixteenth);
                    break;
                case Duration.SixteenthTriplet:
                    Path.Data = Geometry.Parse(Engraving.RestSixteenth);
                    break;
            }
        }

        public void DrawDot(UIMeasure measure)
        {
            var newDot = new Ellipse
            {
                Fill = Brushes.Black,
                Width = 18,
                Height = 18
            };

            SetTop(newDot, GetTop(Path) + 32);
            SetLeft(newDot, GetLeft(Path) + 60);
            Children.Add(newDot);
        }

        public bool StemOfGroupShouldGoUp(Note note)
        {
            var duration = note.Duration;
            var ups = 0;
            var downs = 0;
            var currentNote = note;
            var numberOfNotesToInspect = ((note.Duration == Duration.Eigth && (note.Beat == 1 || note.Beat == 3)) || (note.Duration == Duration.Sixteenth)) ? 4 : 2;
            while (currentNote.Duration == duration && currentNote.GetType() == typeof(Note) && numberOfNotesToInspect > 0)
            {
                if (currentNote.StemShouldGoUp())
                    ups++;
                else
                    downs++;
                if (currentNote.Next != null && currentNote.Next.GetType() == typeof(Note))
                    currentNote = (Note)currentNote.Next;
                else
                    break;
                numberOfNotesToInspect--;
            }
            return ups >= downs;
        }
    }
}