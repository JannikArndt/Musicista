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
    public class beater
    {
        private tipdirection tipField;

        private bool tipFieldSpecified;

        private beatervalue valueField;


        [XmlAttribute]
        public tipdirection tip
        {
            get { return tipField; }
            set { tipField = value; }
        }


        [XmlIgnore]
        public bool tipSpecified
        {
            get { return tipFieldSpecified; }
            set { tipFieldSpecified = value; }
        }


        [XmlText]
        public beatervalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}