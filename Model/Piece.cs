using Model.Meta;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Piece
    {
        public string Title { get; set; }
        public List<Composer> ListOfComposers { get; set; }
        public string Collection { get; set; }
        public OpusNumber Opus { get; set; }
        public Epoch Epoch { get; set; }
        public Form Form { get; set; }
        public DateTime DateOfComposition { get; set; }
        public DateTime DateOfFirstPerformance { get; set; }
        public string PlaceOfFirstPerformance { get; set; }
        public DateTime DateOfFirstPublication { get; set; }
        public string Dedication { get; set; }
        public double AverageDuration { get; set; }
        public List<Person> ListOfLyricists { get; set; }
        public List<Person> ListOfProducers { get; set; }
        public List<Person> ListOfInterpreters { get; set; }
        public int BeatsPerMinute { get; set; }
        public MusicalKey Key { get; set; }
        public Album Album { get; set; }

        public string TypeSetter { get; set; }
        public DateTime DateOfTypesetting { get; set; }
        public string Copyright { get; set; }
        public string Publisher { get; set; }
        public string Reduction { get; set; }
        public Uri Weblink { get; set; }
        public string Notes { get; set; }


        public List<Instrument> ListOfInstruments { get; set; }
        public List<Section> ListOfSections { get; set; }

        public Piece()
        {
            ListOfComposers = new List<Composer>();
            ListOfInterpreters = new List<Person>();
            ListOfLyricists = new List<Person>();
            ListOfProducers = new List<Person>();
            ListOfInstruments = new List<Instrument>();
            ListOfSections = new List<Section>();
        }

    }
}
