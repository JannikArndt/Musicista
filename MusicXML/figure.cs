using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class figure
    {
        private extend extendField;
        private styletext figurenumberField;
        private styletext prefixField;

        private styletext suffixField;


        public styletext prefix
        {
            get { return prefixField; }
            set { prefixField = value; }
        }


        [XmlElement("figure-number")]
        public styletext figurenumber
        {
            get { return figurenumberField; }
            set { figurenumberField = value; }
        }


        public styletext suffix
        {
            get { return suffixField; }
            set { suffixField = value; }
        }


        public extend extend
        {
            get { return extendField; }
            set { extendField = value; }
        }
    }
}