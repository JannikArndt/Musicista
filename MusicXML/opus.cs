using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class opus
    {
        public opus()
        {
            type = opusType.simple;
            show = opusShow.replace;
            actuate = opusActuate.onRequest;
        }

        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink", DataType = "anyURI")]
        public string href { get; set; }


        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        public opusType type { get; set; }


        [XmlIgnore]
        public bool typeSpecified { get; set; }


        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink", DataType = "token")]
        public string role { get; set; }


        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink", DataType = "token")]
        public string title { get; set; }


        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink"), DefaultValue(opusShow.replace)]
        public opusShow show { get; set; }


        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink"), DefaultValue(opusActuate.onRequest)]
        public opusActuate actuate { get; set; }
    }
}