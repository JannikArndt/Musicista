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
    public class play
    {
        private string idField;
        private object[] itemsField;


        [XmlElement("ipa", typeof(string))]
        [XmlElement("mute", typeof(mute))]
        [XmlElement("other-play", typeof(otherplay))]
        [XmlElement("semi-pitched", typeof(semipitched))]
        public object[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }


        [XmlAttribute(DataType = "IDREF")]
        public string id
        {
            get { return idField; }
            set { idField = value; }
        }
    }
}