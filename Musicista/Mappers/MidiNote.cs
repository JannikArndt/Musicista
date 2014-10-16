using Midi.Events.ChannelEvents;
using Model.Sections.Notes;

namespace Musicista.Mappers
{
    /// <summary>
    /// Provides an interim model for Musicista notes with a DeltaTime. This is used for Midi to Musicista conversion.
    /// </summary>
    public class MidiNote
    {
        public Note Note { get; set; }
        public int DeltaTime = 0;

        public MidiNote(NoteOnEvent note, int deltaTime, int devision)
        {
            Note = new Note
            {
                Octave = note.NoteNumber / 12 - 1,
                Step = MidiMapper.MapMidiStepsToPitch[note.NoteNumber % 12],
                Beat = (double)(deltaTime + devision) / devision
            };
            DeltaTime = note.DeltaTime;
        }
    }
}