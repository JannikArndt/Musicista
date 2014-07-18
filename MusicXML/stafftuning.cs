using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "staff-tuning")]
    public class stafftuning
    {
        private string lineField;
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


        [XmlAttribute(DataType = "integer")]
        public string line
        {
            get { return lineField; }
            set { lineField = value; }
        }
    }
}