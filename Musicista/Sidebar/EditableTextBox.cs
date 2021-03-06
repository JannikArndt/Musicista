﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Musicista.Sidebar
{
    /// <summary>
    /// Represents a TextBox whose background is only visible if it has focus
    /// </summary>
    public class EditableTextBox : TextBox
    {
        public EditableTextBox()
        {
            EditModeOff();

            GotFocus += EditModeOn;
            LostFocus += EditModeOff;
            LostKeyboardFocus += EditModeOff;
        }

        private void EditModeOn(object sender, RoutedEventArgs e)
        {
            Background = Brushes.White;
            BorderBrush = Brushes.DeepSkyBlue;
        }

        private void EditModeOff(object sender = null, RoutedEventArgs e = null)
        {
            Background = Brushes.Transparent;
            BorderBrush = Brushes.Transparent;
        }
    }
}
