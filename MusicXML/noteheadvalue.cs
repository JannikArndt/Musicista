using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(TypeName = "notehead-value")]
    public enum noteheadvalue
    {
        slash,


        triangle,


        diamond,


        square,


        cross,


        x,


        [XmlEnum("circle-x")] circlex,


        [XmlEnum("inverted triangle")] invertedtriangle,


        [XmlEnum("arrow down")] arrowdown,


        [XmlEnum("arrow up")] arrowup,


        slashed,


        [XmlEnum("back slashed")] backslashed,


        normal,


        cluster,


        [XmlEnum("circle dot")] circledot,


        [XmlEnum("left triangle")] lefttriangle,


        rectangle,


        none,


        @do,


        re,


        mi,


        fa,


        [XmlEnum("fa up")] faup,


        so,


        la,


        ti,
    }
}