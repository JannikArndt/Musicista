using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MusicXML.Note
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "accidental-text")]
    public class accidentaltext
    {
        private string langField;

        private string spaceField;

        private accidentalvalue valueField;


        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get { return langField; }
            set { langField = value; }
        }


        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string space
        {
            get { return spaceField; }
            set { spaceField = value; }
        }


        [XmlText]
        public accidentalvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}