using Model.Meta;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Model
{
    public class MeasureGroup
    {
        public MeasureGroup()
        {
            Measures = new List<Measure>();
        }
        [XmlAttribute("MeasureNumber")]
        public int MeasureNumber { get; set; }
        public TimeSignature TimeSignature { get; set; }
        public MusicalKey KeySignature { get; set; }
        public List<Measure> Measures { get; set; }
        [XmlIgnore]
        public Passage ParentPassage { get; set; }
        [XmlAttribute, DefaultValue(false)]
        public bool IsPickupMeasure { get; set; }

        [XmlIgnore]
        public MeasureGroup Previous
        {
            get
            {
                if (ParentPassage != null && ParentPassage.ListOfMeasureGroups.IndexOf(this) > 0)
                    return ParentPassage.ListOfMeasureGroups[ParentPassage.ListOfMeasureGroups.IndexOf(this) - 1];
                return null;
            }
        }

        [XmlIgnore]
        public MeasureGroup Next
        {
            get
            {
                if (ParentPassage != null && ParentPassage.ListOfMeasureGroups.IndexOf(this) > -1 && ParentPassage.ListOfMeasureGroups.IndexOf(this) < ParentPassage.ListOfMeasureGroups.Count - 1)
                    return ParentPassage.ListOfMeasureGroups[ParentPassage.ListOfMeasureGroups.IndexOf(this) + 1];
                return null;
            }
        }

        [XmlIgnore]
        public int HoldsDuration
        {
            get { return (int)(TimeSignature.Beats * ((double)Duration.whole / TimeSignature.BeatUnit)); }
        }
    }
}
