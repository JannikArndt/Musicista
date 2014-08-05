using System;

using System.ComponentModel;
using System.Diagnostics;

namespace MusicXML.Note
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class backup
    {
        private decimal durationField;

        private formattedtext footnoteField;

        private level levelField;


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
    }
}