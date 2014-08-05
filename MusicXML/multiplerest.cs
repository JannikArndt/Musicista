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
    [XmlType(TypeName = "multiple-rest")]
    public class multiplerest
    {
        private yesno usesymbolsField;

        private bool usesymbolsFieldSpecified;

        private string valueField;


        [XmlAttribute("use-symbols")]
        public yesno usesymbols
        {
            get { return usesymbolsField; }
            set { usesymbolsField = value; }
        }


        [XmlIgnore]
        public bool usesymbolsSpecified
        {
            get { return usesymbolsFieldSpecified; }
            set { usesymbolsFieldSpecified = value; }
        }


        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}