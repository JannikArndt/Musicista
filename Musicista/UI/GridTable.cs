using Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace Musicista.UI
{
    public class GridTable : Grid
    {
        public GridTable(int columnOneWidth)
        {
            Margin = new Thickness(10);

            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(columnOneWidth) });
            ColumnDefinitions.Add(new ColumnDefinition());

        }

        public void AddRowWithTextField(string key, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException(@"No property name given", propertyName);
            if (MainWindow.CurrentPiece.GetType().GetProperty(propertyName) == null)
                throw new Exception("Property " + propertyName + " not found in piece.");


            RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });

            var keyTextBlock = new TextBlock
            {
                Text = key,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            SetRow(keyTextBlock, RowDefinitions.Count - 1);
            SetColumn(keyTextBlock, 0);

            var valueTextBox = new TextBox
            {
                DataContext = MainWindow.CurrentPiece,
                Width = 200,
                Height = 26,
                Padding = new Thickness(3),
                Margin = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            valueTextBox.SetBinding(TextBox.TextProperty, new Binding(propertyName));
            SetRow(valueTextBox, RowDefinitions.Count - 1);
            SetColumn(valueTextBox, 1);

            Children.Add(keyTextBlock);
            Children.Add(valueTextBox);
        }

        public void AddRowWithPerson(string key, Person person)
        {
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });

            var keyTextBlock = new TextBlock
            {
                Text = key,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            SetRow(keyTextBlock, RowDefinitions.Count - 1);
            SetColumn(keyTextBlock, 0);

            var firstName = new TextBox
            {
                DataContext = person,
                Width = 78,
                Height = 26,
                Padding = new Thickness(3),
                Margin = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            firstName.SetBinding(TextBox.TextProperty, new Binding("FirstName"));
            var middleName = new TextBox
            {
                DataContext = person,
                Width = 38,
                Height = 26,
                Padding = new Thickness(3),
                Margin = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            middleName.SetBinding(TextBox.TextProperty, new Binding("MiddleName"));
            var lastName = new TextBox
            {
                DataContext = person,
                Width = 78,
                Height = 26,
                Padding = new Thickness(3),
                Margin = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            lastName.SetBinding(TextBox.TextProperty, new Binding("LastName"));

            var stackpanel = new StackPanel { Orientation = Orientation.Horizontal };
            stackpanel.Children.Add(firstName);
            stackpanel.Children.Add(middleName);
            stackpanel.Children.Add(lastName);


            SetRow(stackpanel, RowDefinitions.Count - 1);
            SetColumn(stackpanel, 1);

            Children.Add(keyTextBlock);
            Children.Add(stackpanel);
        }

        public void AddRowWithComboBox(string key, string propertyName, Enum enumType)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException(@"No property name given", propertyName);
            if (MainWindow.CurrentPiece.GetType().GetProperty(propertyName) == null)
                throw new Exception("Property " + propertyName + " not found in piece.");


            RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });

            var keyTextBlock = new TextBlock
            {
                Text = key,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            SetRow(keyTextBlock, RowDefinitions.Count - 1);
            SetColumn(keyTextBlock, 0);

            var valueComboBox = new ComboBox
            {
                DataContext = MainWindow.CurrentPiece,
                Width = 200,
                Height = 26,
                Padding = new Thickness(3),
                Margin = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                ItemsSource = Enum.GetValues(enumType.GetType())
            };

            valueComboBox.SetBinding(Selector.SelectedItemProperty, propertyName);

            SetRow(valueComboBox, RowDefinitions.Count - 1);
            SetColumn(valueComboBox, 1);

            Children.Add(keyTextBlock);
            Children.Add(valueComboBox);
        }
    }
}
