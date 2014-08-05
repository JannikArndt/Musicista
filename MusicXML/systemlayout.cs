using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "system-layout")]
    public class systemlayout
    {
        private decimal systemdistanceField;

        private bool systemdistanceFieldSpecified;
        private systemdividers systemdividersField;
        private systemmargins systemmarginsField;

        private decimal topsystemdistanceField;

        private bool topsystemdistanceFieldSpecified;


        [XmlElement("system-margins")]
        public systemmargins systemmargins
        {
            get { return systemmarginsField; }
            set { systemmarginsField = value; }
        }


        [XmlElement("system-distance")]
        public decimal systemdistance
        {
            get { return systemdistanceField; }
            set { systemdistanceField = value; }
        }


        [XmlIgnore]
        public bool systemdistanceSpecified
        {
            get { return systemdistanceFieldSpecified; }
            set { systemdistanceFieldSpecified = value; }
        }


        [XmlElement("top-system-distance")]
        public decimal topsystemdistance
        {
            get { return topsystemdistanceField; }
            set { topsystemdistanceField = value; }
        }


        [XmlIgnore]
        public bool topsystemdistanceSpecified
        {
            get { return topsystemdistanceFieldSpecified; }
            set { topsystemdistanceFieldSpecified = value; }
        }


        [XmlElement("system-dividers")]
        public systemdividers systemdividers
        {
            get { return systemdividersField; }
            set { systemdividersField = value; }
        }
    }
}