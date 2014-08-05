using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class extend
    {
        private startstopcontinue typeField;

        private bool typeFieldSpecified;


        [XmlAttribute]
        public startstopcontinue type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlIgnore]
        public bool typeSpecified
        {
            get { return typeFieldSpecified; }
            set { typeFieldSpecified = value; }
        }
    }
}