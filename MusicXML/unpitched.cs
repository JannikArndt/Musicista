using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class unpitched
    {
        private string displayoctaveField;
        private Step displaystepField;


        [XmlElement("display-step")]
        public Step displaystep
        {
            get { return displaystepField; }
            set { displaystepField = value; }
        }


        [XmlElement("display-octave", DataType = "integer")]
        public string displayoctave
        {
            get { return displayoctaveField; }
            set { displayoctaveField = value; }
        }
    }
}