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
    [XmlType(TypeName = "bass-alter")]
    public class bassalter
    {
        private leftright locationField;

        private bool locationFieldSpecified;
        private yesno printobjectField;

        private bool printobjectFieldSpecified;

        private decimal valueField;


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
        public leftright location
        {
            get { return locationField; }
            set { locationField = value; }
        }


        [XmlIgnore]
        public bool locationSpecified
        {
            get { return locationFieldSpecified; }
            set { locationFieldSpecified = value; }
        }


        [XmlText]
        public decimal Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}