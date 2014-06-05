
using System.ComponentModel;

namespace Model
{
    public enum Epoch
    {
        None,
        Medieval,
        Renaissance,
        Baroque,
        Classical,
        Romantic,
        Modern,
        [Description("Twentieth Century")]
        TwentiethCentury,
        Contemporary,
        [Description("Twentyfirst Century")]
        TwentyFirstCentury,
        Pop
    }
}
