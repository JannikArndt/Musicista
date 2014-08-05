using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class harmony
    {
        private bass[] bassField;

        private degree[] degreeField;

        private FormattedText footnoteField;
        private frame frameField;
        private inversion[] inversionField;
        private object[] itemsField;

        private kind[] kindField;

        private level levelField;
        private offset offsetField;
        private abovebelow placementField;

        private bool placementFieldSpecified;
        private yesno printframeField;

        private bool printframeFieldSpecified;
        private yesno printobjectField;

        private bool printobjectFieldSpecified;

        private string staffField;

        private harmonytype typeField;

        private bool typeFieldSpecified;


        [XmlElement("function", typeof (styletext))]
        [XmlElement("root", typeof (root))]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlElement("kind")]
        public kind[] kind
        {
            get { return kindField; }
            set { kindField = value; }
        }


        [XmlElement("inversion")]
        public inversion[] inversion
        {
            get { return inversionField; }
            set { inversionField = value; }
        }


        [XmlElement("bass")]
        public bass[] bass
        {
            get { return bassField; }
            set { bassField = value; }
        }


        [XmlElement("degree")]
        public degree[] degree
        {
            get { return degreeField; }
            set { degreeField = value; }
        }


        public frame frame
        {
            get { return frameField; }
            set { frameField = value; }
        }


        public offset offset
        {
            get { return offsetField; }
            set { offsetField = value; }
        }


        public FormattedText footnote
        {
            get { return footnoteField; }
            set { footnoteField = value; }
        }


        public level level
        {
            get { return levelField; }
            set { levelField = value; }
        }


        [XmlElement(DataType = "positiveInteger")]
        public string staff
        {
            get { return staffField; }
            set { staffField = value; }
        }


        [XmlAttribute]
        public harmonytype type
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


        [XmlAttribute("print-object")]
        public yesno printobject
        {
            get { return printobjectField; }
            set { printobjectField = value; }
        }


        [XmlIgnore]
        public bool printobjectSpecified
        {
            get { return printobjectFieldSpecified; }
            set { printobjectFieldSpecified = value; }
        }


        [XmlAttribute("print-frame")]
        public yesno printframe
        {
            get { return printframeField; }
            set { printframeField = value; }
        }


        [XmlIgnore]
        public bool printframeSpecified
        {
            get { return printframeFieldSpecified; }
            set { printframeFieldSpecified = value; }
        }


        [XmlAttribute]
        public abovebelow placement
        {
            get { return placementField; }
            set { placementField = value; }
        }


        [XmlIgnore]
        public bool placementSpecified
        {
            get { return placementFieldSpecified; }
            set { placementFieldSpecified = value; }
        }
    }
}