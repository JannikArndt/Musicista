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
    public class arpeggiate
    {
        private string colorField;
        private decimal defaultxField;

        private bool defaultxFieldSpecified;

        private decimal defaultyField;

        private bool defaultyFieldSpecified;
        private updown directionField;

        private bool directionFieldSpecified;
        private string numberField;
        private abovebelow placementField;

        private bool placementFieldSpecified;

        private decimal relativexField;

        private bool relativexFieldSpecified;

        private decimal relativeyField;

        private bool relativeyFieldSpecified;


        [XmlAttribute(DataType = "positiveInteger")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }


        [XmlAttribute]
        public updown direction
        {
            get { return directionField; }
            set { directionField = value; }
        }


        [XmlIgnore]
        public bool directionSpecified
        {
            get { return directionFieldSpecified; }
            set { directionFieldSpecified = value; }
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
    }
}