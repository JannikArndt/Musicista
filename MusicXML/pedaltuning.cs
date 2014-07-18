using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "pedal-tuning")]
    public class pedaltuning
    {
        private decimal pedalalterField;
        private Step pedalstepField;


        [XmlElement("pedal-step")]
        public Step pedalstep
        {
            get { return pedalstepField; }
            set { pedalstepField = value; }
        }


        [XmlElement("pedal-alter")]
        public decimal pedalalter
        {
            get { return pedalalterField; }
            set { pedalalterField = value; }
        }
    }
}