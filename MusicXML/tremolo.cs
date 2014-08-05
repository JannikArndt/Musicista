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
    public class tremolo
    {
        private abovebelow placementField;

        private bool placementFieldSpecified;
        private startstopsingle typeField;

        private string valueField;

        public tremolo()
        {
            typeField = startstopsingle.single;
        }


        [XmlAttribute]
        [DefaultValue(startstopsingle.single)]
        public startstopsingle type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute]
        public abovebelow placement
        {
            get { return placementField; }
            set { placementField = value; }
        }


        [XmlIgnore]
        public bool placementSpecified
        {
            get { return placementFieldSpecified; }
            set { placementFieldSpecified = value; }
        }


        [XmlText(DataType = "integer")]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}