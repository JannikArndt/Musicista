
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
            StaffSpacing = 70;
            SystemSpacing = 30;
            SystemMarginLeft = 50;
            SystemMarginRight = 50;
        }
    }
}
