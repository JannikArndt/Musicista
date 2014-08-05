using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class forward
    {
        private decimal durationField;

        private formattedtext footnoteField;

        private level levelField;

        private string staffField;
        private string voiceField;


        public decimal duration
        {
            get { return durationField; }
            set { durationField = value; }
        }


        public formattedtext footnote
        {
            get { return footnoteField; }
            set { footnoteField = value; }
        }


        public level level
        {
            get { return levelField; }
            set { levelField = value; }
        }


        public string voice
        {
            get { return voiceField; }
            set { voiceField = value; }
        }


        [XmlElement(DataType = "positiveInteger")]
        public string staff
        {
            get { return staffField; }
            set { staffField = value; }
        }
    }
}