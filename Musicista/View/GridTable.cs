using Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using Model.Meta.People;

namespace Musicista.View
{
    public class GridTable : Grid
    {
        readonly int _leftColumnWidth = 60;
        public GridTable(int columnOneWidth)
        {
            _leftColumnWidth = columnOneWidth;
            Margin = new Thickness(10);

            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(columnOneWidth) });
            ColumnDefinitions.Add(new ColumnDefinition());
        }

        public void AddRowWithTextField(string key, object dataContext, string propertyName)
        {
            if (dataContext == null)
                throw new ArgumentException(@"No data context given", "dataContext");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException(@"No property name given", "propertyName");
            if (dataContext.GetType().GetProperty(propertyName) == null)
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
                DataContext = dataContext,
                Width = 260 - _leftColumnWidth,
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

        public void AddRowWithReadonlyTextField(string key, string text)
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

            var valueTextBox = new TextBox
            {
                Text = text,
                Width = 200,
                Height = 26,
                Padding = new Thickness(3),
                Margin = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                IsReadOnly = true
            };
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

        public void AddRowWithComboBox(string key, object dataContext, string propertyName, Enum enumType)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException(@"No property name given", propertyName);
            if (dataContext.GetType().GetProperty(propertyName) == null)
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
                DataContext = dataContext,
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

        public void AddRowWithTwoComboBoxes(string key, object dataContext, string property1Name, string property2Name, Enum enum1Type, Enum enum2Type)
        {
            if (string.IsNullOrEmpty(property1Name))
                throw new ArgumentException(@"No property name given", property1Name);
            if (string.IsNullOrEmpty(property2Name))
                throw new ArgumentException(@"No property name given", property2Name);
            if (dataContext.GetType().GetProperty(property1Name) == null)
                throw new Exception("Property " + property1Name + " not found in piece.");
            if (dataContext.GetType().GetProperty(property2Name) == null)
                throw new Exception("Property " + property2Name + " not found in piece.");


            RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });

            var keyTextBlock = new TextBlock
            {
                Text = key,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            SetRow(keyTextBlock, RowDefinitions.Count - 1);
            SetColumn(keyTextBlock, 0);

            var value1ComboBox = new ComboBox
            {
                DataContext = dataContext,
                Width = 90,
                Height = 26,
                Padding = new Thickness(3),
                Margin = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                ItemsSource = Enum.GetValues(enum1Type.GetType())
            };

            value1ComboBox.SetBinding(Selector.SelectedItemProperty, property1Name);

            var value2ComboBox = new ComboBox
            {
                DataContext = dataContext,
                Width = 100,
                Height = 26,
                Padding = new Thickness(3),
                Margin = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                ItemsSource = Enum.GetValues(enum2Type.GetType())
            };

            value2ComboBox.SetBinding(Selector.SelectedItemProperty, property2Name);

            var stackpanel = new StackPanel { Orientation = Orientation.Horizontal };
            stackpanel.Children.Add(value1ComboBox);
            stackpanel.Children.Add(value2ComboBox);


            SetRow(stackpanel, RowDefinitions.Count - 1);
            SetColumn(stackpanel, 1);

            Children.Add(keyTextBlock);
            Children.Add(stackpanel);
        }

        public void AddRowWithTimeSignature(string key, object dataContext)
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

            var value1TextBox = new TextBox
            {
                DataContext = dataContext,
                Width = 30,
                Height = 26,
                Padding = new Thickness(3),
                Margin = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            value1TextBox.SetBinding(TextBox.TextProperty, new Binding("Beats"));


            var value2TextBox = new TextBox
            {
                DataContext = dataContext,
                Width = 30,
                Height = 26,
                Padding = new Thickness(3),
                Margin = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            value2TextBox.SetBinding(TextBox.TextProperty, new Binding("BeatUnit"));

            var commonCheckBox = new CheckBox
            {
                DataContext = dataContext,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            commonCheckBox.SetBinding(ToggleButton.IsCheckedProperty, new Binding("IsCommon"));

            var cutCheckBox = new CheckBox
            {
                DataContext = dataContext,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            cutCheckBox.SetBinding(ToggleButton.IsCheckedProperty, new Binding("IsCutCommon"));

            var stackpanel = new StackPanel { Orientation = Orientation.Horizontal };
            stackpanel.Children.Add(value1TextBox);
            stackpanel.Children.Add(new TextBlock { Text = " / ", VerticalAlignment = VerticalAlignment.Center });
            stackpanel.Children.Add(value2TextBox);
            stackpanel.Children.Add(new TextBlock { Text = " Common: ", VerticalAlignment = VerticalAlignment.Center });
            stackpanel.Children.Add(commonCheckBox);
            stackpanel.Children.Add(new TextBlock { Text = " Cut: ", VerticalAlignment = VerticalAlignment.Center });
            stackpanel.Children.Add(cutCheckBox);

            SetRow(stackpanel, RowDefinitions.Count - 1);
            SetColumn(stackpanel, 1);

            Children.Add(keyTextBlock);
            Children.Add(stackpanel);
        }

        public void AddRowWithCheckbox(string key, object dataContext, string propertyName)
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

            var valueCheckBox = new CheckBox
            {
                DataContext = dataContext,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            valueCheckBox.SetBinding(ToggleButton.IsCheckedProperty, new Binding(propertyName));

            SetRow(valueCheckBox, RowDefinitions.Count - 1);
            SetColumn(valueCheckBox, 1);

            Children.Add(keyTextBlock);
            Children.Add(valueCheckBox);
        }
    }
}
