using Model.Sections;
using Model.Sections.Notes;
using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Represents a text with a reference to a piece
    /// </summary>
    public class Comment
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
        [XmlAttribute("Author")]
        public string Author { get; set; }

        [XmlElement("NoteReference")]
        public NoteReference NoteReference { get; set; }

        [XmlElement("Text")]
        public string CommentText { get; set; }
        public Comment() { }
        public Comment(string commentText, Symbol noteReference, Movement belongsToMovement, string author)
        {
            CommentText = commentText;
            BelongsToMovement = belongsToMovement;
            NoteReference = new NoteReference(noteReference);
            Author = author;
        }
    }
}
