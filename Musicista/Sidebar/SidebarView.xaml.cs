using Musicista.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

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

            TextBoxMarginTop.DataContext = page.Settings;
            TextBoxMarginTop.SetBinding(TextBox.TextProperty, new Binding("MarginTop"));
            TextBoxMarginTop.KeyDown += AdvanceFocusAndReturn;

            TextBoxStaffSpacing.DataContext = page.Settings;
            TextBoxStaffSpacing.SetBinding(TextBox.TextProperty, new Binding("StaffSpacing"));
            TextBoxStaffSpacing.KeyDown += AdvanceFocusAndReturn;

            TextBoxSystemSpacing.DataContext = page.Settings;
            TextBoxSystemSpacing.SetBinding(TextBox.TextProperty, new Binding("SystemSpacing"));
            TextBoxSystemSpacing.KeyDown += AdvanceFocusAndReturn;

            TextBoxLeftMargin.DataContext = page.Settings;
            TextBoxLeftMargin.SetBinding(TextBox.TextProperty, new Binding("SystemMarginLeft"));
            TextBoxLeftMargin.KeyDown += AdvanceFocusAndReturn;

            TextBoxRightMargin.DataContext = page.Settings;
            TextBoxRightMargin.SetBinding(TextBox.TextProperty, new Binding("SystemMarginRight"));
            TextBoxRightMargin.KeyDown += AdvanceFocusAndReturn;

            MeasuresPerSystemThresholdSlider.DataContext = MainWindow.CurrentPiece.Style.MetricForMovement[0];
            MeasuresPerSystemThresholdSlider.SetBinding(RangeBase.ValueProperty, new Binding("MeasuresPerSystemThreshold"));
        }

        private static void AdvanceFocusAndReturn(object sender, KeyEventArgs args)
        {
            if (args.Key != Key.Return) return;
            var textBox = sender as TextBox;
            if (textBox == null) return;

            textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            textBox.Focus();
        }

        private void ButtonRedrawClick(object sender, RoutedEventArgs e)
        {
            MainWindow.PageList = UIHelper.DrawPiece(MainWindow.CurrentPiece, true);

            var pages = new StackPanel();
            foreach (var newpage in MainWindow.PageList)
                pages.Children.Add(newpage);
            pages.Children.Add(new Canvas { Height = 200 });
            MainWindow.UICanvasScrollViewer.Content = pages;
        }
    }
}
