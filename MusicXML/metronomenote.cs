using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "metronome-note")]
    public class metronomenote
    {
        private metronomebeam[] metronomebeamField;
        private empty[] metronomedotField;

        private metronometuplet metronometupletField;
        private notetypevalue metronometypeField;


        [XmlElement("metronome-type")]
        public notetypevalue metronometype
        {
            get { return metronometypeField; }
            set { metronometypeField = value; }
        }


        [XmlElement("metronome-dot")]
        public empty[] metronomedot
        {
            get { return metronomedotField; }
            set { metronomedotField = value; }
        }


        [XmlElement("metronome-beam")]
        public metronomebeam[] metronomebeam
        {
            get { return metronomebeamField; }
            set { metronomebeamField = value; }
        }


        [XmlElement("metronome-tuplet")]
        public metronometuplet metronometuplet
        {
            get { return metronometupletField; }
            set { metronometupletField = value; }
        }
    }
}