using Model.Meta;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
    public abstract class Symbol
    {
        public double Beat { get; set; }
        public Duration Duration { get; set; }
        public int Voice { get; set; }
        public List<Lyric> Lyrics { get; set; }
        public List<Expression> Expressions { get; set; }
        public List<Ornament> Ornaments { get; set; }
        [XmlIgnore]
        public Measure ParentMeasure { get; set; }

        [XmlIgnore]
        public Symbol Previous
        {
            get { return ParentMeasure.Symbols.FindLast(s => s.Voice == Voice && s.Beat < Beat); }
        }
        [XmlIgnore]
        public Symbol Next
        {
            get { return ParentMeasure.Symbols.Find(s => s.Voice == Voice && s.Beat > Beat); }
        }

        [XmlIgnore]
        public int MeasureNumber
        {
            get { return ParentMeasure.ParentMeasureGroup.MeasureNumber; }
        }

        [XmlIgnore]
        public bool IsTriplet
        {
            get
            {
                return (Duration == Duration.WholeTriplet || Duration == Duration.HalfTriplet || Duration == Duration.QuarterTriplet
                    || Duration == Duration.EigthTriplet || Duration == Duration.SixteenthTriplet || Duration == Duration.ThirtysecondTriplet);
            }
        }

        [XmlIgnore]
        public Duration DurationInMeasure
        {
            get
            {
                var durationAlreadySpent = (Beat - 1) * ((double)Duration.Whole / ParentMeasure.ParentMeasureGroup.TimeSignature.BeatUnit);
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

        protected Symbol()
        {
            Lyrics = new List<Lyric>();
            Ornaments = new List<Ornament>();
            Expressions = new List<Expression>();
        }

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
