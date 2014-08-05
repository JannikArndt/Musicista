using MusicXML.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "key-octave")]
    public class keyoctave
    {
        private yesno cancelField;

        private bool cancelFieldSpecified;
        private string numberField;

        private string valueField;


        [XmlAttribute(DataType = "positiveInteger")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }


        [XmlAttribute]
        public yesno cancel
        {
            get { return cancelField; }
            set { cancelField = value; }
        }


        [XmlIgnore]
        public bool cancelSpecified
        {
            get { return cancelFieldSpecified; }
            set { cancelFieldSpecified = value; }
        }


        [XmlText(DataType = "integer")]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}