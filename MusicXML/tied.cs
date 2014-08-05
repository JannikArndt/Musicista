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
    public class tied
    {
        private decimal bezieroffset2Field;

        private bool bezieroffset2FieldSpecified;
        private decimal bezieroffsetField;

        private bool bezieroffsetFieldSpecified;
        private decimal bezierx2Field;

        private bool bezierx2FieldSpecified;
        private decimal bezierxField;

        private bool bezierxFieldSpecified;
        private decimal beziery2Field;

        private bool beziery2FieldSpecified;
        private decimal bezieryField;

        private bool bezieryFieldSpecified;
        private string colorField;
        private decimal dashlengthField;

        private bool dashlengthFieldSpecified;

        private decimal defaultxField;

        private bool defaultxFieldSpecified;

        private decimal defaultyField;

        private bool defaultyFieldSpecified;
        private linetype linetypeField;

        private bool linetypeFieldSpecified;
        private string numberField;
        private overunder orientationField;

        private bool orientationFieldSpecified;
        private abovebelow placementField;

        private bool placementFieldSpecified;

        private decimal relativexField;

        private bool relativexFieldSpecified;

        private decimal relativeyField;

        private bool relativeyFieldSpecified;
        private decimal spacelengthField;

        private bool spacelengthFieldSpecified;
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


        [XmlAttribute("line-type")]
        public linetype linetype
        {
            get { return linetypeField; }
            set { linetypeField = value; }
        }


        [XmlIgnore]
        public bool linetypeSpecified
        {
            get { return linetypeFieldSpecified; }
            set { linetypeFieldSpecified = value; }
        }


        [XmlAttribute("dash-length")]
        public decimal dashlength
        {
            get { return dashlengthField; }
            set { dashlengthField = value; }
        }


        [XmlIgnore]
        public bool dashlengthSpecified
        {
            get { return dashlengthFieldSpecified; }
            set { dashlengthFieldSpecified = value; }
        }


        [XmlAttribute("space-length")]
        public decimal spacelength
        {
            get { return spacelengthField; }
            set { spacelengthField = value; }
        }


        [XmlIgnore]
        public bool spacelengthSpecified
        {
            get { return spacelengthFieldSpecified; }
            set { spacelengthFieldSpecified = value; }
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


        [XmlAttribute]
        public overunder orientation
        {
            get { return orientationField; }
            set { orientationField = value; }
        }


        [XmlIgnore]
        public bool orientationSpecified
        {
            get { return orientationFieldSpecified; }
            set { orientationFieldSpecified = value; }
        }


        [XmlAttribute("bezier-offset")]
        public decimal bezieroffset
        {
            get { return bezieroffsetField; }
            set { bezieroffsetField = value; }
        }


        [XmlIgnore]
        public bool bezieroffsetSpecified
        {
            get { return bezieroffsetFieldSpecified; }
            set { bezieroffsetFieldSpecified = value; }
        }


        [XmlAttribute("bezier-offset2")]
        public decimal bezieroffset2
        {
            get { return bezieroffset2Field; }
            set { bezieroffset2Field = value; }
        }


        [XmlIgnore]
        public bool bezieroffset2Specified
        {
            get { return bezieroffset2FieldSpecified; }
            set { bezieroffset2FieldSpecified = value; }
        }


        [XmlAttribute("bezier-x")]
        public decimal bezierx
        {
            get { return bezierxField; }
            set { bezierxField = value; }
        }


        [XmlIgnore]
        public bool bezierxSpecified
        {
            get { return bezierxFieldSpecified; }
            set { bezierxFieldSpecified = value; }
        }


        [XmlAttribute("bezier-y")]
        public decimal beziery
        {
            get { return bezieryField; }
            set { bezieryField = value; }
        }


        [XmlIgnore]
        public bool bezierySpecified
        {
            get { return bezieryFieldSpecified; }
            set { bezieryFieldSpecified = value; }
        }


        [XmlAttribute("bezier-x2")]
        public decimal bezierx2
        {
            get { return bezierx2Field; }
            set { bezierx2Field = value; }
        }


        [XmlIgnore]
        public bool bezierx2Specified
        {
            get { return bezierx2FieldSpecified; }
            set { bezierx2FieldSpecified = value; }
        }


        [XmlAttribute("bezier-y2")]
        public decimal beziery2
        {
            get { return beziery2Field; }
            set { beziery2Field = value; }
        }


        [XmlIgnore]
        public bool beziery2Specified
        {
            get { return beziery2FieldSpecified; }
            set { beziery2FieldSpecified = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }
    }
}