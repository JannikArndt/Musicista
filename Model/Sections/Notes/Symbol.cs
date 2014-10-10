using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Model.Sections.Notes
{
    public abstract class Symbol
    {
        /// <summary>
        /// This voice determines if the stem is drawn up or down.
        /// </summary>
        [XmlAttribute("Voice")]
        public int Voice { get; set; }

        /// <summary>
        /// The duration as as enum.
        /// </summary>
        [XmlAttribute("Duration")]
        public Duration Duration { get; set; }

        /// <summary>
        /// The beat is from the half-open interval [1, BeatsPerMeasure + 1), i.e. a 4/4 measure starts at 1.0, the last 16th would be on 4.75, but 5.0 would equal the next measure's 1.0.
        /// </summary>
        [XmlAttribute("Beat")]
        public double Beat { get; set; }

        /// <summary>
        /// A list of lyrics, for multiple verses.
        /// </summary>
        [XmlArray("Lyrics")]
        public List<Lyric> Lyrics { get; set; }
        public bool ShouldSerializeLyrics() { return Lyrics != null && Lyrics.Any(); }


        [XmlIgnore]
        public TimeSpan AbsoluteTime { get; set; }
        /// <summary>
        /// The time passed since the beginning of the movement. Can be used for synchronization.
        /// </summary>
        [XmlAttribute("AbsoluteTime")]
        public String AbsoluteTimeString
        {
            get { return AbsoluteTime.ToString(); }
            set { AbsoluteTime = TimeSpan.Parse(value); }
        }
        public bool ShouldSerializeAbsoluteTimeString() { return AbsoluteTime.TotalMilliseconds > 0; }

        /// <summary>
        /// The Articulation object holds everything from dymanic to bowing.
        /// </summary>
        [XmlElement("Articulation")]
        public Articulation.Articulation Articulations { get; set; }
        public bool ShouldSerializeArticulations() { return Articulations != null && Articulations.ShouldSerialize; }


        [XmlIgnore]
        public Measure ParentMeasure { get; set; }

        /// <summary>
        /// The previous symbol, i.e. the last symbol in the measure with the same voice and a smaller beat.
        /// </summary>
        [XmlIgnore]
        public Symbol Previous
        {
            get { return ParentMeasure.Symbols.FindLast(s => s.Voice == Voice && s.Beat < Beat); }
        }

        /// <summary>
        /// The previous note, i.e. the last note in the measure with the same voice and a smaller beat.
        /// </summary>
        [XmlIgnore]
        public Note PreviousNote
        {
            get { return ParentMeasure.Notes.FindLast(s => s.Voice == Voice && s.Beat < Beat); }
        }

        /// <summary>
        /// The previous rest, i.e. the last rest in the measure with the same voice and a smaller beat.
        /// </summary>
        [XmlIgnore]
        public Rest PreviousRests
        {
            get { return ParentMeasure.Rests.FindLast(s => s.Voice == Voice && s.Beat < Beat); }
        }

        /// <summary>
        /// The next symbol, i.e. the first symbol in the measure with the same voice and a larger beat.
        /// </summary>
        [XmlIgnore]
        public Symbol Next
        {
            get { return ParentMeasure.Symbols.Find(s => s.Voice == Voice && s.Beat > Beat); }
        }

        /// <summary>
        /// The next note, i.e. the first note in the measure with the same voice and a larger beat.
        /// </summary>
        [XmlIgnore]
        public Note NextNote
        {
            get { return ParentMeasure.Notes.Find(s => s.Voice == Voice && s.Beat > Beat); }
        }

        /// <summary>
        /// The next rest, i.e. the first rest in the measure with the same voice and a larger beat.
        /// </summary>
        [XmlIgnore]
        public Rest NextRest
        {
            get { return ParentMeasure.Rests.Find(s => s.Voice == Voice && s.Beat > Beat); }
        }

        /// <summary>
        /// The measure number, taken from the parent MeasureGroup. If that is not set, the measure number is always 0.
        /// </summary>
        [XmlIgnore]
        public int MeasureNumber
        {
            get { return ParentMeasure == null ? 0 : ParentMeasure.ParentMeasureGroup == null ? 0 : ParentMeasure.ParentMeasureGroup.MeasureNumber; }
        }

        /// <summary>
        /// Readonly. Returns if the duration has the -Triplet suffix.
        /// </summary>
        [XmlIgnore]
        public bool IsTriplet
        {
            get
            {
                return (Duration == Duration.WholeTriplet || Duration == Duration.HalfTriplet || Duration == Duration.QuarterTriplet
                    || Duration == Duration.EigthTriplet || Duration == Duration.SixteenthTriplet || Duration == Duration.ThirtysecondTriplet);
            }
        }

        /// <summary>
        /// The part of the duration that actually fits in the measure. Example: in a 4/4 measure a half on the 4.0 would have a duration of a Quarter.
        /// </summary>
        [XmlIgnore]
        public Duration DurationInMeasure
        {
            get
            {
                var durationAlreadySpent = (Beat - 1) * ParentMeasure.ParentMeasureGroup.TimeSignature.Beats / ParentMeasure.ParentMeasureGroup.TimeSignature.BeatUnit * 4;
                var durationLeftInMeasure = ParentMeasure.ParentMeasureGroup.HoldsDuration - durationAlreadySpent;
                var result = (Duration)Math.Min(durationLeftInMeasure, (double)Duration);

                // Parse result (tolerance for triplets)
                if (!Enum.IsDefined(typeof(Duration), result))
                {
                    for (var tolerance = -12; tolerance <= 12; tolerance++)
                    {
                        if (Enum.IsDefined(typeof(Duration), result - tolerance))
                            result -= tolerance;
                    }

                    if (!Enum.IsDefined(typeof(Duration), result))
                        Console.WriteLine(@"Error parsing duration " + result);
                }

                return result;
            }
        }

        public Symbol()
        {
            Lyrics = new List<Lyric>();
            Articulations = new Articulation.Articulation();
            AbsoluteTime = new TimeSpan(0, 0, 0, 0, 0);
        }

        /// <summary>
        /// Adds lyrics at the correct position in the list, automatically extends the list if necessary. Attention, this overwrites existing lyrics!
        /// </summary>
        /// <param name="text"></param>
        /// <param name="verse"></param>
        /// <param name="syllabic"></param>
        public void AddLyrics(string text, int verse, Syllabic syllabic)
        {
            if (Lyrics == null)
                Lyrics = new List<Lyric>();

            while (Lyrics.Count < verse)
                Lyrics.Add(new Lyric());

            Lyrics[verse - 1] = new Lyric { Text = text, Syllabic = syllabic };
        }
    }
}
