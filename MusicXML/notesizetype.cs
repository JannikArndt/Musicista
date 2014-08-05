using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "note-size-type")]
    public enum notesizetype
    {
        cue,


        grace,


        large,
    }
}