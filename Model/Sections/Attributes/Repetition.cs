using System.ComponentModel;

namespace Model.Sections.Attributes
{
    /// <summary>
    /// Represents a repetition. Use description attribute for actual displaying
    /// </summary>
    public enum Repetition
    {
        None,
        SegnoSign,
        CodaSign,
        [Description("Da Capo")]
        dacapo,
        [Description("D.C.")]
        dc,
        [Description("D.C. al Fine")]
        dcalfine,
        [Description("D.C. al Coda")]
        dcalcoda,
        [Description("Da Capo al Fine")]
        dacapoalfine,
        [Description("Dal Segno")]
        dalsegno,
        [Description("D.S.")]
        ds,
        [Description("D.S. al Fine")]
        dsalfine,
        [Description("D.S. al Coda")]
        dsalcoda,
        [Description("Dal Segno al Fine")]
        dalsegnoalfine,
        [Description("Al Fine")]
        alfine,
        [Description("Fine")]
        fine,
        [Description("To Coda")]
        tocoda

    }
}
