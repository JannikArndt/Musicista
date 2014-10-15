using Musicista.TinyEditor;
using Musicista.UI;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Musicista
{
    public partial class MainWindow
    {
        /// <summary>
        /// Called when the text inside the TinyNotationBox is changed, updates the correponding measure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TinyNotationBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedTool != ToolKind.Edit || UIHelper.SelectedUIMeasures.Count == 0 || UIHelper.SelectedUIMeasures.First() == null || !UpdateTinyNotationBox)
                return;

            var measure = UIHelper.SelectedUIMeasures.First().InnerMeasure;
            measure.Symbols = TinyNotation.ParseTinyNotation(TinyNotationBox.Text, measure);
            UIHelper.SelectedUIMeasures.First().ParentUIMeasureGroup.Redraw();
        }

        /// <summary>
        /// Toggle Help button visibility
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TinyNotationHelpButton_OnClick(object sender, RoutedEventArgs e)
        {
            TinyNotationHelp.Visibility = TinyNotationHelp.Visibility == Visibility.Collapsed
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        /// <summary>
        /// Check if the enter key is hit inside the TinyNotationBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TinyNotationBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && UIHelper.SelectedUIMeasures.Count > 0)
            {
                var nextSelectedMeasure = UIHelper.SelectedUIMeasures.First().NextUIMeasure;
                if (nextSelectedMeasure == null)
                {
                    UIHelper.SelectedUIMeasures.First().ParentUIMeasureGroup.AddMeasureGroup(null, null);
                    var part = UIHelper.SelectedUIMeasures.First().ParentUIMeasureGroup.UIMeasures.IndexOf(UIHelper.SelectedUIMeasures.First());
                    nextSelectedMeasure = PageList.Last().Systems.Last().UIMeasureGroups.Last().UIMeasures[part];
                }
                UIHelper.UnselectAll();
                nextSelectedMeasure.Background = UIHelper.SelectColor;
                UIHelper.SelectedUIMeasures.Add(nextSelectedMeasure);

                UpdateTinyNotationBox = false;
                TinyNotationTextBox.Text = TinyNotation.CreateTinyNotation(nextSelectedMeasure.InnerMeasure);
                UpdateTinyNotationBox = true;
            }
        }

        /// <summary>
        /// Insert closing paranthesis and brackets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TinyNotationBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var caret = TinyNotationBox.CaretIndex;
            switch (e.Text)
            {
                case "(":
                    TinyNotationTextBox.Text = TinyNotationTextBox.Text.Insert(caret, "()");
                    TinyNotationTextBox.CaretIndex = caret + 1;
                    e.Handled = true;
                    break;
                case "[":
                    TinyNotationTextBox.Text = TinyNotationTextBox.Text.Insert(caret, "[]");
                    TinyNotationTextBox.CaretIndex = caret + 1;
                    e.Handled = true;
                    break;
            }
        }
    }
}
