using MusicXML.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class notehead
    {
        private string colorField;
        private yesno filledField;

        private bool filledFieldSpecified;

        private string fontfamilyField;
        private string fontsizeField;

        private fontstyle fontstyleField;

        private bool fontstyleFieldSpecified;

        private fontweight fontweightField;

        private bool fontweightFieldSpecified;
        private yesno parenthesesField;

        private bool parenthesesFieldSpecified;

        private noteheadvalue valueField;


        [XmlAttribute]
        public yesno filled
        {
            get { return filledField; }
            set { filledField = value; }
        }


        [XmlIgnore]
        public bool filledSpecified
        {
            get { return filledFieldSpecified; }
            set { filledFieldSpecified = value; }
        }


        [XmlAttribute]
        public yesno parentheses
        {
            get { return parenthesesField; }
            set { parenthesesField = value; }
        }


        [XmlIgnore]
        public bool parenthesesSpecified
        {
            get { return parenthesesFieldSpecified; }
            set { parenthesesFieldSpecified = value; }
        }


        [XmlAttribute("font-family", DataType = "token")]
        public string fontfamily
        {
            get { return fontfamilyField; }
            set { fontfamilyField = value; }
        }


        [XmlAttribute("font-style")]
        public fontstyle fontstyle
        {
            get { return fontstyleField; }
            set { fontstyleField = value; }
        }


        [XmlIgnore]
        public bool fontstyleSpecified
        {
            get { return fontstyleFieldSpecified; }
            set { fontstyleFieldSpecified = value; }
        }


        [XmlAttribute("font-size")]
        public string fontsize
        {
            get { return fontsizeField; }
            set { fontsizeField = value; }
        }


        [XmlAttribute("font-weight")]
        public fontweight fontweight
        {
            get { return fontweightField; }
            set { fontweightField = value; }
        }


        [XmlIgnore]
        public bool fontweightSpecified
        {
            get { return fontweightFieldSpecified; }
            set { fontweightFieldSpecified = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }


        [XmlText]
        public noteheadvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}