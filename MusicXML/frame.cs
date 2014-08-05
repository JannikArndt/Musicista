using MusicXML.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class frame
    {
        private string colorField;
        private decimal defaultxField;

        private bool defaultxFieldSpecified;

        private decimal defaultyField;

        private bool defaultyFieldSpecified;
        private firstfret firstfretField;
        private string framefretsField;
        private framenote[] framenoteField;
        private string framestringsField;
        private leftcenterright halignField;

        private bool halignFieldSpecified;
        private decimal heightField;

        private bool heightFieldSpecified;

        private decimal relativexField;

        private bool relativexFieldSpecified;

        private decimal relativeyField;

        private bool relativeyFieldSpecified;
        private string unplayedField;

        private valignimage valignField;

        private bool valignFieldSpecified;

        private decimal widthField;

        private bool widthFieldSpecified;


        [XmlElement("frame-strings", DataType = "positiveInteger")]
        public string framestrings
        {
            get { return framestringsField; }
            set { framestringsField = value; }
        }


        [XmlElement("frame-frets", DataType = "positiveInteger")]
        public string framefrets
        {
            get { return framefretsField; }
            set { framefretsField = value; }
        }


        [XmlElement("first-fret")]
        public firstfret firstfret
        {
            get { return firstfretField; }
            set { firstfretField = value; }
        }


        [XmlElement("frame-note")]
        public framenote[] framenote
        {
            get { return framenoteField; }
            set { framenoteField = value; }
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


        [XmlAttribute(DataType = "token")]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }


        [XmlAttribute]
        public leftcenterright halign
        {
            get { return halignField; }
            set { halignField = value; }
        }


        [XmlIgnore]
        public bool halignSpecified
        {
            get { return halignFieldSpecified; }
            set { halignFieldSpecified = value; }
        }


        [XmlAttribute]
        public valignimage valign
        {
            get { return valignField; }
            set { valignField = value; }
        }


        [XmlIgnore]
        public bool valignSpecified
        {
            get { return valignFieldSpecified; }
            set { valignFieldSpecified = value; }
        }


        [XmlAttribute]
        public decimal height
        {
            get { return heightField; }
            set { heightField = value; }
        }


        [XmlIgnore]
        public bool heightSpecified
        {
            get { return heightFieldSpecified; }
            set { heightFieldSpecified = value; }
        }


        [XmlAttribute]
        public decimal width
        {
            get { return widthField; }
            set { widthField = value; }
        }


        [XmlIgnore]
        public bool widthSpecified
        {
            get { return widthFieldSpecified; }
            set { widthFieldSpecified = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string unplayed
        {
            get { return unplayedField; }
            set { unplayedField = value; }
        }
    }
}