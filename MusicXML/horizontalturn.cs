using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "horizontal-turn")]
    public class horizontalturn
    {
        private yesno accelerateField;

        private bool accelerateFieldSpecified;

        private decimal beatsField;

        private bool beatsFieldSpecified;

        private decimal lastbeatField;

        private bool lastbeatFieldSpecified;
        private abovebelow placementField;

        private bool placementFieldSpecified;
        private decimal secondbeatField;

        private bool secondbeatFieldSpecified;

        private yesno slashField;

        private bool slashFieldSpecified;
        private startnote startnoteField;

        private bool startnoteFieldSpecified;

        private trillstep trillstepField;

        private bool trillstepFieldSpecified;

        private twonoteturn twonoteturnField;

        private bool twonoteturnFieldSpecified;


        [XmlAttribute]
        public abovebelow placement
        {
            get { return placementField; }
            set { placementField = value; }
        }


        [XmlIgnore]
        public bool placementSpecified
        {
            get { return placementFieldSpecified; }
            set { placementFieldSpecified = value; }
        }


        [XmlAttribute("start-note")]
        public startnote startnote
        {
            get { return startnoteField; }
            set { startnoteField = value; }
        }


        [XmlIgnore]
        public bool startnoteSpecified
        {
            get { return startnoteFieldSpecified; }
            set { startnoteFieldSpecified = value; }
        }


        [XmlAttribute("trill-step")]
        public trillstep trillstep
        {
            get { return trillstepField; }
            set { trillstepField = value; }
        }


        [XmlIgnore]
        public bool trillstepSpecified
        {
            get { return trillstepFieldSpecified; }
            set { trillstepFieldSpecified = value; }
        }


        [XmlAttribute("two-note-turn")]
        public twonoteturn twonoteturn
        {
            get { return twonoteturnField; }
            set { twonoteturnField = value; }
        }


        [XmlIgnore]
        public bool twonoteturnSpecified
        {
            get { return twonoteturnFieldSpecified; }
            set { twonoteturnFieldSpecified = value; }
        }


        [XmlAttribute]
        public yesno accelerate
        {
            get { return accelerateField; }
            set { accelerateField = value; }
        }


        [XmlIgnore]
        public bool accelerateSpecified
        {
            get { return accelerateFieldSpecified; }
            set { accelerateFieldSpecified = value; }
        }


        [XmlAttribute]
        public decimal beats
        {
            get { return beatsField; }
            set { beatsField = value; }
        }


        [XmlIgnore]
        public bool beatsSpecified
        {
            get { return beatsFieldSpecified; }
            set { beatsFieldSpecified = value; }
        }


        [XmlAttribute("second-beat")]
        public decimal secondbeat
        {
            get { return secondbeatField; }
            set { secondbeatField = value; }
        }


        [XmlIgnore]
        public bool secondbeatSpecified
        {
            get { return secondbeatFieldSpecified; }
            set { secondbeatFieldSpecified = value; }
        }


        [XmlAttribute("last-beat")]
        public decimal lastbeat
        {
            get { return lastbeatField; }
            set { lastbeatField = value; }
        }


        [XmlIgnore]
        public bool lastbeatSpecified
        {
            get { return lastbeatFieldSpecified; }
            set { lastbeatFieldSpecified = value; }
        }


        [XmlAttribute]
        public yesno slash
        {
            get { return slashField; }
            set { slashField = value; }
        }


        [XmlIgnore]
        public bool slashSpecified
        {
            get { return slashFieldSpecified; }
            set { slashFieldSpecified = value; }
        }
    }
}