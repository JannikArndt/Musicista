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
    [XmlType(AnonymousType = true)]
    public class ScoretimewiseMeasure
    {
        private yesno implicitField;

        private bool implicitFieldSpecified;

        private yesno noncontrollingField;

        private bool noncontrollingFieldSpecified;
        private string numberField;
        private ScoretimewiseMeasurePart[] partField;

        private decimal widthField;

        private bool widthFieldSpecified;


        [XmlElement("part")]
        public ScoretimewiseMeasurePart[] part
        {
            get { return partField; }
            set { partField = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }


        [XmlAttribute]
        public yesno @implicit
        {
            get { return implicitField; }
            set { implicitField = value; }
        }


        [XmlIgnore]
        public bool implicitSpecified
        {
            get { return implicitFieldSpecified; }
            set { implicitFieldSpecified = value; }
        }


        [XmlAttribute("non-controlling")]
        public yesno noncontrolling
        {
            get { return noncontrollingField; }
            set { noncontrollingField = value; }
        }


        [XmlIgnore]
        public bool noncontrollingSpecified
        {
            get { return noncontrollingFieldSpecified; }
            set { noncontrollingFieldSpecified = value; }
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
    }
}