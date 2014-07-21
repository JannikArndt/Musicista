using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "Note")]
    public class Note
    {
        public override string ToString()
        {
            var result = IsRest ? "Rest for " + Duration : "Note " + Pitch.Step + Pitch.Alter + Pitch.Octave + " for " + Duration;
            if (IsTied) result += ", Tied = " + Tie.Type;
            if (IsChord) result += ", Chord = " + Chord;
            if (IsCue) result += ", Cue = " + Cue;
            if (IsGrace) result += ", Grace = true";
            return result;
        }


        [XmlElement("duration")]
        public decimal Duration { get; set; }

        [XmlElement("pitch")]
        public Pitch Pitch { get; set; }

        // Rests
        [XmlElement("rest", IsNullable = true)]
        public rest Rest { get; set; }

        [XmlIgnore]
        public bool IsRest { get { return Rest != null; } }

        // Chords
        [XmlElement("chord", IsNullable = true)]
        public string Chord { get; set; }

        [XmlIgnore]
        public bool IsChord { get { return Chord != null; } }


        [XmlElement("cue", IsNullable = true)]
        public string Cue { get; set; }

        [XmlIgnore]
        public bool IsCue { get { return Cue != null; } }


        [XmlElement("grace", IsNullable = true)]
        public grace Grace { get; set; }

        [XmlIgnore]
        public bool IsGrace { get { return Grace != null; } }


        [XmlElement("tie", IsNullable = true)]
        public Tie Tie { get; set; }

        [XmlIgnore]
        public bool IsTied { get { return Tie != null; } }


        [XmlElement("unpitched", IsNullable = true)]
        public unpitched Unpitched { get; set; }

        [XmlIgnore]
        public bool IsUnpitched { get { return Unpitched != null; } }


        public instrument instrument { get; set; }


        public formattedtext footnote { get; set; }


        public level level { get; set; }


        public string voice { get; set; }


        public notetype type { get; set; }


        [XmlElement("dot")]
        public emptyplacement[] dot { get; set; }


        public accidental accidental { get; set; }


        [XmlElement("time-modification")]
        public timemodification timemodification { get; set; }


        public stem stem { get; set; }


        public notehead notehead { get; set; }


        [XmlElement("notehead-text")]
        public noteheadtext noteheadtext { get; set; }


        [XmlElement(DataType = "positiveInteger")]
        public string staff { get; set; }


        [XmlElement("beam")]
        public beam[] beam { get; set; }


        [XmlElement("notations")]
        public notations[] notations { get; set; }


        [XmlElement("lyric")]
        public Lyric[] Lyric { get; set; }


        public play play { get; set; }


        [XmlAttribute("default-x")]
        public decimal defaultx { get; set; }


        [XmlIgnore]
        public bool defaultxSpecified { get; set; }


        [XmlAttribute("default-y")]
        public decimal defaulty { get; set; }


        [XmlIgnore]
        public bool defaultySpecified { get; set; }


        [XmlAttribute("relative-x")]
        public decimal relativex { get; set; }


        [XmlIgnore]
        public bool relativexSpecified { get; set; }


        [XmlAttribute("relative-y")]
        public decimal relativey { get; set; }


        [XmlIgnore]
        public bool relativeySpecified { get; set; }


        [XmlAttribute("font-family", DataType = "token")]
        public string fontfamily { get; set; }


        [XmlAttribute("font-style")]
        public fontstyle fontstyle { get; set; }


        [XmlIgnore]
        public bool fontstyleSpecified { get; set; }


        [XmlAttribute("font-size")]
        public string fontsize { get; set; }


        [XmlAttribute("font-weight")]
        public fontweight fontweight { get; set; }


        [XmlIgnore]
        public bool fontweightSpecified { get; set; }


        [XmlAttribute(DataType = "token")]
        public string color { get; set; }


        [XmlAttribute("print-dot")]
        public yesno printdot { get; set; }


        [XmlIgnore]
        public bool printdotSpecified { get; set; }


        [XmlAttribute("print-lyric")]
        public yesno printlyric { get; set; }


        [XmlIgnore]
        public bool printlyricSpecified { get; set; }


        [XmlAttribute]
        public decimal dynamics { get; set; }


        [XmlIgnore]
        public bool dynamicsSpecified { get; set; }


        [XmlAttribute("end-dynamics")]
        public decimal enddynamics { get; set; }


        [XmlIgnore]
        public bool enddynamicsSpecified { get; set; }


        [XmlAttribute]
        public decimal attack { get; set; }


        [XmlIgnore]
        public bool attackSpecified { get; set; }


        [XmlAttribute]
        public decimal release { get; set; }


        [XmlIgnore]
        public bool releaseSpecified { get; set; }


        [XmlAttribute("time-only", DataType = "token")]
        public string timeonly { get; set; }


        [XmlAttribute]
        public yesno pizzicato { get; set; }


        [XmlIgnore]
        public bool pizzicatoSpecified { get; set; }
    }
}