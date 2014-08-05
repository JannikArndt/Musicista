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
    [XmlType(TypeName = "staff-details")]
    public class staffdetails
    {
        private string capoField;

        private string numberField;

        private yesno printobjectField;

        private bool printobjectFieldSpecified;

        private yesno printspacingField;

        private bool printspacingFieldSpecified;
        private showfrets showfretsField;

        private bool showfretsFieldSpecified;
        private string stafflinesField;
        private decimal staffsizeField;

        private bool staffsizeFieldSpecified;
        private stafftuning[] stafftuningField;
        private stafftype stafftypeField;

        private bool stafftypeFieldSpecified;


        [XmlElement("staff-type")]
        public stafftype stafftype
        {
            get { return stafftypeField; }
            set { stafftypeField = value; }
        }


        [XmlIgnore]
        public bool stafftypeSpecified
        {
            get { return stafftypeFieldSpecified; }
            set { stafftypeFieldSpecified = value; }
        }


        [XmlElement("staff-lines", DataType = "nonNegativeInteger")]
        public string stafflines
        {
            get { return stafflinesField; }
            set { stafflinesField = value; }
        }


        [XmlElement("staff-tuning")]
        public stafftuning[] stafftuning
        {
            get { return stafftuningField; }
            set { stafftuningField = value; }
        }


        [XmlElement(DataType = "nonNegativeInteger")]
        public string capo
        {
            get { return capoField; }
            set { capoField = value; }
        }


        [XmlElement("staff-size")]
        public decimal staffsize
        {
            get { return staffsizeField; }
            set { staffsizeField = value; }
        }


        [XmlIgnore]
        public bool staffsizeSpecified
        {
            get { return staffsizeFieldSpecified; }
            set { staffsizeFieldSpecified = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }


        [XmlAttribute("show-frets")]
        public showfrets showfrets
        {
            get { return showfretsField; }
            set { showfretsField = value; }
        }


        [XmlIgnore]
        public bool showfretsSpecified
        {
            get { return showfretsFieldSpecified; }
            set { showfretsFieldSpecified = value; }
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


        [XmlAttribute("print-spacing")]
        public yesno printspacing
        {
            get { return printspacingField; }
            set { printspacingField = value; }
        }


        [XmlIgnore]
        public bool printspacingSpecified
        {
            get { return printspacingFieldSpecified; }
            set { printspacingFieldSpecified = value; }
        }
    }
}