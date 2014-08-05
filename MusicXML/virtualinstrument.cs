using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "virtual-instrument")]
    public class virtualinstrument
    {
        private string virtuallibraryField;

        private string virtualnameField;


        [XmlElement("virtual-library")]
        public string virtuallibrary
        {
            get { return virtuallibraryField; }
            set { virtuallibraryField = value; }
        }


        [XmlElement("virtual-name")]
        public string virtualname
        {
            get { return virtualnameField; }
            set { virtualnameField = value; }
        }
    }
}