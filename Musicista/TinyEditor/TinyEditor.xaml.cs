using Model.Sections;
using Musicista.UI;
using System.Linq;
using System.Windows;
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
            PreviewCanvas.Children.Add(DrawPassage(passage));
        }

        public static UIPage DrawPassage(Passage passage)
        {
            var page = new UIPage(hasMouseDown: false)
            {
                Width = 550,
                Height = 100,
                HorizontalAlignment = HorizontalAlignment.Center,
                Effect = null,
                Settings = new UISettings
                {
                    MarginTop = 10,
                    MarginBelowTitle = 0,
                    StaffSpacing = 0,
                    SystemSpacing = 0,
                    SystemMarginLeft = 0,
                    SystemMarginRight = 0
                }
            };

            if (passage == null) return page;

            page.Systems.Add(new UISystem(page, 1, 1, passage.MeasureGroups.Count));

            foreach (var measureGroup in passage.MeasureGroups)
            {
                var uiMeasureGroup = new UIMeasureGroup(page.Systems.Last(), measureGroup, false);
                uiMeasureGroup.Draw();
            }

            return page;
        }
    }
}
