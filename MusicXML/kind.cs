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
    public class kind
    {
        private yesno bracketdegreesField;

        private bool bracketdegreesFieldSpecified;

        private leftcenterright halignField;

        private bool halignFieldSpecified;
        private yesno parenthesesdegreesField;

        private bool parenthesesdegreesFieldSpecified;
        private yesno stackdegreesField;

        private bool stackdegreesFieldSpecified;
        private string textField;
        private yesno usesymbolsField;

        private bool usesymbolsFieldSpecified;

        private valign valignField;

        private bool valignFieldSpecified;

        private kindvalue valueField;


        [XmlAttribute("use-symbols")]
        public yesno usesymbols
        {
            get { return usesymbolsField; }
            set { usesymbolsField = value; }
        }


        [XmlIgnore]
        public bool usesymbolsSpecified
        {
            get { return usesymbolsFieldSpecified; }
            set { usesymbolsFieldSpecified = value; }
        }


        [XmlAttribute(DataType = "token")]
        public string text
        {
            get { return textField; }
            set { textField = value; }
        }


        [XmlAttribute("stack-degrees")]
        public yesno stackdegrees
        {
            get { return stackdegreesField; }
            set { stackdegreesField = value; }
        }


        [XmlIgnore]
        public bool stackdegreesSpecified
        {
            get { return stackdegreesFieldSpecified; }
            set { stackdegreesFieldSpecified = value; }
        }


        [XmlAttribute("parentheses-degrees")]
        public yesno parenthesesdegrees
        {
            get { return parenthesesdegreesField; }
            set { parenthesesdegreesField = value; }
        }


        [XmlIgnore]
        public bool parenthesesdegreesSpecified
        {
            get { return parenthesesdegreesFieldSpecified; }
            set { parenthesesdegreesFieldSpecified = value; }
        }


        [XmlAttribute("bracket-degrees")]
        public yesno bracketdegrees
        {
            get { return bracketdegreesField; }
            set { bracketdegreesField = value; }
        }


        [XmlIgnore]
        public bool bracketdegreesSpecified
        {
            get { return bracketdegreesFieldSpecified; }
            set { bracketdegreesFieldSpecified = value; }
        }


        [XmlAttribute]
        public leftcenterright halign
        {
            get { return halignField; }
            set { halignField = value; }
        }


        [XmlIgnore]
        public bool halignSpecified
        {
            get { return halignFieldSpecified; }
            set { halignFieldSpecified = value; }
        }


        [XmlAttribute]
        public valign valign
        {
            get { return valignField; }
            set { valignField = value; }
        }


        [XmlIgnore]
        public bool valignSpecified
        {
            get { return valignFieldSpecified; }
            set { valignFieldSpecified = value; }
        }


        [XmlText]
        public kindvalue Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}