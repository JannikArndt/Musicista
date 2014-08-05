using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML.Note
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class grace
    {
        private decimal maketimeField;

        private bool maketimeFieldSpecified;

        private yesno slashField;

        private bool slashFieldSpecified;
        private decimal stealtimefollowingField;

        private bool stealtimefollowingFieldSpecified;
        private decimal stealtimepreviousField;

        private bool stealtimepreviousFieldSpecified;


        [XmlAttribute("steal-time-previous")]
        public decimal stealtimeprevious
        {
            get { return stealtimepreviousField; }
            set { stealtimepreviousField = value; }
        }


        [XmlIgnore]
        public bool stealtimepreviousSpecified
        {
            get { return stealtimepreviousFieldSpecified; }
            set { stealtimepreviousFieldSpecified = value; }
        }


        [XmlAttribute("steal-time-following")]
        public decimal stealtimefollowing
        {
            get { return stealtimefollowingField; }
            set { stealtimefollowingField = value; }
        }


        [XmlIgnore]
        public bool stealtimefollowingSpecified
        {
            get { return stealtimefollowingFieldSpecified; }
            set { stealtimefollowingFieldSpecified = value; }
        }


        [XmlAttribute("make-time")]
        public decimal maketime
        {
            get { return maketimeField; }
            set { maketimeField = value; }
        }


        [XmlIgnore]
        public bool maketimeSpecified
        {
            get { return maketimeFieldSpecified; }
            set { maketimeFieldSpecified = value; }
        }


        [XmlAttribute]
        public yesno slash
        {
            get { return slashField; }
            set { slashField = value; }
        }


        [XmlIgnore]
        public bool slashSpecified
        {
            get { return slashFieldSpecified; }
            set { slashFieldSpecified = value; }
        }
    }
}