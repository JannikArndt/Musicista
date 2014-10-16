using Model;
using Model.Extensions;
using Model.Instruments;
using Model.Meta.People;
using Model.Sections;
using Model.Sections.Attributes;
using Model.Sections.Notes;
using Model.Sections.Notes.Articulation;
using MuseScoreAPI.RESTObjects;
using MusicXML;
using MusicXML.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using Clef = Model.Sections.Notes.Clef;
using Duration = Model.Sections.Notes.Duration;
using Fermata = Model.Sections.Notes.Articulation.Fermata;
using Lyric = Model.Sections.Notes.Lyric;
using Note = MusicXML.Note.Note;
using Step = Model.Sections.Attributes.Step;

namespace Musicista.Mappers
{
    public static partial class MusicXMLMapper
    {
        #region MusicXML to Musicista
        /// <summary>
        /// Maps a MusicXML partwise piece to a musicista piece, first all meta data and instrument definitions, then it calls MapPartwiseMeasuresToPiece()
        /// </summary>
        /// <param name="mxml">A MusicXML piece</param>
        /// <param name="filename">If no title is defined, the filename will be made title</param>
        /// <param name="scoreInfo">An optional MuseScore-API scoreInfo object</param>
        /// <returns></returns>
        public static Piece MapMusicXMLToMusicista(ScorePartwise mxml, String filename, Score scoreInfo = null)
        {
            var piece = new Piece();

            // Map work information
            if (!string.IsNullOrEmpty(mxml.Work.WorkTitle))
                piece.Meta.Title = mxml.Work.WorkTitle;
            else if (scoreInfo != null)
                piece.Meta.Title = scoreInfo.Title;
            else
                piece.Meta.Title = Path.GetFileNameWithoutExtension(filename);

            if (!string.IsNullOrEmpty(mxml.Work.WorkNumber))
                piece.Meta.Notes += "Work Number: " + mxml.Work.WorkNumber;

            // Map Identification information
            if (mxml.Identification != null && mxml.Identification.Encoding != null)
            {
                if (mxml.Identification.Encoding.EncodingDate != null)
                    piece.Meta.Dates.Engraving.Date = DateTime.Parse(mxml.Identification.Encoding.EncodingDate.Value);
                if (mxml.Identification.Encoding.Encoder != null)
                    piece.Meta.Dates.Engraving.Typesetter = mxml.Identification.Encoding.Encoder.Value;
                if (mxml.Identification.Encoding.Software != null)
                    piece.Meta.Software = mxml.Identification.Encoding.Software.Value;
                if (mxml.Identification.Rights != null)
                    piece.Meta.Copyright = String.Join(", ", mxml.Identification.Rights.Select(item => item.Value));
            }
            // Map composers and other people
            if (mxml.Identification != null && mxml.Identification.Creator != null)
                foreach (var creator in mxml.Identification.Creator)
                    switch (creator.Type)
                    {
                        case "composer":
                            piece.Meta.People.Persons.Add(new Composer { FullName = creator.Value });
                            break;
                        case "lyricist":
                            piece.Meta.People.Persons.Add(new Lyricist { FullName = creator.Value });
                            break;
                        case "arranger":
                            piece.Meta.People.Persons.Add(new Arranger { FullName = creator.Value });
                            break;
                        default:
                            piece.Meta.People.Persons.Add(new Person { FullName = creator.Value });
                            break;
                    }

            // Map the instruments
            InstrumentGroup currentInstrumentGroup = null;
            var staffCount = 1;
            if (mxml.PartList.Items != null)
                foreach (var item in mxml.PartList.Items)
                {
                    if (item.GetType() == typeof(partgroup) && ((partgroup)item).type == startstop.start)
                    {
                        currentInstrumentGroup = new InstrumentGroup
                        {
                            BraceType = EnumExtensions.ParseBrace(((partgroup)item).groupsymbol.Value.ToString())
                        };
                        piece.InstrumentGroups.Add(currentInstrumentGroup);
                    }

                    if (item.GetType() == typeof(partgroup) && ((partgroup)item).type == startstop.stop)
                        currentInstrumentGroup = null;

                    if (item.GetType() == typeof(ScorePart))
                    {
                        var instrument = (ScorePart)item;
                        if (currentInstrumentGroup == null)
                        {
                            currentInstrumentGroup = new InstrumentGroup();
                            piece.InstrumentGroups.Add(currentInstrumentGroup);
                        }
                        var newInstrument = new Instrument
                        {
                            Name = instrument.Partname,
                            Shortname = instrument.Partabbreviation,
                            ID = int.Parse(Regex.Match(instrument.id, @"\d+").Value),
                        };
                        var firstMeasure = mxml.Part.First(part => part.id == instrument.id).Measure.First();
                        if (firstMeasure != null)
                        {
                            var transpose = firstMeasure.Attributes.transpose;
                            if (transpose != null) newInstrument.Transposition = (int)transpose.First().chromatic;
                        }

                        var staveString = mxml.Part.FirstOrDefault(part => part.id == instrument.id).Measure.First().Attributes.staves;
                        if (!string.IsNullOrEmpty(staveString))
                        {
                            var staves = int.Parse(staveString);
                            for (var staffNumber = 0; staffNumber < staves; staffNumber++)
                            {
                                newInstrument.Staves.Add(new Staff { ID = staffCount });
                                staffCount++;
                            }

                        }
                        else
                            newInstrument.Staves.Add(new Staff { ID = staffCount });


                        currentInstrumentGroup.Instruments.Add(newInstrument);
                    }
                }
            piece.InstrumentGroups.RemoveAll(item => item.Instruments.Count == 0);

            // Map movement information
            if (mxml.MovementNumber != null)
                piece.Movements.First().Number = int.Parse(mxml.MovementNumber);
            if (mxml.MovementTitle != null)
                piece.Movements.First().Name = mxml.MovementTitle;

            // For downloads from MuseScore.com
            if (scoreInfo != null)
            {
                piece.Meta.Weblink = scoreInfo.Permalink;
                piece.Meta.People.Persons.Add(new Person { FullName = scoreInfo.User.Username, Role = "Uploader", Misc = "User ID = " + scoreInfo.User.Uid });
                piece.Meta.Copyright = scoreInfo.License;
                piece.Meta.Notes += scoreInfo.Description;
                piece.Meta.Subtitle = scoreInfo.Metadata.Subtitle;
                if (!piece.Meta.People.Persons.OfType<Composer>().Any() && !string.IsNullOrEmpty(scoreInfo.Metadata.Composer))
                    piece.Meta.People.Persons.Add(new Composer { FullName = scoreInfo.Metadata.Composer });
                if (!piece.Meta.People.Persons.OfType<Lyricist>().Any() && !string.IsNullOrEmpty(scoreInfo.Metadata.Poet))
                    piece.Meta.People.Persons.Add(new Lyricist { FullName = scoreInfo.Metadata.Poet });
            }

            // Map the music
            MapPartwiseMeasuresToPiece(mxml, piece);

            return piece;
        }
        /// <summary>
        /// Maps a partwise-MusicXML-Object to a Musicista Piece. The structure is 
        /// <score-partwise><part id="P1"><measure number="1"></measure><measure number="2"></measure>...</part><part id="P2">...</part></score-partwise>
        /// 
        /// Dear maintainer:
        /// Once you are done trying to 'optimize' this routine, 
        /// and have realized what a terrible mistake that was, 
        /// please increment the following counter as a warning to the next guy:
        /// 
        /// total_hours_wasted_here = 42
        /// </summary>
        /// <param name="mxml">A ScorePartwise-object</param>
        /// <param name="piece">The Piece-object the measures will be added to</param>
        /// <returns>The given Piece with the measures in it.</returns>
        public static Piece MapPartwiseMeasuresToPiece(ScorePartwise mxml, Piece piece)
        {
            if (piece.Sections.Count == 0)
                piece.Sections.Add(new Section
                {
                    Movements = new List<Movement> { new Movement { Segments = new List<Segment>
                {
                    new Segment { Passages = new List<Passage> { new Passage { MeasureGroups = new List<MeasureGroup>() } } }
                } } }
                });

            var lastClef = new List<List<Clef>>();
            for (var i = 0; i < mxml.Part.Length; i++)
            {
                lastClef.Add(new List<Clef>());
                for (var j = 0; j < piece.Instruments[i].Staves.Count; j++)
                    lastClef[i].Add(Clef.Treble);
            }

            var lastClefAdditionalStaves = new List<Clef>();
            for (var i = 0; i < mxml.Part.Length; i++)
                lastClefAdditionalStaves.Add(Clef.Treble);

            var lastKey = new MusicalKey(Step.C, Gender.Major);
            var lastTime = new TimeSignature(4, 4);
            var durationDivision = 960; // = one quarter

            // take the first part, go through all measures, for each measure look up the other parts
            for (var measureNumber = 0; measureNumber < mxml.Part[0].Measure.Length; measureNumber++)
            {
                // 1. Create a parent MeasureGroup
                var measure = mxml.Part[0].Measure[measureNumber];
                var measureGroup = new MeasureGroup
                {
                    MeasureNumber = int.Parse(Regex.Match(measure.number, @"\d+").Value),
                    TimeSignature = null,
                    Measures = new List<Measure>(),
                    ParentPassage = piece.Sections[0].Movements[0].Segments[0].Passages[0]
                };

                // Pickup / upbeat measure
                if (measureGroup.MeasureNumber == 0)
                    measureGroup.IsPickupMeasure = true;

                // Division (what int corresponds to a quarter?)
                if (measure.Attributes != null && measure.Attributes.Divisions != 0.0M)
                    durationDivision = (int)measure.Attributes.Divisions;

                // KeySignature
                if (measure.Attributes != null && measure.Attributes.key != null && measure.Attributes.key.First() != null)
                    lastKey = GetKeyFromMXMLKey(measure.Attributes.key.First());
                measureGroup.KeySignature = lastKey;

                // TimeSignature
                if (measure.Attributes != null && measure.Attributes.time != null && measure.Attributes.time.First() != null)
                    if (measure.Attributes.time[0].symbolSpecified)
                        switch (measure.Attributes.time[0].symbol)
                        {
                            case timesymbol.common:
                                lastTime = new TimeSignature(isCommon: true);
                                break;
                            case timesymbol.cut:
                                lastTime = new TimeSignature(isCutCommon: true);
                                break;
                        }
                    else
                        lastTime = new TimeSignature(measure.Attributes.time[0].Beats, measure.Attributes.time[0].BeatType);
                measureGroup.TimeSignature = lastTime;


                // 2. Go through all <Part>s, 
                for (var partNumber = 0; partNumber < mxml.Part.Length; partNumber++)
                {
                    var currentMeasure = mxml.Part[partNumber].Measure[measureNumber];
                    var items = mxml.Part[partNumber].Measure[measureNumber].Items;

                    // get correct clef
                    if (currentMeasure.Attributes != null)
                        for (var staff = 0; staff < piece.Instruments[partNumber].Staves.Count; staff++)
                            lastClef[partNumber][staff] = GetClefFromAttributes(currentMeasure.Attributes, staff) ?? lastClef[partNumber][staff];


                    // 3. create a new measure for each part
                    var measures = new List<Measure>();
                    for (var staff = 0; staff < piece.Instruments[partNumber].Staves.Count; staff++)
                    {
                        measures.Add(new Measure
                        {
                            Instrument = piece.Instruments[partNumber],
                            Staff = piece.Instruments[partNumber].Staves[staff],
                            ParentMeasureGroup = measureGroup,
                            Clef = lastClef[partNumber][staff]
                        });
                    }

                    // 4a. Split voices
                    var voices = items.Aggregate(new List<List<Object>> { new List<Object>() },
                                   (list, value) =>
                                   {
                                       if (value.GetType() == typeof(MusicXML.Note.backup)) list.Add(new List<Object>());
                                       else
                                           list.Last().Add(value);
                                       return list;
                                   });

                    // 4b. and add the Notes and Rests of each Measure
                    for (var voice = 0; voice < voices.Count; voice++)
                    {
                        double beat = 960;
                        double advanceBeat = 0;
                        Articulation tempArticulation = null;
                        Wedge tempWedge = null;
                        foreach (var mxmlObject in voices[voice])
                        {
                            // The mxmlObject can be a note, direction, barline, ...
                            if (mxmlObject.GetType() == typeof(Note))
                            {
                                var mxmlNote = (Note)mxmlObject;
                                if (!mxmlNote.IsChord) // advance beat-counter only if <chord>-Tag is not present
                                    beat += advanceBeat;


                                // Tied notes
                                var addDuration = 0;
                                if (mxmlNote.IsTied && mxmlNote.Tie.Type == startstop.start && mxml.Part[partNumber].Measure.Count() > measureNumber + 1)
                                // make tied notes (starting the tie) longer
                                {
                                    var nextMeasure = mxml.Part[partNumber].Measure[measureNumber + 1];
                                    var tiedNote =
                                        nextMeasure.Items.OfType<Note>()
                                            .FirstOrDefault(item => Equals(item.Pitch, mxmlNote.Pitch) && item.IsTied && item.Tie.Type == startstop.stop);
                                    if (tiedNote != null)
                                        addDuration = int.Parse(tiedNote.Duration.ToString(CultureInfo.InvariantCulture));
                                }
                                if (mxmlNote.IsTied && mxmlNote.Tie.Type == startstop.stop) // and skip notes ending a tie
                                {
                                    advanceBeat = int.Parse(mxmlNote.Duration.ToString(CultureInfo.InvariantCulture));
                                    if (durationDivision != 960)
                                        advanceBeat = advanceBeat / durationDivision * 960;
                                    continue;
                                }

                                var newNote = CreateNoteFromMXMLNote(mxmlNote, beat / 960, durationDivision, addDuration, tempArticulation);
                                if (newNote.Voice == 0)
                                    newNote.Voice = voice + 1;

                                advanceBeat = (int)newNote.Duration; // IF the next note advances the beat counter, it should be by this amount

                                if (mxmlNote.staff == null || mxmlNote.staff == "1")
                                    measures[0].AddSymbol(newNote);
                                else if (measures.Count <= int.Parse(mxmlNote.staff))
                                    measures[int.Parse(mxmlNote.staff) - 1].AddSymbol(newNote);

                                tempArticulation = null;
                            }
                            else if (mxmlObject.GetType() == typeof(Direction))
                            {
                                foreach (var directionType in ((Direction)mxmlObject).DirectionType)
                                {
                                    if (tempArticulation == null)
                                        tempArticulation = new Articulation();

                                    if (directionType.Dynamics != null)
                                        tempArticulation.Dynamics =
                                            (Dynamics)Enum.Parse(typeof(Dynamics), directionType.Dynamics.ItemsElementName.FirstOrDefault().ToString());

                                    if (directionType.Rehearsal != null && directionType.Rehearsal.Value != null)
                                        measureGroup.RehearsalMark = directionType.Rehearsal.Value;

                                    // Crescendo and Decrescendo (diminuendo). Attention: This looses wedges that last for more than one measure
                                    if (directionType.Wedge != null && directionType.Wedge.type == wedgetype.crescendo)
                                        tempWedge = new Wedge(beat / 960, 0, true);

                                    if (directionType.Wedge != null && directionType.Wedge.type == wedgetype.diminuendo)
                                        tempWedge = new Wedge(beat / 960, 0, false);

                                    if (directionType.Wedge != null && tempWedge != null && directionType.Wedge.type == wedgetype.stop)
                                    {
                                        tempWedge.EndBeat = beat / 960;
                                        measures[0].Wedge = tempWedge;
                                    }

                                    if (directionType.Words != null)
                                    {
                                        var newTempo = new Tempo { Beat = beat / 960 };
                                        var mute = new Mute();

                                        if (newTempo.Parse(directionType.Words.Value))
                                            measureGroup.Tempi.Add(newTempo);
                                        else if (mute.Parse(directionType.Words.Value))
                                            tempArticulation.Mute = mute;
                                        else if (EnumExtensions.ParseRepetition(directionType.Words.Value) != Repetition.None)
                                            measureGroup.Repetition = EnumExtensions.ParseRepetition(directionType.Words.Value);
                                        else
                                            ParseArticulation(tempArticulation, directionType.Words.Value);
                                    }

                                    if (directionType.Segno != null)
                                        measureGroup.Repetition = Repetition.SegnoSign;

                                    if (directionType.Coda != null)
                                        measureGroup.Repetition = Repetition.CodaSign;

                                    if (directionType.OtherDirection != null && directionType.OtherDirection.Value == "Trill")
                                        tempArticulation.Trill = true;

                                }
                            }
                            else if (mxmlObject.GetType() == typeof(barline))
                            {
                                var barline = ((barline)mxmlObject);
                                measureGroup.Barlines.Add(new Barline(barline.location.ToString(),
                                    barline.barstyle != null ? barline.barstyle.Value.ToString() : "Single",
                                    barline.repeat != null ? barline.repeat.direction.ToString() : "none"));

                            }
                        }
                    }
                    measureGroup.Measures.AddRange(measures);
                }
                piece.Sections[0].Movements[0].Segments[0].Passages[0].MeasureGroups.Add(measureGroup);
            }

            // Correct the first measure if it is a pickup measure
            if (piece.MeasureGroups.First() != null && piece.MeasureGroups.First().IsPickupMeasure)
                foreach (var measure in piece.MeasureGroups.First().Measures)
                    CorrectPickupMeasure(measure);
            return piece;
        }

        /// <summary>
        /// Turns a string into an articulation property and adds that to the given Articulation object
        /// </summary>
        /// <param name="tempArticulation"></param>
        /// <param name="words"></param>
        private static void ParseArticulation(Articulation tempArticulation, string words)
        {
            switch (words.RemoveWhitespace().ToLower().Replace(".", String.Empty))
            {
                case "pizz":
                    tempArticulation.Bowing = Bowing.Pizzicato; return;
                case "arco":
                    tempArticulation.Bowing = Bowing.Arco; return;
                case "marcato":
                    tempArticulation.Accent = Accent.Marcato; return;
                case "dolce":
                    tempArticulation.Dolce = true; return;
                case "espress":
                    tempArticulation.Espressivo = true; return;
                case "leggiero":
                    tempArticulation.Other = "leggiero"; return;
                case "cresc":
                    tempArticulation.Other = "cresc."; return;
                case "pococresc":
                    tempArticulation.Other = "poco cresc."; return;
                case "erallent":
                    tempArticulation.Other = "e rallent."; return;
                case "dim":
                    tempArticulation.Other = "dim."; return;
                case "dimin":
                    tempArticulation.Other = "dimin."; return;
                default:
                    tempArticulation.Other = words;
                    Console.WriteLine(@"Could not parse articulation " + words);
                    if (MainWindow.Tracker != null)
                        MainWindow.Tracker.Track("Articulation Parsing Error", new Dictionary<string, object> { { "Username", Properties.Settings.Default.Username }, { "Words", words } });
                    break;
            }
        }

        /// <summary>
        /// Moves all notes to the right of the measure
        /// </summary>
        /// <param name="measure"></param>
        private static void CorrectPickupMeasure(Measure measure)
        {
            var difference = measure.ParentMeasureGroup.HoldsDuration - measure.Symbols.Sum(item => (int)item.Duration);
            if (difference > 0)
                foreach (var symbol in measure.Symbols)
                    symbol.Beat += difference / (double)Duration.Quarter;
        }

        /// <summary>
        /// Parses the MusicXML attributes and extracts the clef
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private static Clef? GetClefFromAttributes(attributes attributes, int number = 0)
        {
            if (attributes == null || attributes.clef == null || attributes.clef.All(item => item.number != "" + number))
                return null;

            var clef = attributes.clef.First((item => item.number == "" + number));

            if (clef.sign == clefsign.G && clef.line == "2")
                return Clef.Treble;
            if (clef.sign == clefsign.C && clef.line == "3")
                return Clef.Alto;
            if (clef.sign == clefsign.C && clef.line == "4")
                return Clef.Tenor;
            if (clef.sign == clefsign.F && clef.line == "4")
                return Clef.Bass;
            return null;
        }

        /// <summary>
        /// Creates a Musicista Note from a MusicXML Note
        /// </summary>
        /// <param name="mxmlNote"></param>
        /// <param name="beat"></param>
        /// <param name="durationDivision"></param>
        /// <param name="addToDuration"></param>
        /// <param name="articulation"></param>
        /// <returns></returns>
        public static Symbol CreateNoteFromMXMLNote(Note mxmlNote, double beat = 1.0, int durationDivision = 256, int addToDuration = 0, Articulation articulation = null)
        {
            if (mxmlNote == null) return null;


            Symbol symbol;
            if (mxmlNote.IsRest)  // Rests
                symbol = new Rest
                {
                    Beat = beat,
                    Duration = GetDurationFromMXMLNote(mxmlNote, durationDivision, addToDuration),
                    Lyrics = GetLyricsFromMXMLNote(mxmlNote),
                    Voice = GetVoiceFromMXMLNote(mxmlNote),
                    Articulations = articulation
                };
            else if (mxmlNote.IsGrace)
                // Grace Notes
                symbol = new GraceNote
                {
                    Beat = beat,
                    Velocity = 0,
                    Duration = GetDurationFromMXMLNote(mxmlNote, durationDivision, addToDuration),
                    Octave = mxmlNote.Pitch != null ? int.Parse(mxmlNote.Pitch.Octave) : 0,
                    Step = GetPitchFromMXMLNote(mxmlNote),
                    Lyrics = GetLyricsFromMXMLNote(mxmlNote),
                    Voice = GetVoiceFromMXMLNote(mxmlNote),
                    Articulations = articulation
                };
            else
                // Notes
                symbol = new Model.Sections.Notes.Note
                {
                    Beat = beat,
                    Velocity = 0,
                    Duration = GetDurationFromMXMLNote(mxmlNote, durationDivision, addToDuration),
                    Octave = mxmlNote.Pitch != null ? int.Parse(mxmlNote.Pitch.Octave) : 0,
                    Step = GetPitchFromMXMLNote(mxmlNote),
                    Lyrics = GetLyricsFromMXMLNote(mxmlNote),
                    Voice = GetVoiceFromMXMLNote(mxmlNote),
                    Articulations = articulation
                };

            if (mxmlNote.Notations != null)
            {
                symbol.Articulations = articulation ?? new Articulation();

                foreach (var item in mxmlNote.Notations)
                {
                    if (item.Articulations != null)
                    {
                        if (item.Articulations.Accent != null)
                            symbol.Articulations.Accent = Accent.Standard;

                        if (item.Articulations.Staccato != null)
                            symbol.Articulations.Accent = Accent.Staccato;

                        if (item.Articulations.Tenuto != null)
                            symbol.Articulations.Accent = Accent.Tenuto;

                        if (item.Articulations.StrongAccent != null)
                            symbol.Articulations.Accent = Accent.Marcato;

                        if (item.Articulations.Staccatissimo != null)
                            symbol.Articulations.Accent = Accent.Staccatissimo;

                        if (item.Articulations.DetachedLegato != null)
                            symbol.Articulations.Accent = Accent.Portato;

                        if (item.Articulations.Spiccato != null)
                            symbol.Articulations.Bowing = Bowing.Spiccato;


                        if (item.Articulations.Scoop != null)
                            symbol.Articulations.Sliding = Sliding.Scoop;

                        if (item.Articulations.Falloff != null)
                            symbol.Articulations.Sliding = Sliding.FallOff;

                        if (item.Articulations.Doit != null)
                            symbol.Articulations.Sliding = Sliding.Doit;

                        if (item.Articulations.Plop != null)
                            symbol.Articulations.Sliding = Sliding.Plop;
                    }

                    if (item.Technical != null)
                    {
                        if (item.Technical.UpBow != null)
                            symbol.Articulations.Bowing = Bowing.Up;
                        if (item.Technical.DownBow != null)
                            symbol.Articulations.Bowing = Bowing.Down;
                        if (item.Technical.OpenString != null)
                            symbol.Articulations.Bowing = Bowing.OpenString;
                    }
                    if (item.Dynamics != null)
                    {
                        symbol.Articulations.Dynamics = (Dynamics)Enum.Parse(typeof(Dynamics), item.Dynamics.ItemsElementName.FirstOrDefault().ToString());
                    }

                    if (item.Fermata != null)
                        switch (item.Fermata.Value)
                        {
                            case fermatashape.normal:
                                symbol.Articulations.Fermata = Fermata.Standard; break;
                            case fermatashape.angled:
                                symbol.Articulations.Fermata = Fermata.Short; break;
                            case fermatashape.square:
                                symbol.Articulations.Fermata = Fermata.Long; break;
                        }

                    if (item.Arpeggiate != null)
                        symbol.Articulations.Arpeggiate = true;

                    if (item.Slur != null)
                        switch (item.Slur.type)
                        {
                            case startstopcontinue.start:
                                symbol.Articulations.Slur = Slur.Start; break;
                            case startstopcontinue.stop:
                                symbol.Articulations.Slur = Slur.End; break;
                            case startstopcontinue.@continue:
                                symbol.Articulations.Slur = Slur.Middle; break;
                        }

                    if (item.Ornaments != null)
                    {
                        if (item.Ornaments.TrillMark != null)
                            symbol.Articulations.Trill = true;
                        if (item.Ornaments.Tremolo != null)
                            symbol.Articulations.Tremolo = true;

                        if (item.Ornaments.Turn != null)
                            symbol.Articulations.Ornament = Ornament.Turn;
                        if (item.Ornaments.InvertedTurn != null)
                            symbol.Articulations.Ornament = Ornament.InvertedTurn;
                        if (item.Ornaments.DelayedTurn != null)
                            symbol.Articulations.Ornament = Ornament.DelayedTurn;
                        if (item.Ornaments.DelayedInvertedTurn != null)
                            symbol.Articulations.Ornament = Ornament.DelayedInvertedTurn;
                        if (item.Ornaments.VerticalTurn != null)
                            symbol.Articulations.Ornament = Ornament.VerticalTurn;

                        if (item.Ornaments.Mordent != null)
                            symbol.Articulations.Ornament = Ornament.Mordent;
                        if (item.Ornaments.InvertedMordent != null)
                            symbol.Articulations.Ornament = Ornament.InvertedMordent;

                        if (item.Ornaments.Schleifer != null)
                            symbol.Articulations.Ornament = Ornament.Schleifer;
                        if (item.Ornaments.Shake != null)
                            symbol.Articulations.Ornament = Ornament.Shake;
                        if (item.Ornaments.WavyLine != null)
                            symbol.Articulations.Ornament = Ornament.WavyLine;

                    }

                }
            }

            return symbol;

        }

        private static bool _durationErrorDisplayed;
        /// <summary>
        /// Parses the duration from a MusicXML note
        /// </summary>
        /// <param name="mxmlNote"></param>
        /// <param name="durationDivision"></param>
        /// <param name="addToDuration"></param>
        /// <returns></returns>
        public static Duration GetDurationFromMXMLNote(Note mxmlNote, int durationDivision = 256, int addToDuration = 0)
        {
            // Division
            var duration = int.Parse(mxmlNote.Duration.ToString(CultureInfo.InvariantCulture)) + addToDuration;
            if (durationDivision != 960)
                duration = (int)((double)duration / durationDivision * 960);

            if (!Enum.IsDefined(typeof(Duration), duration))
            {
                for (var tolerance = -12; tolerance <= 12; tolerance++)
                    if (Enum.IsDefined(typeof(Duration), duration - tolerance))
                        duration -= tolerance;

                if (!Enum.IsDefined(typeof(Duration), duration))
                {
                    if (!_durationErrorDisplayed)
                    {
                        MessageBox.Show(
                            "This score contains a combination of notes that is not supported, namely " + duration + ". These notes will not be displayed.",
                            "Error");
                        _durationErrorDisplayed = true;
                    }
                    Console.WriteLine(@"Error parsing duration " + mxmlNote.Duration);
                    duration = 0;
                }
            }
            return (Duration)duration;
        }

        /// <summary>
        /// Retrieves a list of lyrics from a MusicXML note
        /// </summary>
        /// <param name="mxmlNote"></param>
        /// <returns></returns>
        public static List<Lyric> GetLyricsFromMXMLNote(Note mxmlNote)
        {
            var result = new List<Lyric>();
            if (mxmlNote.Lyric == null) return result;
            foreach (var verse in mxmlNote.Lyric.Where(item => item.Text != null))
                result.Add(new Lyric { Text = verse.Text.Value, Syllabic = (Syllabic)verse.Syllabic, Line = GetLineFromLyricsNumber(verse.number) });

            return result;
        }

        /// <summary>
        /// Tries to interpret the cryptic string that applications (mis)use to encode what line a lyric is on
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int GetLineFromLyricsNumber(string number)
        {
            if (!string.IsNullOrEmpty(number))
                try
                {
                    if (number.Contains("verse")) // for Sibelius
                        return int.Parse(Regex.Match(number.Substring(number.IndexOf("verse", StringComparison.Ordinal) + 5), @"\d+").Value);
                    return int.Parse(Regex.Match(number, @"\d+").Value);
                }
                catch
                {
                    return 1;
                }
            return 1;
        }

        /// <summary>
        /// Extract the voice from a MusicXML note
        /// </summary>
        /// <param name="mxmlNote"></param>
        /// <returns></returns>
        public static int GetVoiceFromMXMLNote(Note mxmlNote)
        {
            if (!string.IsNullOrEmpty(mxmlNote.voice))
                try
                {
                    return int.Parse(Regex.Match(mxmlNote.voice, @"\d+").Value);
                }
                catch
                {
                    return 0;
                }
            return 0;
        }

        /// <summary>
        /// Extracts the Pitch from a MusicXML note
        /// </summary>
        /// <param name="mxmlNote"></param>
        /// <returns></returns>
        public static Step GetPitchFromMXMLNote(Note mxmlNote)
        {
            if (mxmlNote.Pitch == null)
                return Step.Unknown;
            switch ((int)mxmlNote.Pitch.Alter)
            {
                case 0:
                    switch (mxmlNote.Pitch.Step)
                    {
                        case MusicXML.Step.A:
                            return Step.A;
                        case MusicXML.Step.B:
                            return Step.B;
                        case MusicXML.Step.C:
                            return Step.C;
                        case MusicXML.Step.D:
                            return Step.D;
                        case MusicXML.Step.E:
                            return Step.E;
                        case MusicXML.Step.F:
                            return Step.F;
                        case MusicXML.Step.G:
                            return Step.G;
                    }
                    break;
                case 1:
                    switch (mxmlNote.Pitch.Step)
                    {
                        case MusicXML.Step.A:
                            return Step.ASharp;
                        case MusicXML.Step.B:
                            return Step.BSharp;
                        case MusicXML.Step.C:
                            return Step.CSharp;
                        case MusicXML.Step.D:
                            return Step.DSharp;
                        case MusicXML.Step.E:
                            return Step.ESharp;
                        case MusicXML.Step.F:
                            return Step.FSharp;
                        case MusicXML.Step.G:
                            return Step.GSharp;
                    }
                    break;
                case -1:
                    switch (mxmlNote.Pitch.Step)
                    {
                        case MusicXML.Step.A:
                            return Step.AFlat;
                        case MusicXML.Step.B:
                            return Step.BFlat;
                        case MusicXML.Step.C:
                            return Step.CFlat;
                        case MusicXML.Step.D:
                            return Step.DFlat;
                        case MusicXML.Step.E:
                            return Step.EFlat;
                        case MusicXML.Step.F:
                            return Step.FFlat;
                        case MusicXML.Step.G:
                            return Step.GFlat;
                    }
                    break;
            }
            return Step.Unknown;
        }

        /// <summary>
        /// Turns a MusicXML key into a Musicista key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static MusicalKey GetKeyFromMXMLKey(key key)
        {
            var fifths = int.Parse(key.Fifths);
            var mode = key.Mode;

            switch (mode)
            {
                case "major":
                    switch (fifths)
                    {
                        case 0:
                            return new MusicalKey(Step.C, Gender.Major);
                        case 1:
                            return new MusicalKey(Step.G, Gender.Major);
                        case 2:
                            return new MusicalKey(Step.D, Gender.Major);
                        case 3:
                            return new MusicalKey(Step.A, Gender.Major);
                        case 4:
                            return new MusicalKey(Step.E, Gender.Major);
                        case 5:
                            return new MusicalKey(Step.B, Gender.Major);
                        case 6:
                            return new MusicalKey(Step.FSharp, Gender.Major);
                        case 7:
                            return new MusicalKey(Step.CSharp, Gender.Major);
                        case -1:
                            return new MusicalKey(Step.F, Gender.Major);
                        case -2:
                            return new MusicalKey(Step.BFlat, Gender.Major);
                        case -3:
                            return new MusicalKey(Step.EFlat, Gender.Major);
                        case -4:
                            return new MusicalKey(Step.AFlat, Gender.Major);
                        case -5:
                            return new MusicalKey(Step.DFlat, Gender.Major);
                        case -6:
                            return new MusicalKey(Step.GFlat, Gender.Major);
                        case -7:
                            return new MusicalKey(Step.CFlat, Gender.Major);
                    }
                    break;
                case "minor":
                    switch (fifths)
                    {
                        case 0:
                            return new MusicalKey(Step.A, Gender.Minor);
                        case 1:
                            return new MusicalKey(Step.E, Gender.Minor);
                        case 2:
                            return new MusicalKey(Step.B, Gender.Minor);
                        case 3:
                            return new MusicalKey(Step.FSharp, Gender.Minor);
                        case 4:
                            return new MusicalKey(Step.CSharp, Gender.Minor);
                        case 5:
                            return new MusicalKey(Step.GSharp, Gender.Minor);
                        case 6:
                            return new MusicalKey(Step.DSharp, Gender.Minor);
                        case 7:
                            return new MusicalKey(Step.ASharp, Gender.Minor);
                        case -1:
                            return new MusicalKey(Step.D, Gender.Minor);
                        case -2:
                            return new MusicalKey(Step.G, Gender.Minor);
                        case -3:
                            return new MusicalKey(Step.C, Gender.Minor);
                        case -4:
                            return new MusicalKey(Step.F, Gender.Minor);
                        case -5:
                            return new MusicalKey(Step.BFlat, Gender.Minor);
                        case -6:
                            return new MusicalKey(Step.EFlat, Gender.Minor);
                        case -7:
                            return new MusicalKey(Step.AFlat, Gender.Minor);
                    }
                    break;
            }
            return new MusicalKey(Step.C, Gender.Major);
        }
        #endregion

    }
}