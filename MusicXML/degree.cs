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
    public class degree
    {
        private degreealter degreealterField;

        private degreetype degreetypeField;
        private degreevalue degreevalueField;

        private yesno printobjectField;

        private bool printobjectFieldSpecified;


        [XmlElement("degree-value")]
        public degreevalue degreevalue
        {
            get { return degreevalueField; }
            set { degreevalueField = value; }
        }


        [XmlElement("degree-alter")]
        public degreealter degreealter
        {
            get { return degreealterField; }
            set { degreealterField = value; }
        }


        [XmlElement("degree-type")]
        public degreetype degreetype
        {
            get { return degreetypeField; }
            set { degreetypeField = value; }
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
    }
}