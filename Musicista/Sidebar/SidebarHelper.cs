
using Model;
using Model.Sections;
using Musicista.Exceptions;
using Musicista.UI;
using System;
using System.Linq;
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
                Margin = new Thickness(10, 4, 0, -18),
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
                Data = Geometry.Parse("F0 M 15,7C 15,11 12,15 8,15C 3,15 0,11 0,7C 0,3 3,0 8,0C 12,0 15,3 15,7 Z M 4,2L 8,5L 11,2L 12,4L 9,7L 12,10L 11,12L 8,9L 4,12L 3,10L 6,7L 3,4L 4,2 Z"),
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

        public static UIPage DrawPassage(Passage passage)
        {
            var page = new UIPage(hasMouseDown: false)
            {
                Width = 280,
                Height = 50,
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

        public static void DeletePart(Part part, Panel partsStack, StackPanel namePanel, Canvas preview)
        {
            MainWindow.CurrentPiece.Parts.Remove(part);
            partsStack.Children.Remove(namePanel);
            partsStack.Children.Remove(preview);
        }
    }
}
