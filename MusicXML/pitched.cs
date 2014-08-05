using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    public enum pitched
    {
        chimes,


        glockenspiel,


        mallet,


        marimba,


        [XmlEnum("tubular chimes")] tubularchimes,


        vibraphone,


        xylophone,
    }
}