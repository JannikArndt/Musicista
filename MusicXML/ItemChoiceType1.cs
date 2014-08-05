using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemChoiceType1
    {
        [XmlEnum("pre-bend")] prebend,


        release,
    }
}