using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "page-layout")]
    public class pagelayout
    {
        private decimal pageheightField;

        private pagemargins[] pagemarginsField;
        private decimal pagewidthField;


        [XmlElement("page-height")]
        public decimal pageheight
        {
            get { return pageheightField; }
            set { pageheightField = value; }
        }


        [XmlElement("page-width")]
        public decimal pagewidth
        {
            get { return pagewidthField; }
            set { pagewidthField = value; }
        }


        [XmlElement("page-margins")]
        public pagemargins[] pagemargins
        {
            get { return pagemarginsField; }
            set { pagemarginsField = value; }
        }
    }
}