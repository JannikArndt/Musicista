using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "page-margins")]
    public class pagemargins
    {
        private decimal bottommarginField;
        private decimal leftmarginField;

        private decimal rightmarginField;

        private decimal topmarginField;

        private margintype typeField;

        private bool typeFieldSpecified;


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


        [XmlElement("top-margin")]
        public decimal topmargin
        {
            get { return topmarginField; }
            set { topmarginField = value; }
        }


        [XmlElement("bottom-margin")]
        public decimal bottommargin
        {
            get { return bottommarginField; }
            set { bottommarginField = value; }
        }


        [XmlAttribute]
        public margintype type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlIgnore]
        public bool typeSpecified
        {
            get { return typeFieldSpecified; }
            set { typeFieldSpecified = value; }
        }
    }
}