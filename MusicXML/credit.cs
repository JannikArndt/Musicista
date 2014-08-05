using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class credit
    {
        private bookmark[] bookmarkField;
        private string[] credittypeField;

        private object[] itemsField;
        private link[] linkField;

        private string pageField;


        [XmlElement("credit-type", Order = 0)]
        public string[] credittype
        {
            get { return credittypeField; }
            set { credittypeField = value; }
        }


        [XmlElement("link", Order = 1)]
        public link[] link
        {
            get { return linkField; }
            set { linkField = value; }
        }


        [XmlElement("bookmark", Order = 2)]
        public bookmark[] bookmark
        {
            get { return bookmarkField; }
            set { bookmarkField = value; }
        }


        [XmlElement("bookmark", typeof (bookmark), Order = 3)]
        [XmlElement("credit-image", typeof (image), Order = 3)]
        [XmlElement("credit-words", typeof (formattedtext), Order = 3)]
        [XmlElement("link", typeof (link), Order = 3)]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlAttribute(DataType = "positiveInteger")]
        public string page
        {
            get { return pageField; }
            set { pageField = value; }
        }
    }
}