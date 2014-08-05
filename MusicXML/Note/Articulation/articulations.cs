using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note.Articulation
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class Articulations
    {
        [XmlElement("accent", typeof(Emptyplacement))]
        public Emptyplacement Accent { get; set; }


        [XmlElement("breath-mark", typeof(breathmark))]
        public breathmark BreathMark { get; set; }


        [XmlElement("caesura", typeof(Emptyplacement))]
        public Emptyplacement Caesura { get; set; }


        [XmlElement("detached-legato", typeof(Emptyplacement))]
        public Emptyplacement DetachedLegato { get; set; }


        [XmlElement("doit", typeof(emptyline))]
        public emptyline Doit { get; set; }


        [XmlElement("falloff", typeof(emptyline))]
        public emptyline Falloff { get; set; }


        [XmlElement("other-articulation", typeof(placementtext))]
        public placementtext OtherArticulation { get; set; }


        [XmlElement("plop", typeof(emptyline))]
        public emptyline Plop { get; set; }


        [XmlElement("scoop", typeof(emptyline))]
        public emptyline Scoop { get; set; }


        [XmlElement("spiccato", typeof(Emptyplacement))]
        public Emptyplacement Spiccato { get; set; }


        [XmlElement("staccatissimo", typeof(Emptyplacement))]
        public Emptyplacement Staccatissimo { get; set; }


        [XmlElement("staccato", typeof(Emptyplacement))]
        public Emptyplacement Staccato { get; set; }


        [XmlElement("stress", typeof(Emptyplacement))]
        public Emptyplacement Stress { get; set; }


        [XmlElement("strong-accent", typeof(strongaccent))]
        public strongaccent StrongAccent { get; set; }


        [XmlElement("tenuto", typeof(Emptyplacement))]
        public Emptyplacement Tenuto { get; set; }


        [XmlElement("unstress", typeof(Emptyplacement))]
        public Emptyplacement Unstress { get; set; }

    }
}