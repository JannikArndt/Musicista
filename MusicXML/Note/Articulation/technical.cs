using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note.Articulation
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class Technical
    {
        [XmlElement("arrow", typeof(arrow))]
        public arrow Arrow { get; set; }


        [XmlElement("bend", typeof(bend))]
        public bend Bend { get; set; }


        [XmlElement("double-tongue", typeof(Emptyplacement))]
        public Emptyplacement DoubleTongue { get; set; }


        [XmlElement("down-bow", typeof(Emptyplacement))]
        public Emptyplacement DownBow { get; set; }


        [XmlElement("fingering", typeof(fingering))]
        public fingering Fingering { get; set; }


        [XmlElement("fingernails", typeof(Emptyplacement))]
        public Emptyplacement Fingernails { get; set; }


        [XmlElement("fret", typeof(fret))]
        public fret Fret { get; set; }


        [XmlElement("hammer-on", typeof(hammeronpulloff))]
        public hammeronpulloff HammerOn { get; set; }


        [XmlElement("handbell", typeof(handbell))]
        public handbell Handbell { get; set; }


        [XmlElement("harmonic", typeof(harmonic))]
        public harmonic Harmonic { get; set; }


        [XmlElement("heel", typeof(heeltoe))]
        public heeltoe Heeltoe { get; set; }


        [XmlElement("hole", typeof(hole))]
        public hole Hole { get; set; }


        [XmlElement("open-string", typeof(Emptyplacement))]
        public Emptyplacement OpenString { get; set; }


        [XmlElement("other-technical", typeof(placementtext))]
        public placementtext OtherTechnical { get; set; }


        [XmlElement("pluck", typeof(placementtext))]
        public placementtext Pluck { get; set; }


        [XmlElement("pull-off", typeof(hammeronpulloff))]
        public hammeronpulloff PullOff { get; set; }


        [XmlElement("snap-pizzicato", typeof(Emptyplacement))]
        public Emptyplacement SnapPizzicato { get; set; }


        [XmlElement("stopped", typeof(Emptyplacement))]
        public Emptyplacement Stopped { get; set; }


        [XmlElement("string", typeof(@string))]
        public @string @String { get; set; }


        [XmlElement("tap", typeof(placementtext))]
        public placementtext Tap { get; set; }


        [XmlElement("thumb-position", typeof(Emptyplacement))]
        public Emptyplacement ThumbPosition { get; set; }


        [XmlElement("toe", typeof(heeltoe))]
        public heeltoe Toe { get; set; }


        [XmlElement("triple-tongue", typeof(Emptyplacement))]
        public Emptyplacement TripleTongue { get; set; }


        [XmlElement("up-bow", typeof(Emptyplacement))]
        public Emptyplacement UpBow { get; set; }
    }
}