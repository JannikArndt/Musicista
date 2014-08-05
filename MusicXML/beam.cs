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
    public class beam
    {
        private string colorField;
        private fan fanField;

        private bool fanFieldSpecified;
        private string numberField;

        private yesno repeaterField;

        private bool repeaterFieldSpecified;

        private beamvalue valueField;

        public beam()
        {
            numberField = "1";
        }


        [XmlAttribute(DataType = "positiveInteger")]
        [DefaultValue("1")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }


        [XmlAttribute]
        public yesno repeater
        {
            get { return repeaterField; }
            set { repeaterField = value; }
        }


        [XmlIgnore]
        public bool repeaterSpecified
        {
            get { return repeaterFieldSpecified; }
            set { repeaterFieldSpecified = value; }
        }


        [XmlAttribute]
        public fan fan
        {
            get { return fanField; }
            set { fanField = value; }
        }


        [XmlIgnore]
        public bool fanSpecified
        {
            get { return fanFieldSpecified; }
            set { fanFieldSpecified = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }


        [XmlText]
        public beamvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}