using Model.Sections;
using System;
using System.Linq;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Represents a Passage with a reference to the original occurance
    /// </summary>
    public class Part
    {
        [XmlAttribute("Name")]
        public String Name { get; set; }
        [XmlIgnore]
        public Movement BelongsToMovement { get; set; }

        [XmlIgnore]
        private int _movementID;

        [XmlAttribute("Movement")]
        public int MovementID
        {
            get { return BelongsToMovement == null ? _movementID : BelongsToMovement.Number; }
            set { _movementID = value; }
        }
        [XmlElement("Start")]
        public NoteReference Start { get; set; }
        [XmlElement("End")]
        public NoteReference End { get; set; }
        [XmlElement("Passage")]
        public Passage Passage { get; set; }
        public Part() { }
        public Part(Passage passage, Movement belongsToMovement)
        {
            Passage = passage;
            BelongsToMovement = belongsToMovement;
            Start = new NoteReference(Passage.MeasureGroups[0].Measures[0].Symbols[0]);
            End = new NoteReference(Passage.MeasureGroups.Last().Measures.Last().Symbols.Last());
        }
    }
}
