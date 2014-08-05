using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "accordion-registration")]
    public class accordionregistration
    {
        private empty accordionhighField;

        private empty accordionlowField;
        private string accordionmiddleField;


        [XmlElement("accordion-high")]
        public empty accordionhigh
        {
            get { return accordionhighField; }
            set { accordionhighField = value; }
        }


        [XmlElement("accordion-middle", DataType = "positiveInteger")]
        public string accordionmiddle
        {
            get { return accordionmiddleField; }
            set { accordionmiddleField = value; }
        }


        [XmlElement("accordion-low")]
        public empty accordionlow
        {
            get { return accordionlowField; }
            set { accordionlowField = value; }
        }
    }
}