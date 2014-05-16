namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class link
    {

        private string hrefField;

        private opusType typeField;

        private bool typeFieldSpecified;

        private string roleField;

        private string titleField;

        private opusShow showField;

        private opusActuate actuateField;

        private string nameField;

        private string elementField;

        private string positionField;

        private decimal defaultxField;

        private bool defaultxFieldSpecified;

        private decimal defaultyField;

        private bool defaultyFieldSpecified;

        private decimal relativexField;

        private bool relativexFieldSpecified;

        private decimal relativeyField;

        private bool relativeyFieldSpecified;

        public link()
        {
            this.typeField = opusType.simple;
            this.showField = opusShow.replace;
            this.actuateField = opusActuate.onRequest;
        }


        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink", DataType = "anyURI")]
        public string href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        public opusType type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink", DataType = "token")]
        public string role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink", DataType = "token")]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        [System.ComponentModel.DefaultValueAttribute(opusShow.replace)]
        public opusShow show
        {
            get
            {
                return this.showField;
            }
            set
            {
                this.showField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        [System.ComponentModel.DefaultValueAttribute(opusActuate.onRequest)]
        public opusActuate actuate
        {
            get
            {
                return this.actuateField;
            }
            set
            {
                this.actuateField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
        public string element
        {
            get
            {
                return this.elementField;
            }
            set
            {
                this.elementField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public string position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("default-x")]
        public decimal defaultx
        {
            get
            {
                return this.defaultxField;
            }
            set
            {
                this.defaultxField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool defaultxSpecified
        {
            get
            {
                return this.defaultxFieldSpecified;
            }
            set
            {
                this.defaultxFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("default-y")]
        public decimal defaulty
        {
            get
            {
                return this.defaultyField;
            }
            set
            {
                this.defaultyField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool defaultySpecified
        {
            get
            {
                return this.defaultyFieldSpecified;
            }
            set
            {
                this.defaultyFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("relative-x")]
        public decimal relativex
        {
            get
            {
                return this.relativexField;
            }
            set
            {
                this.relativexField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool relativexSpecified
        {
            get
            {
                return this.relativexFieldSpecified;
            }
            set
            {
                this.relativexFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute("relative-y")]
        public decimal relativey
        {
            get
            {
                return this.relativeyField;
            }
            set
            {
                this.relativeyField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool relativeySpecified
        {
            get
            {
                return this.relativeyFieldSpecified;
            }
            set
            {
                this.relativeyFieldSpecified = value;
            }
        }
    }
}