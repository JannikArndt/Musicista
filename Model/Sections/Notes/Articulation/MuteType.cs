using System.ComponentModel;

namespace Model.Sections.Notes.Articulation
{
    public enum MuteType
    {
        None,
        [Description("con sord.")]
        consord,
        [Description("con sordina")]
        consordina,
        [Description("con sordine")]
        consordine,
        [Description("senza sord.")]
        senzasord,
        [Description("via sord.")]
        viasord,
        [Description("with mute")]
        withmute,
        [Description("remove mute")]
        removemute,
        [Description("straight mute")]
        straightmute,
        [Description("muted")]
        muted,
        [Description("open")]
        open,

    }
}
