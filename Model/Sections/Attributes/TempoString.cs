
using System.ComponentModel;

namespace Model.Sections.Attributes
{
    public enum TempoString
    {
        None,
        Other,
        [Description("Larghissimo")]
        larghissimo,
        [Description("Grave")]
        grave,
        [Description("Largo")]
        largo,
        [Description("Larghetto")]
        larghetto,
        [Description("Lento")]
        lento,
        [Description("Adagio")]
        adagio,
        [Description("Adagietto")]
        adagietto,
        [Description("Andante")]
        andante,
        [Description("Andantino")]
        andantino,
        [Description("Maestoso")]
        maestoso,
        [Description("Moderato")]
        moderato,
        [Description("Con Moto")]
        conmoto,
        [Description("Allegretto")]
        allegretto,
        [Description("Allegretto Moderato")]
        allegrettomoderato,
        [Description("Allegro")]
        allegro,
        [Description("Vivace")]
        vivace,
        [Description("Vivo")]
        vivo,
        [Description("Vivacissimo")]
        vivacissimo,
        [Description("Presto")]
        presto,
        [Description("Prestissimo")]
        prestissimo
    }
}
