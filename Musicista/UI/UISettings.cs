
namespace Musicista.UI
{
    public class UISettings
    {
        public double MarginTop { get; set; }
        public double MarginBelowTitle { get; set; }
        public double StaffSpacing { get; set; }
        public double SystemSpacing { get; set; }
        public double SystemMarginLeft { get; set; }
        public double SystemMarginRight { get; set; }

        public UISettings(bool firstPage = false)
        {
            MarginTop = 60;
            MarginBelowTitle = 60;
            StaffSpacing = 50;
            SystemSpacing = 60;
            SystemMarginLeft = 50;
            SystemMarginRight = 50;
        }
    }
}
