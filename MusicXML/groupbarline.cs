using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "group-barline")]
    public class groupbarline
    {
        private string colorField;

        private groupbarlinevalue valueField;


        [XmlAttribute(DataType = "token")]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }


        [XmlText]
        public groupbarlinevalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}