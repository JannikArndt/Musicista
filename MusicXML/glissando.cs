using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class glissando
    {
        private decimal dashlengthField;

        private bool dashlengthFieldSpecified;
        private linetype linetypeField;

        private bool linetypeFieldSpecified;
        private string numberField;

        private decimal spacelengthField;

        private bool spacelengthFieldSpecified;
        private startstop typeField;

        private string valueField;

        public glissando()
        {
            numberField = "1";
        }


        [XmlAttribute]
        public startstop type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        [DefaultValue("1")]
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


        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}