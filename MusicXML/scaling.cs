using System;

using System.ComponentModel;
using System.Diagnostics;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class scaling
    {
        private decimal millimetersField;

        private decimal tenthsField;


        public decimal millimeters
        {
            get { return millimetersField; }
            set { millimetersField = value; }
        }


        public decimal tenths
        {
            get { return tenthsField; }
            set { tenthsField = value; }
        }
    }
}