using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "score-instrument")]
    public class scoreinstrument
    {
        private string idField;
        private string instrumentabbreviationField;
        private string instrumentnameField;

        private string instrumentsoundField;

        private object itemField;

        private virtualinstrument virtualinstrumentField;


        [XmlElement("instrument-name")]
        public string instrumentname
        {
            get { return instrumentnameField; }
            set { instrumentnameField = value; }
        }


        [XmlElement("instrument-abbreviation")]
        public string instrumentabbreviation
        {
            get { return instrumentabbreviationField; }
            set { instrumentabbreviationField = value; }
        }


        [XmlElement("instrument-sound")]
        public string instrumentsound
        {
            get { return instrumentsoundField; }
            set { instrumentsoundField = value; }
        }


        [XmlElement("ensemble", typeof (string))]
        [XmlElement("solo", typeof (empty))]
        public object Item
        {
            get { return itemField; }
            set { itemField = value; }
        }


        [XmlElement("virtual-instrument")]
        public virtualinstrument virtualinstrument
        {
            get { return virtualinstrumentField; }
            set { virtualinstrumentField = value; }
        }


        [XmlAttribute(DataType = "ID")]
        public string id
        {
            get { return idField; }
            set { idField = value; }
        }
    }
}