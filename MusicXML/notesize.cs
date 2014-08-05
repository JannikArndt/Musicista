using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "note-size")]
    public class notesize
    {
        private notesizetype typeField;

        private decimal valueField;


        [XmlAttribute]
        public notesizetype type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlText]
        public decimal Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}