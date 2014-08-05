﻿
using System.Xml.Serialization;

namespace Model.Sections.Notes.Articulation
{
    public class Articulation
    {
        [XmlAttribute("Accent")]
        public Accent Accent { get; set; }
        public bool ShouldSerializeAccent { get { return Accent != Accent.None; } }


        [XmlAttribute("Caesura")]
        public bool Caesura { get; set; }
        public bool ShouldSerializeCaesura { get { return Caesura; } }


        [XmlAttribute("Damping")]
        public bool Damping { get; set; }
        public bool ShouldSerializeDamping { get { return Damping; } }


        [XmlAttribute("Dynamics")]
        public Dynamics Dynamics { get; set; }
        public bool ShouldSerializeDynamics { get { return Dynamics != Dynamics.None; } }


        [XmlAttribute("Fermata")]
        public bool Fermata { get; set; }
        public bool ShouldSerializeFermata { get { return Fermata; } }


        [XmlAttribute("Legato")]
        public bool Legato { get; set; }
        public bool ShouldSerializeLegato { get { return Legato; } }


        [XmlAttribute("Bowing")]
        public Bowing Bowing { get; set; }
        public bool ShouldSerializeBowing { get { return Bowing != Bowing.None; } }


        [XmlAttribute("Portato")]
        public bool Portato { get; set; }
        public bool ShouldSerializePortato { get { return Portato; } }



        [XmlText]
        public string Other { get; set; }
        public bool ShouldSerializeOther { get { return !string.IsNullOrEmpty(Other); } }


        public bool ShouldSerialize { get { return Accent != Accent.None || Caesura || Damping || Fermata || Legato || Bowing != Bowing.None || Portato || !string.IsNullOrEmpty(Other); } }
    }
}
