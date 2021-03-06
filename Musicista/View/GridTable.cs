﻿using Model;
using Model.Instruments;
using Model.Meta.People;
using Model.Sections;
using Model.Sections.Notes;
using Musicista.Sidebar;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.View
{
    /// <summary>
    /// A two column grid that offers custom functions for adding rows
    /// </summary>
    public class GridTable : Grid
    {
        public readonly int LeftColumnWidth = 60;

        /// <summary>
        /// Create a new GridTable with two columns.
        /// </summary>
        /// <param name="columnOneWidth">Width of the left colum</param>
        public GridTable(int columnOneWidth)
        {
            LeftColumnWidth = columnOneWidth;
            Margin = new Thickness(10);

            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(columnOneWidth) });
            ColumnDefinitions.Add(new ColumnDefinition());
        }

        /// <summary>
        /// Add a row to the GridTable with a TextField and binding to a property.
        /// </summary>
        /// <param name="key">The label in the left colum</param>
        /// <param name="dataContext">The bound object</param>
        /// <param name="propertyName">Name of the bound property</param>
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
                Width = 260 - LeftColumnWidth,
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

        /// <summary>
        /// Add a row to the GridTable with a TestField that can only be read and has no binding.
        /// </summary>
        /// <param name="key">The label in the left colum</param>
        /// <param name="text">Content of the TextField</param>
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

        /// <summary>
        /// Add a row to the GridTable with the name of a Person and buttons for editing and deleting.
        /// </summary>
        /// <param name="key">The label in the left colum</param>
        /// <param name="person">The person that is displayed</param>
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

            var personTextBlock = new TextBlock
            {
                Text = person.FullName,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            personTextBlock.PreviewMouseDown += (sender, args) =>
            {
                var editPersonWindow = new EditPerson(person);
                editPersonWindow.Show();
            };


            var editTextBlock = new TextBlock
            {
                Text = "(e)",
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center
            };
            editTextBlock.PreviewMouseDown += (sender, args) =>
            {
                var editPersonWindow = new EditPerson(person);
                editPersonWindow.Show();
            };

            var deleteButton = new Path
            {
                Data = Geometry.Parse("F0 M 15,7C 15,11 12,15 8,15C 3,15 0,11 0,7C 0,3 3,0 8,0C 12,0 15,3 15,7 Z M 4,2L 8,5L 11,2L 12,4L 9,7L 12,10L 11,12L 8,9L 4,12L 3,10L 6,7L 3,4L 4,2 Z"),
                Fill = Brushes.LightGray,
                RenderTransform = new ScaleTransform(0.9, 0.9),
                VerticalAlignment = VerticalAlignment.Center
            };
            deleteButton.PreviewMouseDown += (sender, args) =>
            {
                if (person.GetType() == typeof(Composer))
                    MainWindow.CurrentPiece.Meta.People.Persons.Remove(person);
                MainWindow.SidebarInformation.ShowPiece();
                if (MainWindow.PageList.Count > 0)
                    MainWindow.PageList[0].Composer.Text = MainWindow.CurrentPiece.Meta.People.ComposersAsString;
            };

            var nameGrid = new Grid { Width = 260 - LeftColumnWidth };
            nameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength() });
            nameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
            nameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
            SetColumn(personTextBlock, 0);
            SetColumn(editTextBlock, 1);
            SetColumn(deleteButton, 2);

            nameGrid.Children.Add(personTextBlock);
            nameGrid.Children.Add(editTextBlock);
            nameGrid.Children.Add(deleteButton);

            SetRow(nameGrid, RowDefinitions.Count - 1);
            SetColumn(nameGrid, 1);

            Children.Add(keyTextBlock);
            Children.Add(nameGrid);
        }

        /// <summary>
        /// Add a row to the GridTable with a "+ add Person" text
        /// </summary>
        /// <param name="persons">The list of persons the new person would be added to</param>
        public void AddRowWithAddPerson(List<Person> persons)
        {
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });


            var personTextBlock = new TextBlock
            {
                Text = "+ add Person",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            personTextBlock.PreviewMouseDown += (sender, args) =>
            {
                var newPerson = new Person();
                persons.Add(newPerson);
                var editPersonWindow = new EditPerson(newPerson);
                editPersonWindow.Show();
            };
            SetRow(personTextBlock, RowDefinitions.Count - 1);
            SetColumn(personTextBlock, 1);
            Children.Add(personTextBlock);
        }

        /// <summary>
        /// Add a row to the GridTable with a ComboBox and a binding to an enum
        /// </summary>
        /// <param name="key">The label in the left column</param>
        /// <param name="dataContext">The object that holds the property</param>
        /// <param name="propertyName">The name of the bound property, whcih will be selected in the ComboBox</param>
        /// <param name="enumType">The items in the ComboBox</param>
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

        /// <summary>
        /// Add a row to the GridTable with two ComboBoxes
        /// </summary>
        /// <param name="key">The label in the left column</param>
        /// <param name="dataContext">The object that hold both properties</param>
        /// <param name="property1Name">The name of the first property</param>
        /// <param name="property2Name">The name of the econd property</param>
        /// <param name="enum1Type">The items in the first ComboBox</param>
        /// <param name="enum2Type">The items in the second ComboBox</param>
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

        /// <summary>
        /// Add a row to the GridTable with a TimeSignature
        /// </summary>
        /// <param name="key">The label in the left column</param>
        /// <param name="dataContext">The timesignature object</param>
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

        /// <summary>
        /// Add a row to the GridTable with a Checkbox.
        /// </summary>
        /// <param name="key">The label in the left colum</param>
        /// <param name="dataContext">the object that holds the property</param>
        /// <param name="propertyName">The name of the property</param>
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

        /// <summary>
        /// Add a row to the GridTable with a Comment
        /// </summary>
        /// <param name="referenceSymbol"></param>
        public void AddRowWithCommentBox(Symbol referenceSymbol)
        {
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });

            var keyTextBlock = new TextBlock
            {
                Text = Properties.Settings.Default.Username + ":",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            SetRow(keyTextBlock, RowDefinitions.Count - 1);
            SetColumn(keyTextBlock, 0);

            var valueTextBox = new TextBox
            {
                Width = 210 - LeftColumnWidth,
                Height = 26,
                Padding = new Thickness(3),
                Margin = new Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            SetRow(valueTextBox, RowDefinitions.Count - 1);
            SetColumn(valueTextBox, 1);

            Children.Add(keyTextBlock);
            Children.Add(valueTextBox);

            var addCommentButton = new Button
            {
                Content = "Add",
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 26,
                Padding = new Thickness(1),
                Margin = new Thickness(1, 1, 18, 1),
                Width = 40
            };
            addCommentButton.Click += delegate
            {
                var comment = new Comment(valueTextBox.Text, referenceSymbol, referenceSymbol.ParentMeasure.ParentMeasureGroup.ParentPassage.ParentSegment.ParentMovement, Properties.Settings.Default.Username);
                MainWindow.CurrentPiece.Comments.Add(comment);
            };

            SetRow(addCommentButton, RowDefinitions.Count - 1);
            SetColumn(addCommentButton, 1);
            Children.Add(addCommentButton);
        }

        /// <summary>
        /// Add a row to the GridTable with an "Edit Instruments" button
        /// </summary>
        /// <param name="list">The list of instrumentgroups</param>
        public void AddRowWithInstruments(List<InstrumentGroup> list)
        {
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });

            var editInstrumentsButton = new Button
            {
                Content = "Edit Instruments",
                Width = 150,
                Height = 20,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            }; ;
            editInstrumentsButton.PreviewMouseDown += (sender, args) =>
            {
                MainWindow.UISidebar.Content = new SidebarInstruments();
            };
            SetRow(editInstrumentsButton, RowDefinitions.Count - 1);
            SetColumn(editInstrumentsButton, 1);
            Children.Add(editInstrumentsButton);
        }

        /// <summary>
        /// Add a row to the GridTable with an Instrument
        /// </summary>
        /// <param name="measure"></param>
        public void AddRowWithInstrument(Measure measure)
        {
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });

            var keyTextBlock = new TextBlock
            {
                Text = "Instrument",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            SetRow(keyTextBlock, RowDefinitions.Count - 1);
            SetColumn(keyTextBlock, 0);

            var instrumentTextBlock = new TextBlock
            {
                Text = measure.Instrument.Name,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(3, 0, 0, 0)
            };
            SetRow(instrumentTextBlock, RowDefinitions.Count - 1);
            SetColumn(instrumentTextBlock, 1);

            var editInstrumentButton = new Button
            {
                Content = "Edit",
                Width = 50,
                Height = 20,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 19, 0)
            };
            SetRow(editInstrumentButton, RowDefinitions.Count - 1);
            SetColumn(editInstrumentButton, 1);
            editInstrumentButton.PreviewMouseDown += (sender, args) =>
            {
                MainWindow.UISidebar.Content = new SidebarInstruments();
            };

            Children.Add(keyTextBlock);
            Children.Add(instrumentTextBlock);
            Children.Add(editInstrumentButton);
        }
    }
}
