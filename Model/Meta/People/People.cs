using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Model.Meta.People
{
    public class People
    {
        [XmlArray("Composers")]
        public List<Composer> Composers { get; set; }
        public bool ShouldSerializeComposers() { return Composers != null && Composers.Any(); }

        [XmlArray("Lyricists")]
        public List<Person> Lyricists { get; set; }
        public bool ShouldSerializeLyricists() { return Lyricists != null && Lyricists.Any(); }

        [XmlArray("Arrangers")]
        public List<Person> Arrangers { get; set; }
        public bool ShouldSerializeArrangers() { return Arrangers != null && Arrangers.Any(); }

        [XmlArray("Producers")]
        public List<Person> Producers { get; set; }
        public bool ShouldSerializeProducers() { return Producers != null && Producers.Any(); }

        [XmlArray("Interpreters")]
        public List<Person> Interpreters { get; set; }
        public bool ShouldSerializeInterpreters() { return Interpreters != null && Interpreters.Any(); }

        [XmlArray("OtherPersons")]
        public List<Person> OtherPersons { get; set; }
        public bool ShouldSerializeOtherPersons() { return OtherPersons != null && OtherPersons.Any(); }


        [XmlIgnore]
        public String ComposersAsString { get { return String.Join(", ", Composers); } }

        public People()
        {
            Composers = new List<Composer>();
            Interpreters = new List<Person>();
            Lyricists = new List<Person>();
            Producers = new List<Person>();
            OtherPersons = new List<Person>();
        }
    }
}
