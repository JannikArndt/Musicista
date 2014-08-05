using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "degree-alter")]
    public class degreealter
    {
        private yesno plusminusField;

        private bool plusminusFieldSpecified;

        private decimal valueField;


        [XmlAttribute("plus-minus")]
        public yesno plusminus
        {
            get { return plusminusField; }
            set { plusminusField = value; }
        }


        [XmlIgnore]
        public bool plusminusSpecified
        {
            get { return plusminusFieldSpecified; }
            set { plusminusFieldSpecified = value; }
        }


        [XmlText]
        public decimal Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}