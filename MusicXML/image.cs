using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class image
    {
        private string sourceField;

        private string typeField;


        [XmlAttribute(DataType = "anyURI")]
        public string source
        {
            get { return sourceField; }
            set { sourceField = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string type
        {
            get { return typeField; }
            set { typeField = value; }
        }
    }
}