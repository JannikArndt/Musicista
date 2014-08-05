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
    public class wedge
    {
        private string colorField;
        private decimal dashlengthField;

        private bool dashlengthFieldSpecified;

        private decimal defaultxField;

        private bool defaultxFieldSpecified;

        private decimal defaultyField;

        private bool defaultyFieldSpecified;
        private linetype linetypeField;

        private bool linetypeFieldSpecified;
        private yesno nienteField;

        private bool nienteFieldSpecified;
        private string numberField;

        private decimal relativexField;

        private bool relativexFieldSpecified;

        private decimal relativeyField;

        private bool relativeyFieldSpecified;
        private decimal spacelengthField;

        private bool spacelengthFieldSpecified;
        private decimal spreadField;

        private bool spreadFieldSpecified;
        private wedgetype typeField;


        [XmlAttribute]
        public wedgetype type
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
        public decimal spread
        {
            get { return spreadField; }
            set { spreadField = value; }
        }


        [XmlIgnore]
        public bool spreadSpecified
        {
            get { return spreadFieldSpecified; }
            set { spreadFieldSpecified = value; }
        }


        [XmlAttribute]
        public yesno niente
        {
            get { return nienteField; }
            set { nienteField = value; }
        }


        [XmlIgnore]
        public bool nienteSpecified
        {
            get { return nienteFieldSpecified; }
            set { nienteFieldSpecified = value; }
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


        [XmlAttribute(DataType = "token")]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }
    }
}