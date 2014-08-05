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
    [XmlType(TypeName = "hammer-on-pull-off")]
    public class hammeronpulloff
    {
        private string numberField;

        private abovebelow placementField;

        private bool placementFieldSpecified;
        private startstop typeField;

        private string valueField;

        public hammeronpulloff()
        {
            numberField = "1";
        }


        [XmlAttribute]
        public startstop type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        [DefaultValue("1")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
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


        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}