using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class scordatura
    {
        private accord[] accordField;


        [XmlElement("accord")]
        public accord[] accord
        {
            get { return accordField; }
            set { accordField = value; }
        }
    }
}