using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class barre
    {
        private string colorField;
        private startstop typeField;


        [XmlAttribute]
        public startstop type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }
    }
}