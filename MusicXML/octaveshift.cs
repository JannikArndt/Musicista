using MusicXML.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "octave-shift")]
    public class octaveshift
    {
        private decimal dashlengthField;

        private bool dashlengthFieldSpecified;
        private string numberField;

        private string sizeField;

        private decimal spacelengthField;

        private bool spacelengthFieldSpecified;
        private updownstopcontinue typeField;

        public octaveshift()
        {
            sizeField = "8";
        }


        [XmlAttribute]
        public updownstopcontinue type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        [DefaultValue("8")]
        public string size
        {
            get { return sizeField; }
            set { sizeField = value; }
        }


        [XmlAttribute("dash-length")]
        public decimal dashlength
        {
            get { return dashlengthField; }
            set { dashlengthField = value; }
        }


        [XmlIgnore]
        public bool dashlengthSpecified
        {
            get { return dashlengthFieldSpecified; }
            set { dashlengthFieldSpecified = value; }
        }


        [XmlAttribute("space-length")]
        public decimal spacelength
        {
            get { return spacelengthField; }
            set { spacelengthField = value; }
        }


        [XmlIgnore]
        public bool spacelengthSpecified
        {
            get { return spacelengthFieldSpecified; }
            set { spacelengthFieldSpecified = value; }
        }
    }
}