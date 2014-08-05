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
    public class stick
    {
        private stickmaterial stickmaterialField;
        private sticktype sticktypeField;

        private tipdirection tipField;

        private bool tipFieldSpecified;


        [XmlElement("stick-type")]
        public sticktype sticktype
        {
            get { return sticktypeField; }
            set { sticktypeField = value; }
        }


        [XmlElement("stick-material")]
        public stickmaterial stickmaterial
        {
            get { return stickmaterialField; }
            set { stickmaterialField = value; }
        }


        [XmlAttribute]
        public tipdirection tip
        {
            get { return tipField; }
            set { tipField = value; }
        }


        [XmlIgnore]
        public bool tipSpecified
        {
            get { return tipFieldSpecified; }
            set { tipFieldSpecified = value; }
        }
    }
}