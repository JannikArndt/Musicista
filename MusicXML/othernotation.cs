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
    [XmlType(TypeName = "other-notation")]
    public class othernotation
    {
        private string numberField;

        private abovebelow placementField;

        private bool placementFieldSpecified;
        private yesno printobjectField;

        private bool printobjectFieldSpecified;
        private startstopsingle typeField;

        private string valueField;

        public othernotation()
        {
            numberField = "1";
        }


        [XmlAttribute]
        public startstopsingle type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        [DefaultValue("1")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }


        [XmlAttribute("print-object")]
        public yesno printobject
        {
            get { return printobjectField; }
            set { printobjectField = value; }
        }


        [XmlIgnore]
        public bool printobjectSpecified
        {
            get { return printobjectFieldSpecified; }
            set { printobjectFieldSpecified = value; }
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


        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}