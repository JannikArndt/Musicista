using System;

using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType5
    {
        f,


        ff,


        fff,


        ffff,


        fffff,


        ffffff,


        fp,


        fz,


        mf,


        mp,


        [XmlEnum("other-dynamics")] otherdynamics,


        p,


        pp,


        ppp,


        pppp,


        ppppp,


        pppppp,


        rf,


        rfz,


        sf,


        sffz,


        sfp,


        sfpp,


        sfz,
    }
}