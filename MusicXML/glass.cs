using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    public enum glass
    {
        [XmlEnum("wind chimes")] windchimes,
    }
}