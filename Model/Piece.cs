using Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Model
{
    public class Piece
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public List<Composer> ListOfComposers { get; set; }
        [XmlIgnore]
        public String ComposersAsString { get { return String.Join(", ", ListOfComposers); } }
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
        public List<Person> ListOfArrangers { get; set; }
        public List<Person> ListOfProducers { get; set; }
        public List<Person> ListOfInterpreters { get; set; }
        public List<Person> ListOfOtherPersons { get; set; }
        public int BeatsPerMinute { get; set; }
        public MusicalKey Key { get; set; }
        public Album Album { get; set; }

        public string TypeSetter { get; set; }
        public DateTime DateOfTypesetting { get; set; }
        public string Copyright { get; set; }
        public string Publisher { get; set; }
        public string Reduction { get; set; }
        public string Weblink { get; set; }
        public string Notes { get; set; }
        public string Software { get; set; }


        public List<Instrument> ListOfInstruments { get; set; }
        public List<Section> ListOfSections { get; set; }

        [XmlIgnore]
        public List<Movement> ListOfAllMovements { get { return ListOfSections.SelectMany(section => section.ListOfMovements).ToList(); } }
        [XmlIgnore]
        public List<Segment> ListOfAllSegments { get { return ListOfAllMovements.SelectMany(movement => movement.ListOfSegments).ToList(); } }
        [XmlIgnore]
        public List<Passage> ListOfAllPassages { get { return ListOfAllSegments.SelectMany(segment => segment.ListOfPassages).ToList(); } }
        [XmlIgnore]
        public List<MeasureGroup> ListOfAllMeasureGroups { get { return ListOfAllPassages.SelectMany(passage => passage.ListOfMeasureGroups).ToList(); } }
        [XmlIgnore]
        public List<Measure> ListOfAllMeasures { get { return ListOfAllMeasureGroups.SelectMany(measureGroup => measureGroup.Measures).ToList(); } }

        public List<Part> Parts { get; set; }

        public Piece()
        {
            Title = "New Piece";
            ListOfComposers = new List<Composer>();
            ListOfInterpreters = new List<Person>();
            ListOfLyricists = new List<Person>();
            ListOfProducers = new List<Person>();
            ListOfOtherPersons = new List<Person>();
            ListOfInstruments = new List<Instrument>();
            ListOfSections = new List<Section>();
            Parts = new List<Part>();

            Collection = "";
            Opus = new OpusNumber();
            Epoch = Epoch.None;
            Form = Form.Other;
        }
    }
}
