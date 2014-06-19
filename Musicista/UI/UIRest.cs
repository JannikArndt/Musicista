using Model;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Duration = Model.Duration;

namespace Musicista.UI
{
    public class UIRest : UISymbol
    {
        public Rest Rest { get; set; }
        public UIRest(Rest rest, UIMeasure parentMeasure)
        {
            BeatsPerMeasure = parentMeasure.InnerMeasure.ParentMeasureGroup.TimeSignature.Beats;
            parentMeasure.ConnectNotesAtEndOfRun = false;
            Rest = rest;
            ParentMeasure = parentMeasure;
            ParentMeasure.Rests.Add(this);

            Top = 55;
            Left = ((parentMeasure.Width - parentMeasure.Indent) / BeatsPerMeasure * (rest.Beat - 1)) + parentMeasure.Indent;
            if (rest.Duration == Duration.whole)
                Left = parentMeasure.Width / 2;
            SetDuration(rest, parentMeasure);

            Canvas.SetTop(Path, Top);
            Canvas.SetLeft(Path, Left);
            parentMeasure.Children.Add(Path);

            if (parentMeasure.ConnectNotesAtEndOfRun || parentMeasure.NotYetConnectedNotes.Count == 4
                || (parentMeasure.NotYetConnectedNotes.Any() && rest.Next == null)
                || (parentMeasure.NotYetConnectedNotes.Any() && rest.Next != null && (rest.Next.Beat == 3 || rest.Next.Beat == 1))
                || (parentMeasure.NotYetConnectedNotes.Any(item => item.Note.Duration == Duration.sixteenth) && rest.Next != null && (rest.Next.Beat == 2 || rest.Next.Beat == 4)))
                parentMeasure.ConnectNotes();
        }

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
            if (Math.Abs(Top % 30) < 5)
                top = Top + 88;
            else
                top = Top + 103;

            var left = Left + 50;

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
