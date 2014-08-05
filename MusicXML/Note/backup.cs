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

        private FormattedText footnoteField;

        private level levelField;


        public decimal duration
        {
            get { return durationField; }
            set { durationField = value; }
        }


        public FormattedText footnote
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