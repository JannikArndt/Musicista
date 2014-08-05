using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "lyric-language")]
    public class lyriclanguage
    {
        private string langField;
        private string nameField;
        private string numberField;


        [XmlAttribute(DataType = "NMTOKEN")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string name
        {
            get { return nameField; }
            set { nameField = value; }
        }


        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get { return langField; }
            set { langField = value; }
        }
    }
}