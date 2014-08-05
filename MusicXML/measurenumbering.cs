using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "measure-numbering")]
    public class measurenumbering
    {
        private measurenumberingvalue valueField;


        [XmlText]
        public measurenumberingvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}