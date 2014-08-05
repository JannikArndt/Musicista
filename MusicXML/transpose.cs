using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class transpose
    {
        private decimal chromaticField;
        private string diatonicField;

        private empty doubleField;

        private string numberField;
        private string octavechangeField;


        [XmlElement(DataType = "integer")]
        public string diatonic
        {
            get { return diatonicField; }
            set { diatonicField = value; }
        }


        public decimal chromatic
        {
            get { return chromaticField; }
            set { chromaticField = value; }
        }


        [XmlElement("octave-change", DataType = "integer")]
        public string octavechange
        {
            get { return octavechangeField; }
            set { octavechangeField = value; }
        }


        public empty @double
        {
            get { return doubleField; }
            set { doubleField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }
    }
}