using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "other-play")]
    public class otherplay
    {
        private string typeField;

        private string valueField;


        [XmlAttribute(DataType = "token")]
        public string type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}