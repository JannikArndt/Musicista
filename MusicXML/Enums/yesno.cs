using System;
using System.Xml.Serialization;

namespace MusicXML.Enums
{

    [Serializable]
    [XmlType(TypeName = "yes-no")]
    public enum yesno
    {
        yes,
        no,
    }
}