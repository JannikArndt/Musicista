using Midi;
using Midi.Events.ChannelEvents;
using Midi.Events.MetaEvents;
using Model;
using Model.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Musicista.Mappers
{
    public static class MidiMapper
    {
        public static Piece MapMidiToPiece()
        {
            const string filePath = @"C:\Users\Jannik\test.mid";
            var file = File.OpenRead(filePath);
            var midiData = FileParser.Parse(file);
            Console.WriteLine(midiData.Header.ToString());

            var piece = Mapper.CreateEmptyPiece();
            piece.Title = filePath;
            var passage = piece.ListOfSections[0].ListOfMovements[0].ListOfSegments[0].ListOfPassages[0];
            passage.ListOfMeasureGroups.Add(new MeasureGroup { MeasureNumber = 1 });
            var currentMeasureGroup = passage.ListOfMeasureGroups[0];
            currentMeasureGroup.Measures.Add(new Measure());

            Console.WriteLine(@"Time Division = " + midiData.Header.TimeDivision);

            var nowPlayingDict = new Dictionary<int, MidiNote>();
            var deltaTimeInThisMeasure = 0;
            var measureNumber = 2;
            var instrumentID = 1;

            foreach (var track in midiData.Tracks)
            {
                var currentInstrument = new Instrument("", ++instrumentID);
                Console.WriteLine(@"Track " + track.ChunkId);
                foreach (var midiEvent in track.Events)
                {
                    // Notes are still hold need to know the new delta times, because delta-times are always relative to the ONE event before them
                    foreach (var note in nowPlayingDict.Keys)
                        nowPlayingDict[note].DeltaTime += midiEvent.DeltaTime;

                    deltaTimeInThisMeasure += midiEvent.DeltaTime;




                    if (midiEvent is NoteOnEvent)
                    {
                        var newNote = new MidiNote(midiEvent as NoteOnEvent, deltaTimeInThisMeasure, midiData.Header.TimeDivision);
                        nowPlayingDict.Add((midiEvent as NoteOnEvent).note_number, newNote);
                        currentMeasureGroup.Measures[0].ListOfSymbols.Add(newNote.Note);
                    }
                    else if (midiEvent is NoteOffEvent)
                    {
                        if (nowPlayingDict.ContainsKey((midiEvent as NoteOffEvent).note_number))
                        {
                            var note = nowPlayingDict[(midiEvent as NoteOffEvent).note_number];
                            note.Note.Duration = ConvertDeltaTimeToDuration(note.DeltaTime, midiData.Header.TimeDivision);
                            nowPlayingDict.Remove((midiEvent as NoteOffEvent).note_number);
                        }

                    }
                    else if (midiEvent is ControllerEvent)
                        Console.WriteLine(@"Controller: " + (midiEvent as ControllerEvent).controller_number + @" => " +
                                          (midiEvent as ControllerEvent).controller_value);
                    else if (midiEvent is EndOfTrackEvent)
                        break;
                    else if (midiEvent is SetTempoEvent)
                        Console.WriteLine(@"Tempo = " + 60000000 / (midiEvent as SetTempoEvent).tempo);
                    else if (midiEvent is CopyrightNoticeEvent)
                        Console.WriteLine(@"Coypright = " + (midiEvent as CopyrightNoticeEvent).notice);
                    else if (midiEvent is MIDIChannelPrefixEvent)
                        Console.WriteLine(@"Channel Prefix = " + (midiEvent as MIDIChannelPrefixEvent).channel);
                    else if (midiEvent is InstrumentNameEvent)
                        currentInstrument.Name = (midiEvent as InstrumentNameEvent).name;
                    else if (midiEvent is SequenceOrTrackNameEvent)
                        currentInstrument.Name = (midiEvent as SequenceOrTrackNameEvent).name;
                    else if (midiEvent is ProgramChangeEvent)
                        Console.WriteLine(@"Program Change = " + (midiEvent as ProgramChangeEvent).program_number);
                    else
                    {
                        Console.WriteLine(@"Event: " + midiEvent.GetType());
                    }


                    if (deltaTimeInThisMeasure >= midiData.Header.TimeDivision * 4)
                    {
                        passage.ListOfMeasureGroups.Add(new MeasureGroup { MeasureNumber = measureNumber });
                        currentMeasureGroup = passage.ListOfMeasureGroups.Last();
                        currentMeasureGroup.Measures.Add(new Measure { Instrument = currentInstrument });
                        deltaTimeInThisMeasure = 0;
                        measureNumber++;
                    }
                }
            }

            return piece;
        }

        private static Duration ConvertDeltaTimeToDuration(int time, int devision)
        {
            // 1. Normalize devision to 960
            if (devision != 960)
                time = time * (960 / devision);

            // 2. Map time to intervals
            var cases = new Dictionary<Func<int, bool>, Duration>
                { 
                    { x => x < 150,                Duration.sixtyforth},          // = 120
                    { x => x >= 150 && x < 210,    Duration.sixtyforthDotted},    // = 180
                    { x => x >= 210 && x < 280,    Duration.thirtysecond},        // = 240
                    { x => x >= 280 && x < 400,    Duration.thirtysecondDotted},  // = 320
                    { x => x >= 400 && x < 600,    Duration.eigth},               // = 480
                    { x => x >= 600 && x < 840,    Duration.eigthDotted},         // = 720
                    { x => x >= 840 && x < 1200,   Duration.quarter},             // = 960
                    { x => x >= 1200 && x < 1680,  Duration.quarterDotted},       // = 1440
                    { x => x >= 1680 && x < 2400,  Duration.half},                // = 1920
                    { x => x >= 2400 && x < 3360,  Duration.halfDotted},          // = 2880
                    { x => x >= 3360 && x < 4800,  Duration.whole},               // = 3840
                    { x => x >= 4800 && x < 6720,  Duration.wholeDotted},         // = 5760
                    { x => x >= 6720 && x < 8640,  Duration.doublewhole},         // = 7680
                    { x => x >= 8640,              Duration.doublewholeDotted}    // = 9600
                };

            // 3. Return corresponding Duration
            return cases.First(kvp => kvp.Key(time)).Value;
        }

        public static Note GetNoteFromMidi(byte noteNumber)
        {
            var steps = new Dictionary<int, Pitch>
                { 
                    { 0, Pitch.C },
                    { 1, Pitch.CSharp },
                    { 2, Pitch.D },
                    { 3, Pitch.DSharp },
                    { 4, Pitch.E },
                    { 5, Pitch.F },
                    { 6, Pitch.FSharp },
                    { 7, Pitch.G },
                    { 8, Pitch.GSharp },
                    { 9, Pitch.A },
                    { 10, Pitch.ASharp },
                    { 11, Pitch.B }
                };

            return new Note
            {
                Octave = noteNumber / 12 - 1,
                Step = steps[noteNumber % 12],
                Beat = 1
            };
        }
    }

    public class MidiNote
    {
        public Note Note { get; set; }
        public int DeltaTime = 0;

        public MidiNote(NoteOnEvent note, int deltaTime, int devision)
        {
            Note = MidiMapper.GetNoteFromMidi(note.note_number);
            Note.Beat = (double)(deltaTime + devision) / devision;
            DeltaTime = note.DeltaTime;
        }
    }
}
