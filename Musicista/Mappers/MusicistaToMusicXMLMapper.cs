using Model;
using Model.Sections;
using Model.Sections.Attributes;
using Model.Sections.Notes;
using MusicXML;
using MusicXML.Enums;
using MusicXML.Note;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Clef = MusicXML.Clef;
using Note = MusicXML.Note.Note;
using Step = Model.Sections.Attributes.Step;

namespace Musicista.Mappers
{
    /// <summary>
    /// Mapper between MusicXML and Musicista (both ways)
    /// </summary>
    public static partial class MusicXMLMapper
    {
        /// <summary>
        /// Maps a Musicista piece to a MusicXML partwise score for export.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public static ScorePartwise MapMusicistaToMusicXML(Piece piece)
        {
            // Initialization and Metadata
            var mxml = new ScorePartwise
            {
                Work =
                {
                    WorkTitle = piece.Meta.Title,
                    Opus = new opus { title = piece.Meta.Opus.OpusString }
                },
                MovementNumber = piece.Movements.First().Number.ToString(CultureInfo.InvariantCulture),
                MovementTitle = piece.Movements.First().Name,
                Identification = new Identification
                {
                    Encoding = new Encoding
                    {
                        Encoder = new Typedtext("Encoder", piece.Meta.Dates.Engraving.Typesetter),
                        EncodingDate = new Typedtext("Date", piece.Meta.Dates.Engraving.DateString),
                        Software = new Typedtext("Software", "Musicista 0.9")
                    },
                    Rights = new[] { new Typedtext("Rights", piece.Meta.Copyright) },
                    Creator = piece.Meta.People.Persons.Select(person => new Typedtext(person.GetType().ToString(), person.FullName)).ToArray()
                },
                PartList = new Partlist()
            };

            // Instrument definitions
            var instrumentList = new List<object>();
            var counter = 0;
            foreach (var instrumentGroup in piece.InstrumentGroups)
            {
                instrumentList.Add(new partgroup { type = startstop.start, number = counter.ToString(CultureInfo.InvariantCulture) });
                instrumentList.AddRange(instrumentGroup.Instruments.Select(instrument => new ScorePart
                {
                    id = instrument.ID.ToString(CultureInfo.InvariantCulture),
                    Partname = instrument.Name,
                    Partabbreviation = instrument.Shortname,
                    Scoreinstrument = new[] { new scoreinstrument { id = instrument.ID.ToString(CultureInfo.InvariantCulture) } }
                }));
                instrumentList.Add(new partgroup { type = startstop.stop, number = counter++.ToString(CultureInfo.InvariantCulture) });
            }
            mxml.PartList.Items = instrumentList.ToArray();

            // Measures
            mxml.Part = new ScorePartwisePart[piece.MeasureGroups.First().Measures.Count];
            var measures = new List<ScorePartwisePartMeasure>();
            for (var part = 0; part < piece.MeasureGroups.First().Measures.Count; part++)
            {
                var showAttributes = false;
                var firstMeasure = true;
                MusicalKey lastKey = null;
                var lastClef = new Model.Sections.Notes.Clef();
                TimeSignature lastTimeSignature = null;

                foreach (var measureGroup in piece.MeasureGroups)
                {
                    // Attributes only if needed
                    var attributes = new attributes();
                    if (!Equals(lastKey, measureGroup.KeySignature))
                    {
                        attributes.key = new[] { new key { Fifths = measureGroup.KeySignature.Step.ToFifths().ToString(CultureInfo.InvariantCulture), Mode = measureGroup.KeySignature.Gender.ToString() } };
                        lastKey = measureGroup.KeySignature;
                        showAttributes = true;
                    }
                    if (!Equals(lastClef, measureGroup.Measures[part].Clef))
                    {
                        attributes.clef = new[] { new Clef { sign = measureGroup.Measures[part].Clef == Model.Sections.Notes.Clef.Treble ? clefsign.G : clefsign.F } };
                        lastClef = measureGroup.Measures[part].Clef;
                        showAttributes = true;
                    }
                    if (!Equals(lastTimeSignature, measureGroup.TimeSignature))
                    {
                        attributes.time = new[] { new time { Beats = measureGroup.TimeSignature.Beats, BeatType = measureGroup.TimeSignature.BeatUnit } };
                        lastTimeSignature = measureGroup.TimeSignature;
                        showAttributes = true;
                    }

                    var measure = new ScorePartwisePartMeasure
                    {
                        number = measureGroup.MeasureNumber.ToString(CultureInfo.InvariantCulture),
                        Attributes = (showAttributes || firstMeasure) ? attributes : null,
                        Items = measureGroup.Measures[part].Symbols.Select(symbol => GetMXMLNoteFromMusicistaSymbol(symbol, measureGroup.Measures[part])).Cast<object>().ToArray()
                    };

                    if (firstMeasure)
                    {
                        measure.Attributes.Divisions = 960;
                        measure.Attributes.staves = measureGroup.Measures[part].Instrument.Staves.Count.ToString(CultureInfo.InvariantCulture);
                        measure.Attributes.transpose = new[] { new transpose { chromatic = measureGroup.Measures[part].Instrument.Transposition } };
                        firstMeasure = false;
                    }
                    measures.Add(measure);
                }
                mxml.Part[part] = new ScorePartwisePart
                {
                    id = (part + 1).ToString(CultureInfo.InvariantCulture),
                    Measure = measures.ToArray()
                };
            }

            return mxml;
        }

        private static double _lastBeat;
        /// <summary>
        /// Converts a Musicista symbol into a MusicXML note
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="measure"></param>
        /// <returns></returns>
        public static Note GetMXMLNoteFromMusicistaSymbol(Symbol symbol, Measure measure)
        {
            var note = new Note
            {
                Cue = null,
                Grace = null,
                Unpitched = null,
                Duration = (int)symbol.Duration,
                instrument = new instrument { id = measure.InstrumentID.ToString(CultureInfo.InvariantCulture) },
                voice = symbol.Voice.ToString(CultureInfo.InvariantCulture),
                //type = new notetype { Value = notetypevalue.whole},
            };

            if (symbol.GetType() == typeof(Model.Sections.Notes.Note))
                note.Pitch = GetPitchFromMusicistaNote((Model.Sections.Notes.Note)symbol);
            else
                note.Rest = new rest();

            // Recognize chords
            if (Math.Abs(symbol.Beat - _lastBeat) < 0.01)
                note.Chord = "true";
            _lastBeat = symbol.Beat;

            return note;
        }

        /// <summary>
        /// Extracts the MusicXML Pitch from a Musicista note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public static Pitch GetPitchFromMusicistaNote(Model.Sections.Notes.Note note)
        {
            var c = CultureInfo.InvariantCulture;
            switch (note.Step)
            {
                case Step.C: return new Pitch { Step = MusicXML.Step.C, Alter = 0, Octave = note.Octave.ToString(c) };
                case Step.D: return new Pitch { Step = MusicXML.Step.D, Alter = 0, Octave = note.Octave.ToString(c) };
                case Step.E: return new Pitch { Step = MusicXML.Step.F, Alter = 0, Octave = note.Octave.ToString(c) };
                case Step.F: return new Pitch { Step = MusicXML.Step.G, Alter = 0, Octave = note.Octave.ToString(c) };
                case Step.G: return new Pitch { Step = MusicXML.Step.A, Alter = 0, Octave = note.Octave.ToString(c) };
                case Step.A: return new Pitch { Step = MusicXML.Step.B, Alter = 0, Octave = note.Octave.ToString(c) };
                case Step.B: return new Pitch { Step = MusicXML.Step.C, Alter = 0, Octave = note.Octave.ToString(c) };

                case Step.CSharp: return new Pitch { Step = MusicXML.Step.C, Alter = 1, Octave = note.Octave.ToString(c) };
                case Step.DSharp: return new Pitch { Step = MusicXML.Step.D, Alter = 1, Octave = note.Octave.ToString(c) };
                case Step.ESharp: return new Pitch { Step = MusicXML.Step.F, Alter = 1, Octave = note.Octave.ToString(c) };
                case Step.FSharp: return new Pitch { Step = MusicXML.Step.G, Alter = 1, Octave = note.Octave.ToString(c) };
                case Step.GSharp: return new Pitch { Step = MusicXML.Step.A, Alter = 1, Octave = note.Octave.ToString(c) };
                case Step.ASharp: return new Pitch { Step = MusicXML.Step.B, Alter = 1, Octave = note.Octave.ToString(c) };
                case Step.BSharp: return new Pitch { Step = MusicXML.Step.C, Alter = 1, Octave = note.Octave.ToString(c) };

                case Step.CFlat: return new Pitch { Step = MusicXML.Step.C, Alter = -1, Octave = note.Octave.ToString(c) };
                case Step.DFlat: return new Pitch { Step = MusicXML.Step.D, Alter = -1, Octave = note.Octave.ToString(c) };
                case Step.EFlat: return new Pitch { Step = MusicXML.Step.F, Alter = -1, Octave = note.Octave.ToString(c) };
                case Step.FFlat: return new Pitch { Step = MusicXML.Step.G, Alter = -1, Octave = note.Octave.ToString(c) };
                case Step.GFlat: return new Pitch { Step = MusicXML.Step.A, Alter = -1, Octave = note.Octave.ToString(c) };
                case Step.AFlat: return new Pitch { Step = MusicXML.Step.B, Alter = -1, Octave = note.Octave.ToString(c) };
                case Step.BFlat: return new Pitch { Step = MusicXML.Step.C, Alter = -1, Octave = note.Octave.ToString(c) };

                default: return new Pitch();
            }
        }
    }
}