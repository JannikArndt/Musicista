using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "string-mute")]
    public class stringmute
    {
        private onoff typeField;


        [XmlAttribute]
        public onoff type
        {
            get { return typeField; }
            set { typeField = value; }
        }
    }
}