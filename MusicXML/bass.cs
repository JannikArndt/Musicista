using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class bass
    {
        private bassalter bassalterField;
        private bassstep bassstepField;


        [XmlElement("bass-step")]
        public bassstep bassstep
        {
            get { return bassstepField; }
            set { bassstepField = value; }
        }


        [XmlElement("bass-alter")]
        public bassalter bassalter
        {
            get { return bassalterField; }
            set { bassalterField = value; }
        }
    }
}