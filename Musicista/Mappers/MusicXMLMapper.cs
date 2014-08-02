using Model;
using Model.Meta;
using Model.Meta.People;
using Model.Sections;
using Model.Sections.Notes;
using MuseScoreAPI.RESTObjects;
using MusicXML;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using Clef = Model.Sections.Notes.Clef;
using Duration = Model.Sections.Notes.Duration;
using Lyric = Model.Sections.Notes.Lyric;
using Note = MusicXML.Note;
using Step = Model.Meta.Step;

namespace Musicista.Mappers
{
    public static class MusicXMLMapper
    {
        public static Piece MapMusicXMLToMusicista(ScorePartwise mxml, String filename, Score scoreInfo = null)
        {
            var piece = Mapper.CreateEmptyPiece();

            // Map work information
            if (!string.IsNullOrEmpty(mxml.Work.WorkTitle))
                piece.Meta.Title = mxml.Work.WorkTitle;
            else if (scoreInfo != null)
                piece.Meta.Title = scoreInfo.Title;
            else
                piece.Meta.Title = Path.GetFileNameWithoutExtension(filename);

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
                            piece.Meta.People.Composers.Add(new Composer { FullName = creator.Value });
                            break;
                        case "lyricist":
                            piece.Meta.People.Lyricists.Add(new Person { FullName = creator.Value });
                            break;
                        case "arranger":
                            piece.Meta.People.Arrangers.Add(new Person { FullName = creator.Value });
                            break;
                        default:
                            piece.Meta.People.OtherPersons.Add(new Person { FullName = creator.Value });
                            break;
                    }

            // Map the instruments
            if (mxml.PartList.ScoreParts != null)
                foreach (var scorepart in mxml.PartList.ScoreParts)
                    piece.Instruments.Add(new Instrument(scorepart.Partname, int.Parse(Regex.Match(scorepart.id, @"\d+").Value)));

            // Map movement information
            if (mxml.MovementNumber != null)
                piece.Movements.First().Number = int.Parse(mxml.MovementNumber);
            if (mxml.MovementTitle != null)
                piece.Movements.First().Name = mxml.MovementTitle;

            // For downloads from MuseScore.com
            if (scoreInfo != null)
            {
                piece.Meta.Weblink = scoreInfo.Permalink;
                piece.Meta.People.OtherPersons.Add(new Person { FullName = scoreInfo.User.Username, Role = "Uploader", Misc = "User ID = " + scoreInfo.User.Uid });
                piece.Meta.Copyright = scoreInfo.License;
                piece.Meta.Notes += scoreInfo.Description;
                piece.Meta.Subtitle = scoreInfo.Metadata.Subtitle;
                if (piece.Meta.People.Composers.Count == 0 && !string.IsNullOrEmpty(scoreInfo.Metadata.Composer))
                    piece.Meta.People.Composers.Add(new Composer { FullName = scoreInfo.Metadata.Composer });
                if (piece.Meta.People.Lyricists.Count == 0 && !string.IsNullOrEmpty(scoreInfo.Metadata.Poet))
                    piece.Meta.People.Lyricists.Add(new Person { FullName = scoreInfo.Metadata.Poet });
            }

            // Map the music
            MapPartwiseMeasuresToPiece(mxml, piece);

            return piece;
        }
        /// <summary>
        /// Maps a partwise-MusicXML-Object to a Musicista Piece. The structure is 
        /// <score-partwise><part id="P1"><measure number="1"></measure><measure number="2"></measure>...</part><part id="P2">...</part></score-partwise>
        /// </summary>
        /// <param name="mxml">A ScorePartwise-object</param>
        /// <param name="piece">The Piece-object the measures will be added to</param>
        /// <returns>The given Piece with the measures in it.</returns>
        public static Piece MapPartwiseMeasuresToPiece(ScorePartwise mxml, Piece piece)
        {
            var lastClef = new List<Clef>();
            for (var i = 0; i < mxml.Part[0].Measure.Length; i++)
                lastClef.Add(Clef.Treble);

            var lastClefAdditionalStaves = new List<Clef>();
            for (var i = 0; i < mxml.Part[0].Measure.Length; i++)
                lastClefAdditionalStaves.Add(Clef.Treble);

            var listOfAdditionalStaves = new Dictionary<int, List<Measure>>();

            var lastKey = new MusicalKey(Step.C, Gender.Major);
            var lastTime = new TimeSignature(4, 4);
            var durationDivision = 960; // = one quarter

            // take the first part, go through all measure, for each measure look up the other parts
            for (var measureNumber = 0; measureNumber < mxml.Part[0].Measure.Length; measureNumber++)
            {
                // 1. Create a parent MeasureGroup
                ScorePartwisePartMeasure measure = mxml.Part[0].Measure[measureNumber];
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

                    // crazy multiple staves-madness, part 1
                    if (currentMeasure.Attributes != null && currentMeasure.Attributes.staves != null && int.Parse(currentMeasure.Attributes.staves) > 1)
                        listOfAdditionalStaves.Add(partNumber, new List<Measure>());
                    if (listOfAdditionalStaves.ContainsKey(partNumber))
                    {
                        if (currentMeasure.Attributes != null)
                            lastClefAdditionalStaves[partNumber] = GetClefFromAttributes(currentMeasure.Attributes, true) ?? lastClefAdditionalStaves[partNumber];
                        listOfAdditionalStaves[partNumber].Add(new Measure
                        {
                            Instrument = piece.Instruments[partNumber],
                            ParentMeasureGroup = measureGroup,
                            Clef = lastClefAdditionalStaves[partNumber]

                        });
                    }

                    // get correct clef
                    if (currentMeasure.Attributes != null)
                        lastClef[partNumber] = GetClefFromAttributes(currentMeasure.Attributes) ?? lastClef[partNumber];

                    // 3. create a new measure for each part
                    var newMeasure = new Measure
                    {
                        Instrument = piece.Instruments[partNumber],
                        ParentMeasureGroup = measureGroup,
                        Clef = lastClef[partNumber]
                    };

                    // 4a. Split voices (crazy multiple staves-madness, part 2)
                    var voices = items.Aggregate(new List<List<Note>> { new List<Note>() },
                                   (list, value) =>
                                   {
                                       if (value.GetType() == typeof(Note)) list.Last().Add((Note)value);
                                       if (value.GetType() == typeof(backup)) list.Add(new List<Note>());
                                       return list;
                                   });

                    // 4b. and add the Notes and Rests of each Measure
                    for (var voice = 0; voice < voices.Count; voice++)
                    {
                        double beat = 960;
                        double advanceBeat = 0;
                        foreach (var mxmlNote in voices[voice])
                        {
                            if (!mxmlNote.IsChord) // advance beat-counter only if <chord>-Tag is not present
                                beat += advanceBeat;


                            // Tied notes
                            var addDuration = 0;
                            if (mxmlNote.IsTied && mxmlNote.Tie.Type == startstop.start && mxml.Part[partNumber].Measure.Count() > measureNumber + 1) // make tied notes (starting the tie) longer
                            {
                                var nextMeasure = mxml.Part[partNumber].Measure[measureNumber + 1];
                                var tiedNote = nextMeasure.Items.OfType<Note>().FirstOrDefault(item => Equals(item.Pitch, mxmlNote.Pitch) && item.IsTied && item.Tie.Type == startstop.stop);
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

                            var newNote = CreateNoteFromMXMLNote(mxmlNote, beat / 960, durationDivision, addDuration);
                            if (newNote.Voice == 0)
                                newNote.Voice = voice + 1;

                            advanceBeat = (int)newNote.Duration; // IF the next note advances the beat counter, it should be by this amount

                            if (mxmlNote.staff == null || mxmlNote.staff == "1")
                                newMeasure.AddSymbol(newNote);
                            else if (listOfAdditionalStaves.ContainsKey(partNumber)) //crazy multiple staves-madness, part 3
                                listOfAdditionalStaves[partNumber][measureNumber].AddSymbol(newNote);
                        }
                    }
                    measureGroup.Measures.Add(newMeasure);
                }
                piece.Sections[0].Movements[0].Segments[0].Passages[0].MeasureGroups.Add(measureGroup);
            }
            //crazy multiple staves-madness, part 4
            if (listOfAdditionalStaves.Count > 0)
                foreach (var additionalStaff in listOfAdditionalStaves.Reverse())
                {
                    var instrument = new Instrument(piece.Instruments[additionalStaff.Key].Name);
                    piece.Instruments.Add(instrument);
                    foreach (var measure in additionalStaff.Value)
                    {
                        measure.Instrument = instrument;
                        measure.ParentMeasureGroup.Measures.Insert(additionalStaff.Key + 1, measure);
                    }
                }
            // Correct the first measure if it is a pickup measure
            if (piece.MeasureGroups.First() != null && piece.MeasureGroups.First().IsPickupMeasure)
                foreach (var measure in piece.MeasureGroups.First().Measures)
                    CorrectPickupMeasure(measure);
            return piece;
        }

        private static void CorrectPickupMeasure(Measure measure)
        {
            var difference = measure.ParentMeasureGroup.HoldsDuration - measure.Symbols.Sum(item => (int)item.Duration);
            if (difference > 0)
                foreach (var symbol in measure.Symbols)
                    symbol.Beat += difference / (double)Duration.Quarter;
        }

        private static Clef? GetClefFromAttributes(attributes attributes, bool takeLast = false)
        {
            if (attributes == null || attributes.clef == null || attributes.clef[0] == null)
                return null;

            var clef = takeLast ? attributes.clef.Last() : attributes.clef.First();

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

        public static Symbol CreateNoteFromMXMLNote(Note mxmlNote, double beat = 1.0, int durationDivision = 256, int addToDuration = 0)
        {
            if (mxmlNote == null) return null;

            if (mxmlNote.IsRest)  // Rests
                return new Rest
                {
                    Beat = beat,
                    Duration = GetDurationFromMXMLNote(mxmlNote, durationDivision, addToDuration),
                    Lyrics = GetLyricsFromMXMLNote(mxmlNote),
                    Voice = GetVoiceFromMXMLNote(mxmlNote)
                };

            // Notes
            return new Model.Sections.Notes.Note
            {
                Beat = beat,
                Velocity = 0,
                Duration = GetDurationFromMXMLNote(mxmlNote, durationDivision, addToDuration),
                Octave = mxmlNote.Pitch != null ? int.Parse(mxmlNote.Pitch.Octave) : 0,
                Step = GetPitchFromMXMLNote(mxmlNote),
                Lyrics = GetLyricsFromMXMLNote(mxmlNote),
                Voice = GetVoiceFromMXMLNote(mxmlNote)
            };
        }

        private static bool _durationErrorDisplayed;
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

        public static List<Lyric> GetLyricsFromMXMLNote(Note mxmlNote)
        {
            var result = new List<Lyric>();
            if (mxmlNote.Lyric != null)
                for (var verse = 0; verse < mxmlNote.Lyric.Length; verse++)
                    if (mxmlNote.Lyric[verse].Text != null)
                    {
                        while (Int32.Parse(mxmlNote.Lyric[verse].number) > verse + 1)
                            result.Add(new Lyric());
                        result.Add(new Lyric { Text = mxmlNote.Lyric[verse].Text.Value, Syllabic = (Syllabic)mxmlNote.Lyric[verse].Syllabic });
                    }
            return result;
        }

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
    }
}