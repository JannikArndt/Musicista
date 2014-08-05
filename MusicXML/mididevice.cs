using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "midi-device")]
    public class mididevice
    {
        private string idField;
        private string portField;

        private string valueField;


        [XmlAttribute(DataType = "positiveInteger")]
        public string port
        {
            get { return portField; }
            set { portField = value; }
        }


        [XmlAttribute(DataType = "IDREF")]
        public string id
        {
            get { return idField; }
            set { idField = value; }
        }


        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}