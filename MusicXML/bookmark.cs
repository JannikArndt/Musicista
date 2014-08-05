using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class bookmark
    {
        private string elementField;
        private string idField;

        private string nameField;

        private string positionField;


        [XmlAttribute(DataType = "ID")]
        public string id
        {
            get { return idField; }
            set { idField = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string name
        {
            get { return nameField; }
            set { nameField = value; }
        }


        [XmlAttribute(DataType = "NMTOKEN")]
        public string element
        {
            get { return elementField; }
            set { elementField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        public string position
        {
            get { return positionField; }
            set { positionField = value; }
        }
    }
}