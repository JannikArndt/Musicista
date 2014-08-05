using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "measure-style")]
    public class measurestyle
    {
        private string colorField;
        private string fontfamilyField;
        private string fontsizeField;

        private fontstyle fontstyleField;

        private bool fontstyleFieldSpecified;

        private fontweight fontweightField;

        private bool fontweightFieldSpecified;
        private object itemField;

        private string numberField;


        [XmlElement("beat-repeat", typeof (beatrepeat))]
        [XmlElement("measure-repeat", typeof (measurerepeat))]
        [XmlElement("multiple-rest", typeof (multiplerest))]
        [XmlElement("slash", typeof (slash))]
        public object Item
        {
            get { return itemField; }
            set { itemField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
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
    }
}