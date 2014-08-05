using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Note;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "notehead-text")]
    public class noteheadtext
    {
        private object[] itemsField;


        [XmlElement("accidental-text", typeof(accidentaltext))]
        [XmlElement("display-text", typeof(FormattedText))]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }
    }
}