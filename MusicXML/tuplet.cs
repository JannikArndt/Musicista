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
    public class tuplet
    {
        private yesno bracketField;

        private bool bracketFieldSpecified;

        private decimal defaultxField;

        private bool defaultxFieldSpecified;

        private decimal defaultyField;

        private bool defaultyFieldSpecified;
        private lineshape lineshapeField;

        private bool lineshapeFieldSpecified;
        private string numberField;
        private abovebelow placementField;

        private bool placementFieldSpecified;

        private decimal relativexField;

        private bool relativexFieldSpecified;

        private decimal relativeyField;

        private bool relativeyFieldSpecified;
        private showtuplet shownumberField;

        private bool shownumberFieldSpecified;

        private showtuplet showtypeField;

        private bool showtypeFieldSpecified;
        private tupletportion tupletactualField;

        private tupletportion tupletnormalField;

        private startstop typeField;


        [XmlElement("tuplet-actual")]
        public tupletportion tupletactual
        {
            get { return tupletactualField; }
            set { tupletactualField = value; }
        }


        [XmlElement("tuplet-normal")]
        public tupletportion tupletnormal
        {
            get { return tupletnormalField; }
            set { tupletnormalField = value; }
        }


        [XmlAttribute]
        public startstop type
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


        [XmlAttribute]
        public yesno bracket
        {
            get { return bracketField; }
            set { bracketField = value; }
        }


        [XmlIgnore]
        public bool bracketSpecified
        {
            get { return bracketFieldSpecified; }
            set { bracketFieldSpecified = value; }
        }


        [XmlAttribute("show-number")]
        public showtuplet shownumber
        {
            get { return shownumberField; }
            set { shownumberField = value; }
        }


        [XmlIgnore]
        public bool shownumberSpecified
        {
            get { return shownumberFieldSpecified; }
            set { shownumberFieldSpecified = value; }
        }


        [XmlAttribute("show-type")]
        public showtuplet showtype
        {
            get { return showtypeField; }
            set { showtypeField = value; }
        }


        [XmlIgnore]
        public bool showtypeSpecified
        {
            get { return showtypeFieldSpecified; }
            set { showtypeFieldSpecified = value; }
        }


        [XmlAttribute("line-shape")]
        public lineshape lineshape
        {
            get { return lineshapeField; }
            set { lineshapeField = value; }
        }


        [XmlIgnore]
        public bool lineshapeSpecified
        {
            get { return lineshapeFieldSpecified; }
            set { lineshapeFieldSpecified = value; }
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
    }
}