using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "system-dividers")]
    public class systemdividers
    {
        private emptyprintobjectstylealign leftdividerField;

        private emptyprintobjectstylealign rightdividerField;


        [XmlElement("left-divider")]
        public emptyprintobjectstylealign leftdivider
        {
            get { return leftdividerField; }
            set { leftdividerField = value; }
        }


        [XmlElement("right-divider")]
        public emptyprintobjectstylealign rightdivider
        {
            get { return rightdividerField; }
            set { rightdividerField = value; }
        }
    }
}