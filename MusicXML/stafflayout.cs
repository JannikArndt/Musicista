using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "staff-layout")]
    public class stafflayout
    {
        private string numberField;
        private decimal staffdistanceField;

        private bool staffdistanceFieldSpecified;


        [XmlElement("staff-distance")]
        public decimal staffdistance
        {
            get { return staffdistanceField; }
            set { staffdistanceField = value; }
        }


        [XmlIgnore]
        public bool staffdistanceSpecified
        {
            get { return staffdistanceFieldSpecified; }
            set { staffdistanceFieldSpecified = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }
    }
}