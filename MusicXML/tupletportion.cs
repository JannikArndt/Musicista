using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "tuplet-portion")]
    public class tupletportion
    {
        private tupletdot[] tupletdotField;
        private tupletnumber tupletnumberField;

        private tuplettype tuplettypeField;


        [XmlElement("tuplet-number")]
        public tupletnumber tupletnumber
        {
            get { return tupletnumberField; }
            set { tupletnumberField = value; }
        }


        [XmlElement("tuplet-type")]
        public tuplettype tuplettype
        {
            get { return tuplettypeField; }
            set { tuplettypeField = value; }
        }


        [XmlElement("tuplet-dot")]
        public tupletdot[] tupletdot
        {
            get { return tupletdotField; }
            set { tupletdotField = value; }
        }
    }
}