using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "metronome-beam")]
    public class metronomebeam
    {
        private string numberField;

        private beamvalue valueField;

        public metronomebeam()
        {
            numberField = "1";
        }


        [XmlAttribute(DataType = "positiveInteger")]
        [DefaultValue("1")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }


        [XmlText]
        public beamvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}