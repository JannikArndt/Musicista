using Musicista.UI;
using System.Windows.Controls;
using System.Windows.Data;

namespace Musicista.Sidebar
{
    /// <summary>
    /// Interaction logic for SidebarView.xaml
    /// </summary>
    public partial class SidebarView
    {
        public SidebarView()
        {
            InitializeComponent();
        }

        public void ShowPageSettings(UIPage page)
        {
            TitleTextBlock.Text = "Page";

            // SidebarPanel.Children.Clear();

            TextBoxMarginTop.DataContext = page.Settings;
            TextBoxMarginTop.SetBinding(TextBox.TextProperty, new Binding("MarginTop"));
            TextBoxStaffSpacing.DataContext = page.Settings;
            TextBoxStaffSpacing.SetBinding(TextBox.TextProperty, new Binding("StaffSpacing"));
            TextBoxSystemSpacing.DataContext = page.Settings;
            TextBoxSystemSpacing.SetBinding(TextBox.TextProperty, new Binding("SystemSpacing"));
            TextBoxLeftMargin.DataContext = page.Settings;
            TextBoxLeftMargin.SetBinding(TextBox.TextProperty, new Binding("SystemMarginLeft"));
            TextBoxRightMargin.DataContext = page.Settings;
            TextBoxRightMargin.SetBinding(TextBox.TextProperty, new Binding("SystemMarginRight"));


            //var grid = new GridTable(120);
            //grid.AddRowWithTextField("Top Margin", page.Settings, "MarginTop");
            //grid.AddRowWithTextField("Staff Spacing", page.Settings, "StaffSpacing");
            //grid.AddRowWithTextField("System Spacing", page.Settings, "SystemSpacing");
            //grid.AddRowWithTextField("Left Margin", page.Settings, "SystemMarginLeft");
            //grid.AddRowWithTextField("Right Margin", page.Settings, "SystemMarginRight");
            //SidebarPanel.Children.Add(grid);
        }
    }
}
