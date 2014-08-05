using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(TypeName = "part-group")]
    public class partgroup
    {
        private FormattedText footnoteField;
        private groupname groupabbreviationField;

        private namedisplay groupabbreviationdisplayField;

        private groupbarline groupbarlineField;
        private groupname groupnameField;

        private namedisplay groupnamedisplayField;
        private groupsymbol groupsymbolField;

        private empty grouptimeField;

        private level levelField;

        private string numberField;
        private startstop typeField;

        public partgroup()
        {
            numberField = "1";
        }


        [XmlElement("group-name")]
        public groupname groupname
        {
            get { return groupnameField; }
            set { groupnameField = value; }
        }


        [XmlElement("group-name-display")]
        public namedisplay groupnamedisplay
        {
            get { return groupnamedisplayField; }
            set { groupnamedisplayField = value; }
        }


        [XmlElement("group-abbreviation")]
        public groupname groupabbreviation
        {
            get { return groupabbreviationField; }
            set { groupabbreviationField = value; }
        }


        [XmlElement("group-abbreviation-display")]
        public namedisplay groupabbreviationdisplay
        {
            get { return groupabbreviationdisplayField; }
            set { groupabbreviationdisplayField = value; }
        }


        [XmlElement("group-symbol")]
        public groupsymbol groupsymbol
        {
            get { return groupsymbolField; }
            set { groupsymbolField = value; }
        }


        [XmlElement("group-barline")]
        public groupbarline groupbarline
        {
            get { return groupbarlineField; }
            set { groupbarlineField = value; }
        }


        [XmlElement("group-time")]
        public empty grouptime
        {
            get { return grouptimeField; }
            set { grouptimeField = value; }
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


        [XmlAttribute]
        public startstop type
        {
            get { return typeField; }
            set { typeField = value; }
        }


        [XmlAttribute(DataType = "token")]
        [DefaultValue("1")]
        public string number
        {
            get { return numberField; }
            set { numberField = value; }
        }
    }
}