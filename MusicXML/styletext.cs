using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "style-text")]
    public class styletext
    {
        private string valueField;


        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}