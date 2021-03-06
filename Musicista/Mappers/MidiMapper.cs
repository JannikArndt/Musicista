﻿using Midi;
using Midi.Events.ChannelEvents;
using Midi.Events.MetaEvents;
using Model;
using Model.Instruments;
using Model.Sections;
using Model.Sections.Attributes;
using Model.Sections.Notes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musicista.Mappers
{
    /// <summary>
    /// Static class to convert a MidiData object (see package Midi) into a Musicista piece
    /// </summary>
    public static class MidiMapper
    {
        /// <summary>
        /// Maps the MidiData object to a Musicista piece
        /// </summary>
        /// <param name="midi"></param>
        /// <returns></returns>
        public static Piece MapMidiToPiece(MidiData midi)
        {
            var piece = new Piece(initialize: true);
            //piece.Title = filePath;
            var passage = piece.Sections[0].Movements[0].Segments[0].Passages[0];

            var nowPlayingDict = new Dictionary<int, MidiNote>();
            var deltaTimeInThisMeasure = 100000; // force creating a new measure
            var measureNumber = 1;
            var instrumentID = 1;
            var currentPartNumber = 0;
            var currentMeasure = new Measure();

            foreach (var track in midi.Tracks)
            {
                var currentInstrument = new Instrument("", ++instrumentID);
                piece.Instruments.Add(currentInstrument);
                foreach (var midiEvent in track.Events)
                {
                    // Notes that are still hold need to know the new delta times, because delta-times are always relative to the ONE event before them
                    foreach (var note in nowPlayingDict.Keys)
                        nowPlayingDict[note].DeltaTime += midiEvent.DeltaTime;

                    // Add up delta times to know when a measure is full
                    deltaTimeInThisMeasure += midiEvent.DeltaTime;

                    if (deltaTimeInThisMeasure >= midi.Header.TimeDivision * 4) // TODO assumes 4/4 measure
                    {
                        // first run or if a new track has more measures than all previous had
                        if (currentPartNumber == 0 || passage.MeasureGroups.Count < measureNumber)
                            passage.MeasureGroups.Add(new MeasureGroup { MeasureNumber = measureNumber, ParentPassage = passage });
                        // create a new measure and add it to the measureGroup
                        currentMeasure = new Measure { Instrument = currentInstrument };
                        passage.MeasureGroups[measureNumber - 1].Measures.Add(currentMeasure);
                        // adjust counting variables
                        deltaTimeInThisMeasure = 0;
                        measureNumber++;
                    }

                    // Handle actual events
                    if (midiEvent is NoteOnEvent)
                    {
                        var newNote = new MidiNote(midiEvent as NoteOnEvent, deltaTimeInThisMeasure, midi.Header.TimeDivision);
                        nowPlayingDict.Add((midiEvent as NoteOnEvent).NoteNumber, newNote);
                        currentMeasure.AddSymbol(newNote.Note);
                    }
                    else if (midiEvent is NoteOffEvent && nowPlayingDict.ContainsKey((midiEvent as NoteOffEvent).NoteNumber))
                    {
                        var note = nowPlayingDict[(midiEvent as NoteOffEvent).NoteNumber];
                        note.Note.Duration = ConvertDeltaTimeToDuration(note.DeltaTime, midi.Header.TimeDivision);
                        nowPlayingDict.Remove((midiEvent as NoteOffEvent).NoteNumber);
                    }
                    else if (midiEvent is EndOfTrackEvent)
                        break;
                    else if (midiEvent is InstrumentNameEvent)
                        currentInstrument.Name = (midiEvent as InstrumentNameEvent).name;
                    else if (midiEvent is SequenceOrTrackNameEvent)
                        currentInstrument.Name = (midiEvent as SequenceOrTrackNameEvent).name;
                    //else if (midiEvent is ControllerEvent)
                    //    Console.WriteLine(@"Controller: " + (midiEvent as ControllerEvent).controller_number + @" => " + (midiEvent as ControllerEvent).controller_value);
                    //else if (midiEvent is SetTempoEvent)
                    //    Console.WriteLine(@"Tempo = " + 60000000 / (midiEvent as SetTempoEvent).tempo);
                    //else if (midiEvent is CopyrightNoticeEvent)
                    //    Console.WriteLine(@"Coypright = " + (midiEvent as CopyrightNoticeEvent).notice);
                    //else if (midiEvent is MIDIChannelPrefixEvent)
                    //    Console.WriteLine(@"Channel Prefix = " + (midiEvent as MIDIChannelPrefixEvent).channel);

                    //else if (midiEvent is ProgramChangeEvent)
                    //    Console.WriteLine(@"Program Change = " + (midiEvent as ProgramChangeEvent).program_number);
                    //else
                    //    Console.WriteLine(@"Event: " + midiEvent.GetType());
                }
                currentPartNumber++;
                measureNumber = 1;
            }
            return piece;
        }

        /// <summary>
        /// Converts a given delta time into a Duration object, according to the given division
        /// </summary>
        /// <param name="time"></param>
        /// <param name="division"></param>
        /// <returns></returns>
        private static Duration ConvertDeltaTimeToDuration(int time, int division)
        {
            // 1. Normalize division to 960
            if (division != 960)
                time = time * (960 / division);

            // 2. Return corresponding Duration
            return MapDeltaTimeToDuration.First(kvp => kvp.Key(time)).Value;
        }

        /// <summary>
        /// Maps midi steps (0 to 11) to Step objects (C, CSharp, ...)
        /// </summary>
        public static Dictionary<int, Step> MapMidiStepsToPitch = new Dictionary<int, Step>
                { 
                    { 0, Step.C },
                    { 1, Step.CSharp },
                    { 2, Step.D },
                    { 3, Step.DSharp },
                    { 4, Step.E },
                    { 5, Step.F },
                    { 6, Step.FSharp },
                    { 7, Step.G },
                    { 8, Step.GSharp },
                    { 9, Step.A },
                    { 10, Step.ASharp },
                    { 11, Step.B }
                };

        /// <summary>
        /// Maps delta times to Duration objects, with a tolerance.
        /// </summary>
        public static Dictionary<Func<int, bool>, Duration> MapDeltaTimeToDuration = new Dictionary<Func<int, bool>, Duration>
                { 
                    { x => x < 150,                Duration.Sixtyforth},          // = 120
                    { x => x >= 150 && x < 210,    Duration.SixtyforthDotted},    // = 180
                    { x => x >= 210 && x < 280,    Duration.Thirtysecond},        // = 240
                    { x => x >= 280 && x < 400,    Duration.ThirtysecondDotted},  // = 320 // falsch, 360
                    { x => x >= 400 && x < 600,    Duration.Eigth},               // = 480
                    { x => x >= 600 && x < 840,    Duration.EigthDotted},         // = 720
                    { x => x >= 840 && x < 1200,   Duration.Quarter},             // = 960
                    { x => x >= 1200 && x < 1680,  Duration.QuarterDotted},       // = 1440
                    { x => x >= 1680 && x < 2400,  Duration.Half},                // = 1920
                    { x => x >= 2400 && x < 3360,  Duration.HalfDotted},          // = 2880
                    { x => x >= 3360 && x < 4800,  Duration.Whole},               // = 3840
                    { x => x >= 4800 && x < 6720,  Duration.WholeDotted},         // = 5760
                    { x => x >= 6720 && x < 8640,  Duration.Doublewhole},         // = 7680
                    { x => x >= 8640,              Duration.DoublewholeDotted}    // = 9600
                };
    }
}
