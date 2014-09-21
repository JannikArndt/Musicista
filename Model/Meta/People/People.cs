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
        public String ComposersAsString { get { return String.Join(", ", Persons.OfType<Composer>()); } }

        public People()
        {
            Persons = new List<Person>();
        }
    }
}
