using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [XmlInclude(typeof (metronometuplet))]
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "time-modification")]
    public class timemodification
    {
        private string actualnotesField;
        private empty[] normaldotField;

        private string normalnotesField;

        private notetypevalue normaltypeField;


        [XmlElement("actual-notes", DataType = "nonNegativeInteger")]
        public string actualnotes
        {
            get { return actualnotesField; }
            set { actualnotesField = value; }
        }


        [XmlElement("normal-notes", DataType = "nonNegativeInteger")]
        public string normalnotes
        {
            get { return normalnotesField; }
            set { normalnotesField = value; }
        }


        [XmlElement("normal-type")]
        public notetypevalue normaltype
        {
            get { return normaltypeField; }
            set { normaltypeField = value; }
        }


        [XmlElement("normal-dot")]
        public empty[] normaldot
        {
            get { return normaldotField; }
            set { normaldotField = value; }
        }
    }
}