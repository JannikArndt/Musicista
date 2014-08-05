using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "frame-note")]
    public class framenote
    {
        private barre barreField;
        private fingering fingeringField;
        private fret fretField;
        private @string stringField;


        public @string @string
        {
            get { return stringField; }
            set { stringField = value; }
        }


        public fret fret
        {
            get { return fretField; }
            set { fretField = value; }
        }


        public fingering fingering
        {
            get { return fingeringField; }
            set { fingeringField = value; }
        }


        public barre barre
        {
            get { return barreField; }
            set { barreField = value; }
        }
    }
}