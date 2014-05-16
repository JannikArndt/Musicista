using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MusicXML
{
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class opus
    {
        private opusActuate actuateField;
        private string hrefField;

        private string roleField;

        private opusShow showField;
        private string titleField;
        private opusType typeField;

        private bool typeFieldSpecified;

        public opus()
        {
            typeField = opusType.simple;
            showField = opusShow.replace;
            actuateField = opusActuate.onRequest;
        }

        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink", DataType = "anyURI")]
        public string href
        {
            get { return hrefField; }
            set { hrefField = value; }
        }

    
        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        public opusType type
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

    
        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink", DataType = "token")]
        public string role
        {
            get { return roleField; }
            set { roleField = value; }
        }

    
        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink", DataType = "token")]
        public string title
        {
            get { return titleField; }
            set { titleField = value; }
        }

    
        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        [DefaultValue(opusShow.replace)]
        public opusShow show
        {
            get { return showField; }
            set { showField = value; }
        }

    
        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        [DefaultValue(opusActuate.onRequest)]
        public opusActuate actuate
        {
            get { return actuateField; }
            set { actuateField = value; }
        }
    }
}