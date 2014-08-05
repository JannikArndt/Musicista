
using System.Xml.Serialization;

namespace Model.Sections.Notes.Articulation
{
    public class Articulation
    {
        [XmlAttribute("Accent")]
        public Accent Accent { get; set; }
        public bool AccentSpecified { get { return Accent != Accent.None; } }

        [XmlAttribute("Arpeggiate")]
        public bool Arpeggiate { get; set; }
        public bool ArpeggiateSpecified { get { return Arpeggiate; } }

        [XmlAttribute("Caesura")]
        public bool Caesura { get; set; }
        public bool CaesuraSpecified { get { return Caesura; } }


        [XmlAttribute("Damping")]
        public bool Damping { get; set; }
        public bool DampingSpecified { get { return Damping; } }


        [XmlAttribute("Dynamics")]
        public Dynamics Dynamics { get; set; }
        public bool DynamicsSpecified { get { return Dynamics != Dynamics.None; } }


        [XmlAttribute("Fermata")]
        public bool Fermata { get; set; }
        public bool FermataSpecified { get { return Fermata; } }


        [XmlAttribute("Legato")]
        public bool Legato { get; set; }
        public bool LegatoSpecified { get { return Legato; } }


        [XmlAttribute("Bowing")]
        public Bowing Bowing { get; set; }
        public bool BowingSpecified { get { return Bowing != Bowing.None; } }


        [XmlAttribute("Portato")]
        public bool Portato { get; set; }
        public bool PortatoSpecified { get { return Portato; } }

        [XmlAttribute("Sliding")]
        public Sliding Sliding { get; set; }
        public bool SlidingSpecified { get { return Sliding != Sliding.None; } }

        [XmlAttribute("Slur")]
        public Slur Slur { get; set; }
        public bool SlurSpecified { get { return Slur != Slur.None; } }

        [XmlAttribute("Trill")]
        public bool Trill { get; set; }
        public bool TrillSpecified { get { return Trill; } }

        [XmlAttribute("Tremolo")]
        public bool Tremolo { get; set; }
        public bool TremoloSpecified { get { return Tremolo; } }


        [XmlAttribute("Ornament")]
        public Ornament Ornament { get; set; }
        public bool OrnamentSpecified { get { return Ornament != Ornament.None; } }


        [XmlText]
        public string Other { get; set; }
        public bool ShouldSerializeOther() { return !string.IsNullOrEmpty(Other); }


        public bool ShouldSerialize
        {
            get
            {
                return Accent != Accent.None || Caesura || Damping || Dynamics != Dynamics.None || Fermata || Legato ||
                    Bowing != Bowing.None || Sliding != Sliding.None || Portato || !string.IsNullOrEmpty(Other);
            }
        }
    }
}
