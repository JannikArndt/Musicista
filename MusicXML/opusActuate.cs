using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/xlink")]
    public enum opusActuate
    {
        onRequest,


        onLoad,


        other,


        none,
    }
}