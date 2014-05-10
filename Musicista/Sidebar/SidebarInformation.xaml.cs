using System.Windows.Controls;

namespace Musicista.Sidebar
{
    /// <summary>
    /// Interaction logic for SidebarInformation.xaml
    /// </summary>
    public partial class SidebarInformation : UserControl
    {
        public SidebarInformation()
        {
            InitializeComponent();
        }

        public void ShowUIElement(object uiObject)
        {
            if (uiObject is TextBlock)
                Clicked.Text = (uiObject as TextBlock).Text;
        }
    }
}
