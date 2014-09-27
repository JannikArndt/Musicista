using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Model.Meta.People
{
    public class People
    {
        [XmlElement("Composer", Type = typeof(Composer))]
        [XmlElement("Lyricist", Type = typeof(Lyricist))]
        [XmlElement("Arranger", Type = typeof(Arranger))]
        [XmlElement("Producer", Type = typeof(Producer))]
        [XmlElement("Interpreter", Type = typeof(Interpreter))]
        [XmlElement("Person", Type = typeof(Person))]
        public List<Person> Persons { get; set; }

        [XmlIgnore]
        public List<Composer> Composers { get { return Persons.OfType<Composer>().ToList(); } }

        [XmlIgnore]
        public List<Lyricist> Lyricists { get { return Persons.OfType<Lyricist>().ToList(); } }

        [XmlIgnore]
        public List<Arranger> Arrangers { get { return Persons.OfType<Arranger>().ToList(); } }

        [XmlIgnore]
        public List<Producer> Producers { get { return Persons.OfType<Producer>().ToList(); } }

        [XmlIgnore]
        public List<Interpreter> Interpreters { get { return Persons.OfType<Interpreter>().ToList(); } }

        [XmlIgnore]
        public String ComposersAsString { get { return String.Join(", ", Persons.OfType<Composer>()); } }

        public People()
        {
            Persons = new List<Person>();
        }
    }
}
