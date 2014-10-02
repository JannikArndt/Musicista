using System.Windows.Controls;

namespace Musicista.TinyEditor
{
    /// <summary>
    /// Interaction logic for TinyEditor.xaml
    /// </summary>
    public partial class TinyEditor
    {
        public TinyEditor()
        {
            InitializeComponent();
        }

        private void InputTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var passage = TinyNotation.ParseTinyNotation(((TextBox)sender).Text);
            PreviewCanvas.Children.Clear();
            PreviewCanvas.Children.Add(Sidebar.SidebarHelper.DrawPassage(passage));
        }
    }
}
