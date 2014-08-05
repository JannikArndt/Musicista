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
    [XmlType(TypeName = "metronome-tuplet")]
    public class metronometuplet : timemodification
    {
        private yesno bracketField;

        private bool bracketFieldSpecified;

        private showtuplet shownumberField;

        private bool shownumberFieldSpecified;
        private startstop typeField;


        [XmlAttribute]
        public startstop type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute]
        public yesno bracket
        {
            get { return bracketField; }
            set { bracketField = value; }
        }


        [XmlIgnore]
        public bool bracketSpecified
        {
            get { return bracketFieldSpecified; }
            set { bracketFieldSpecified = value; }
        }


        [XmlAttribute("show-number")]
        public showtuplet shownumber
        {
            get { return shownumberField; }
            set { shownumberField = value; }
        }


        [XmlIgnore]
        public bool shownumberSpecified
        {
            get { return shownumberFieldSpecified; }
            set { shownumberFieldSpecified = value; }
        }
    }
}