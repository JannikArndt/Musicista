
using Model;
using Model.Sections;
using Model.View;
using Musicista.Exceptions;
using Musicista.UI;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Musicista.Sidebar
{
    public static class SidebarHelper
    {
        public static void DrawPartBox(Part part, Panel stackPanel)
        {
            if (String.IsNullOrEmpty(part.Name))
                part.Name = "Part #" + (MainWindow.CurrentPiece.Parts.IndexOf(part) + 1);

            var namePanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 4, 0, 0),
                Width = 280,
            };

            var partTitle = new EditableTextBox
            {
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 160,
                DataContext = part
            };
            partTitle.SetBinding(TextBox.TextProperty, new Binding("Name"));

            var partStartAndEnd = new TextBlock
            {
                FontSize = 12,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                Width = 90,
                Text = "(" + part.Start + "-" + part.End + ")"
            };

            var deleteArea = new Border
            {
                Background = Brushes.Transparent,
                Margin = new Thickness(10, 10, 0, 0)
            };
            var deleteButton = new Path
            {
                Data = Geometry.Parse("F0 M 16,8 C 16,12 12,16 8,16 C 4,16 0,12 0,8 C 0,4 4,0 8,0 C 12,0 16,4 16,8 Z M 4,3 L 3,4 L 7,8 L 3,12 L 4,13 L 8,9 L 12,13 L 13,12 L 9,8 L 13,4 L 12,3 L 8,7 L 4,3 Z "),
                Fill = Brushes.LightGray,
                RenderTransform = new ScaleTransform(0.9, 0.9)
            };

            var preview = DrawPassage(part.Passage);
            preview.MouseDown += delegate
            {
                try
                {
                    UIHelper.SelectPassageInScore(part.Start, part.End);
                }
                catch (GUIException exception)
                {
                    MessageBox.Show(exception.Message, "Error");
                }
            };
            deleteArea.Child = deleteButton;

            namePanel.Children.Add(partTitle);
            namePanel.Children.Add(partStartAndEnd);
            namePanel.Children.Add(deleteArea);

            deleteArea.MouseEnter += (sender, args) => deleteButton.Fill = Brushes.Gray;
            deleteArea.MouseLeave += (sender, args) => deleteButton.Fill = Brushes.LightGray;
            deleteArea.MouseDown += delegate { DeletePart(part, stackPanel, namePanel, preview); };

            stackPanel.Children.Add(namePanel);
            stackPanel.Children.Add(preview);
        }

        public static UISystem DrawPassage(Passage passage)
        {
            if (passage == null) return null;
            var metrics = new Metrics(280, 50, 0, 10);

            var uiSystem = new UISystem(metrics, 1, 1, passage.MeasureGroups.Count) { Height = 60, Background = Brushes.White, Margin = new Thickness(0, 30, 0, 0) };
            uiSystem.Children.Add(new Rectangle { Width = 280, Height = 30, Fill = Brushes.White, Margin = new Thickness(0, -30, 0, 0) });

            foreach (var measureGroup in passage.MeasureGroups)
                new UIMeasureGroup(uiSystem, measureGroup, false);

            return uiSystem;
        }

        public static void DeletePart(Part part, Panel partsStack, StackPanel namePanel, Canvas preview)
        {
            MainWindow.CurrentPiece.Parts.Remove(part);
            partsStack.Children.Remove(namePanel);
            partsStack.Children.Remove(preview);
        }
    }
}
