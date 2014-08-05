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
    public class link
    {
        private opusActuate actuateField;

        private decimal defaultxField;

        private bool defaultxFieldSpecified;

        private decimal defaultyField;

        private bool defaultyFieldSpecified;
        private string elementField;
        private string hrefField;
        private string nameField;
        private string positionField;

        private decimal relativexField;

        private bool relativexFieldSpecified;

        private decimal relativeyField;

        private bool relativeyFieldSpecified;
        private string roleField;
        private opusShow showField;
        private string titleField;
        private opusType typeField;

        private bool typeFieldSpecified;

        public link()
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


        [XmlAttribute(DataType = "token")]
        public string name
        {
            get { return nameField; }
            set { nameField = value; }
        }


        [XmlAttribute(DataType = "NMTOKEN")]
        public string element
        {
            get { return elementField; }
            set { elementField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        public string position
        {
            get { return positionField; }
            set { positionField = value; }
        }


        [XmlAttribute("default-x")]
        public decimal defaultx
        {
            get { return defaultxField; }
            set { defaultxField = value; }
        }


        [XmlIgnore]
        public bool defaultxSpecified
        {
            get { return defaultxFieldSpecified; }
            set { defaultxFieldSpecified = value; }
        }


        [XmlAttribute("default-y")]
        public decimal defaulty
        {
            get { return defaultyField; }
            set { defaultyField = value; }
        }


        [XmlIgnore]
        public bool defaultySpecified
        {
            get { return defaultyFieldSpecified; }
            set { defaultyFieldSpecified = value; }
        }


        [XmlAttribute("relative-x")]
        public decimal relativex
        {
            get { return relativexField; }
            set { relativexField = value; }
        }


        [XmlIgnore]
        public bool relativexSpecified
        {
            get { return relativexFieldSpecified; }
            set { relativexFieldSpecified = value; }
        }


        [XmlAttribute("relative-y")]
        public decimal relativey
        {
            get { return relativeyField; }
            set { relativeyField = value; }
        }


        [XmlIgnore]
        public bool relativeySpecified
        {
            get { return relativeyFieldSpecified; }
            set { relativeyFieldSpecified = value; }
        }
    }
}