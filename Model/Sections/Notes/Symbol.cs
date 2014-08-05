using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Model.Sections.Notes
{
    public abstract class Symbol
    {
        [XmlAttribute("Voice")]
        public int Voice { get; set; }

        [XmlAttribute("Duration")]
        public Duration Duration { get; set; }

        [XmlAttribute("Beat")]
        public double Beat { get; set; }

        [XmlArray("Lyrics")]
        public List<Lyric> Lyrics { get; set; }
        public bool ShouldSerializeLyrics() { return Lyrics != null && Lyrics.Any(); }


        [XmlElement("Articulation")]
        public Articulation.Articulation Articulations { get; set; }
        public bool ShouldSerializeArticulations() { return Articulations != null && Articulations.ShouldSerialize; }


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
