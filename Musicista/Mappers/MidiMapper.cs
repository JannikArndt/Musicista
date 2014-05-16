using Midi;
using Midi.Events.ChannelEvents;
using Model;
using Model.Meta;
using System;
using System.IO;

namespace Musicista.Mappers
{
    public static class MidiMapper
    {
        public static Piece MapMidiToPiece()
        {
            const string filePath = @"C:\Users\Jannik\simple0.mid";
            var file = File.OpenRead(filePath);
            MidiData midiData = FileParser.Parse(file);
            Console.WriteLine(midiData.Header.ToString());

            foreach (var track in midiData.Tracks)
            {
                Console.WriteLine(@"Track " + track.ChunkId);
                foreach (var midiEvent in track.Events)
                {
                    if (midiEvent is NoteOnEvent)
                        Console.WriteLine(@"Note on: " + (midiEvent as NoteOnEvent).note_number);
                    if (midiEvent is NoteOffEvent)
                        Console.WriteLine(@"Note off: " + (midiEvent as NoteOffEvent).note_number);
                    if (midiEvent is ControllerEvent)
                        Console.WriteLine(@"Controller: " + (midiEvent as ControllerEvent).controller_number + @" => " + (midiEvent as ControllerEvent).controller_value);
                }
            }

            return new Piece();
        }

        public static Note GetNoteFromMidi(byte noteNumber)
        {
            var octave = noteNumber / 12;
            var step = (Pitch)(noteNumber % 12);
            return new Note { Octave = octave, Step = step };
        }
    }
}
