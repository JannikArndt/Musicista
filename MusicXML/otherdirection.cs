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
    [XmlType(TypeName = "other-direction")]
    public class otherdirection
    {
        private yesno printobjectField;

        private bool printobjectFieldSpecified;

        private string valueField;


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


        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}