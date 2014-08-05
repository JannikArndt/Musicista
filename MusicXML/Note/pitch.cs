using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class Pitch
    {
        [XmlElement("step")]
        public Step Step { get; set; }

        [XmlElement("alter")]
        public decimal Alter { get; set; }


        [XmlIgnore]
        public bool AlterSpecified { get; set; }


        [XmlElement("octave", DataType = "integer")]
        public string Octave { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Pitch)obj;
            return Step == other.Step && Alter == other.Alter && Octave == other.Octave;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Step.GetHashCode() ^ Alter.GetHashCode() ^ Octave.GetHashCode();
        }

        public override string ToString()
        {
            return "Note " + Step + Alter + Octave;
        }
    }
}