using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class inversion
    {
        private string valueField;


        [XmlText(DataType = "nonNegativeInteger")]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}