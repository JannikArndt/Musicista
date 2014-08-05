using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class appearance
    {
        private distance[] distanceField;
        private linewidth[] linewidthField;

        private notesize[] notesizeField;

        private otherappearance[] otherappearanceField;


        [XmlElement("line-width")]
        public linewidth[] linewidth
        {
            get { return linewidthField; }
            set { linewidthField = value; }
        }


        [XmlElement("note-size")]
        public notesize[] notesize
        {
            get { return notesizeField; }
            set { notesizeField = value; }
        }


        [XmlElement("distance")]
        public distance[] distance
        {
            get { return distanceField; }
            set { distanceField = value; }
        }


        [XmlElement("other-appearance")]
        public otherappearance[] otherappearance
        {
            get { return otherappearanceField; }
            set { otherappearanceField = value; }
        }
    }
}