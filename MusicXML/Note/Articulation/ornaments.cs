using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note.Articulation
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class Ornaments
    {
        [XmlElement("delayed-inverted-turn", typeof(horizontalturn))]
        public horizontalturn DelayedInvertedTurn { get; set; }



        [XmlElement("delayed-turn", typeof(horizontalturn))]
        public horizontalturn DelayedTurn { get; set; }



        [XmlElement("inverted-mordent", typeof(mordent))]
        public mordent InvertedMordent { get; set; }



        [XmlElement("inverted-turn", typeof(horizontalturn))]
        public horizontalturn InvertedTurn { get; set; }



        [XmlElement("mordent", typeof(mordent))]
        public mordent Mordent { get; set; }



        [XmlElement("other-ornament", typeof(placementtext))]
        public placementtext OtherOrnaments { get; set; }



        [XmlElement("schleifer", typeof(Emptyplacement))]
        public Emptyplacement Schleifer { get; set; }



        [XmlElement("shake", typeof(emptytrillsound))]
        public emptytrillsound Shake { get; set; }



        [XmlElement("tremolo", typeof(tremolo))]
        public tremolo Tremolo { get; set; }



        [XmlElement("trill-mark", typeof(emptytrillsound))]
        public emptytrillsound TrillMark { get; set; }



        [XmlElement("turn", typeof(horizontalturn))]
        public horizontalturn Turn { get; set; }



        [XmlElement("vertical-turn", typeof(emptytrillsound))]
        public emptytrillsound VerticalTurn { get; set; }



        [XmlElement("wavy-line", typeof(wavyline))]
        public wavyline WavyLine { get; set; }



        [XmlElement("accidental-mark")]
        public accidentalmark[] AccidentalMark { get; set; }
    }
}