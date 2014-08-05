using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "system-margins")]
    public class systemmargins
    {
        private decimal leftmarginField;

        private decimal rightmarginField;


        [XmlElement("left-margin")]
        public decimal leftmargin
        {
            get { return leftmarginField; }
            set { leftmarginField = value; }
        }


        [XmlElement("right-margin")]
        public decimal rightmargin
        {
            get { return rightmarginField; }
            set { rightmarginField = value; }
        }
    }
}