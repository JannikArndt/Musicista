using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "harp-pedals")]
    public class harppedals
    {
        private pedaltuning[] pedaltuningField;


        [XmlElement("pedal-tuning")]
        public pedaltuning[] pedaltuning
        {
            get { return pedaltuningField; }
            set { pedaltuningField = value; }
        }
    }
}