
namespace Musicista.UI
{
    public class UISettings
    {
        public double MarginTop { get; set; }
        public double StaffSpacing { get; set; }
        public double SystemSpacing { get; set; }
        public double SystemMarginLeft { get; set; }
        public double SystemMarginRight { get; set; }

        public UISettings(bool firstPage = false)
        {
            if (firstPage)
            {
                MarginTop = 200;
                StaffSpacing = 70;
                SystemSpacing = 30;
            }
            else
            {
                MarginTop = 60;
                StaffSpacing = 55;
                SystemSpacing = 40;
            }
            SystemMarginLeft = 50;
            SystemMarginRight = 50;
        }

    }
}
