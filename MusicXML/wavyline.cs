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
    [XmlType(TypeName = "wavy-line")]
    public class wavyline
    {
        private yesno accelerateField;

        private bool accelerateFieldSpecified;

        private decimal beatsField;

        private bool beatsFieldSpecified;
        private string colorField;
        private decimal defaultxField;

        private bool defaultxFieldSpecified;

        private decimal defaultyField;

        private bool defaultyFieldSpecified;
        private decimal lastbeatField;

        private bool lastbeatFieldSpecified;
        private string numberField;
        private abovebelow placementField;

        private bool placementFieldSpecified;

        private decimal relativexField;

        private bool relativexFieldSpecified;

        private decimal relativeyField;

        private bool relativeyFieldSpecified;
        private decimal secondbeatField;

        private bool secondbeatFieldSpecified;

        private startnote startnoteField;

        private bool startnoteFieldSpecified;

        private trillstep trillstepField;

        private bool trillstepFieldSpecified;

        private twonoteturn twonoteturnField;

        private bool twonoteturnFieldSpecified;
        private startstopcontinue typeField;

    
        [XmlAttribute]
        public startstopcontinue type
        {
            get { return typeField; }
            set { typeField = value; }
        }

    
        [XmlAttribute(DataType = "positiveInteger")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }

    
        [XmlAttribute("default-x")]
        public decimal defaultx
        {
            get { return defaultxField; }
            set { defaultxField = value; }
        }

    
        [XmlIgnore]
        public bool defaultxSpecified
        {
            get { return defaultxFieldSpecified; }
            set { defaultxFieldSpecified = value; }
        }

    
        [XmlAttribute("default-y")]
        public decimal defaulty
        {
            get { return defaultyField; }
            set { defaultyField = value; }
        }

    
        [XmlIgnore]
        public bool defaultySpecified
        {
            get { return defaultyFieldSpecified; }
            set { defaultyFieldSpecified = value; }
        }

    
        [XmlAttribute("relative-x")]
        public decimal relativex
        {
            get { return relativexField; }
            set { relativexField = value; }
        }

    
        [XmlIgnore]
        public bool relativexSpecified
        {
            get { return relativexFieldSpecified; }
            set { relativexFieldSpecified = value; }
        }

    
        [XmlAttribute("relative-y")]
        public decimal relativey
        {
            get { return relativeyField; }
            set { relativeyField = value; }
        }

    
        [XmlIgnore]
        public bool relativeySpecified
        {
            get { return relativeyFieldSpecified; }
            set { relativeyFieldSpecified = value; }
        }

    
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

    
        [XmlAttribute(DataType = "token")]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
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
    }
}