using MusicXML.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML.Note.Articulation
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "heel-toe")]
    public class heeltoe : Emptyplacement
    {
        private yesno substitutionField;

        private bool substitutionFieldSpecified;


        [XmlAttribute]
        public yesno substitution
        {
            get { return substitutionField; }
            set { substitutionField = value; }
        }


        [XmlIgnore]
        public bool substitutionSpecified
        {
            get { return substitutionFieldSpecified; }
            set { substitutionFieldSpecified = value; }
        }
    }
}