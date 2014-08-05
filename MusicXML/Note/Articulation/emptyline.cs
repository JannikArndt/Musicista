using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using MusicXML.Enums;

namespace MusicXML.Note.Articulation
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "empty-line")]
    public class emptyline
    {
        private decimal dashlengthField;

        private bool dashlengthFieldSpecified;
        private lineshape lineshapeField;

        private bool lineshapeFieldSpecified;

        private linetype linetypeField;

        private bool linetypeFieldSpecified;

        private abovebelow placementField;

        private bool placementFieldSpecified;
        private decimal spacelengthField;

        private bool spacelengthFieldSpecified;


        [XmlAttribute("line-shape")]
        public lineshape lineshape
        {
            get { return lineshapeField; }
            set { lineshapeField = value; }
        }


        [XmlIgnore]
        public bool lineshapeSpecified
        {
            get { return lineshapeFieldSpecified; }
            set { lineshapeFieldSpecified = value; }
        }


        [XmlAttribute("line-type")]
        public linetype linetype
        {
            get { return linetypeField; }
            set { linetypeField = value; }
        }


        [XmlIgnore]
        public bool linetypeSpecified
        {
            get { return linetypeFieldSpecified; }
            set { linetypeFieldSpecified = value; }
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