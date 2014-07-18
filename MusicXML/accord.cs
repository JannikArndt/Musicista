using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class accord
    {
        private string stringField;
        private decimal tuningalterField;

        private bool tuningalterFieldSpecified;

        private string tuningoctaveField;
        private Step tuningstepField;


        [XmlElement("tuning-step")]
        public Step tuningstep
        {
            get { return tuningstepField; }
            set { tuningstepField = value; }
        }


        [XmlElement("tuning-alter")]
        public decimal tuningalter
        {
            get { return tuningalterField; }
            set { tuningalterField = value; }
        }


        [XmlIgnore]
        public bool tuningalterSpecified
        {
            get { return tuningalterFieldSpecified; }
            set { tuningalterFieldSpecified = value; }
        }


        [XmlElement("tuning-octave", DataType = "integer")]
        public string tuningoctave
        {
            get { return tuningoctaveField; }
            set { tuningoctaveField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        public string @string
        {
            get { return stringField; }
            set { stringField = value; }
        }
    }
}