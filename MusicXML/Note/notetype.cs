using MusicXML.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "note-type")]
    public class notetype
    {
        private notetypevalue valueField;


        [XmlAttribute]
        public symbolsize size { get; set; }


        [XmlIgnore]
        public bool sizeSpecified { get; set; }


        [XmlText]
        public notetypevalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}