using Model;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.UI
{
    public class UIRest : UISymbol
    {
        public UIRest(Rest rest, UIMeasure parentMeasure)
        {
            ParentMeasure = parentMeasure;
            Rest = rest;
            ParentMeasure.Symbols.Add(this);
            Symbol = rest;

            BeatsPerMeasure = ParentMeasure.InnerMeasure.ParentMeasureGroup.TimeSignature.Beats;
            ParentMeasure.ConnectNotesAtEndOfRun = false;

            SetTop(Path, 55 + -TopRelativeToMeasure);
            SetLeft(Path, 10);
            CanvasLeft = ((ParentMeasure.Width - ParentMeasure.Indent) / BeatsPerMeasure * (rest.Beat - 1)) + ParentMeasure.Indent;
            if (rest.Duration == Duration.whole)
                CanvasLeft = ParentMeasure.Width / 2;
            SetDuration(rest, ParentMeasure);

            Children.Add(Path);
            ParentMeasure.Children.Add(this);


            if (ParentMeasure.ConnectNotesAtEndOfRun || ParentMeasure.NotYetConnectedNotes.Count == 4
                || (ParentMeasure.NotYetConnectedNotes.Any() && rest.Next == null)
                || (ParentMeasure.NotYetConnectedNotes.Any() && rest.Next != null && (rest.Next.Beat == 3 || rest.Next.Beat == 1))
                || (ParentMeasure.NotYetConnectedNotes.Any(item => item.Note.Duration == Duration.sixteenth) && rest.Next != null && (rest.Next.Beat == 2 || rest.Next.Beat == 4)))
                ParentMeasure.ConnectNotes();
        }

        public Path Path = new Path
        {
            Fill = Brushes.Black,
            SnapsToDevicePixels = true
        };

        public Rest Rest { get; set; }

        public UIRest NextUIRest
        {
            get
            {
                var index = ParentMeasure.Rests.IndexOf(this);
                if (ParentMeasure.Rests.Count > index + 1)
                    return ParentMeasure.Rests[index + 1];
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
                case Duration.whole:
                    Path.Data = Geometry.Parse(Engraving.RestWhole);
                    break;
                case Duration.halfDotted:
                    Path.Data = Geometry.Parse(Engraving.RestHalf);
                    DrawDot(measure);
                    break;
                case Duration.half:
                    Path.Data = Geometry.Parse(Engraving.RestHalf);
                    break;
                case Duration.quarterDotted:
                    Path.Data = Geometry.Parse(Engraving.RestQuarter);
                    DrawDot(measure);
                    break;
                case Duration.quarter:
                    Path.Data = Geometry.Parse(Engraving.RestQuarter);
                    break;
                case Duration.eigthDotted:
                    Path.Data = Geometry.Parse(Engraving.RestQuarter);
                    DrawDot(measure);
                    break;
                case Duration.eigth:
                    Path.Data = Geometry.Parse(Engraving.RestEigth);
                    break;
                case Duration.sixteenthDotted:
                    Path.Data = Geometry.Parse(Engraving.RestQuarter);
                    DrawDot(measure);
                    break;
                case Duration.sixteenth:
                    Path.Data = Geometry.Parse(Engraving.RestSixteenth);
                    break;
            }
        }

        public void DrawDot(UIMeasure measure)
        {
            double top;
            if (Math.Abs(GetTop(Path) % 31) < 5)
                top = GetTop(Path) + 88;
            else
                top = GetTop(Path) + 103;

            var left = CanvasLeft + 50;

            var newDot = new Ellipse
            {
                Fill = Brushes.Black,
                Width = 18,
                Height = 18
            };

            Canvas.SetTop(newDot, top);
            Canvas.SetLeft(newDot, left);
            measure.Children.Add(newDot);
        }

        public bool StemOfGroupShouldGoUp(Note note)
        {
            var duration = note.Duration;
            var ups = 0;
            var downs = 0;
            var currentNote = note;
            var numberOfNotesToInspect = ((note.Duration == Duration.eigth && (note.Beat == 1 || note.Beat == 3)) || (note.Duration == Duration.sixteenth)) ? 4 : 2;
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