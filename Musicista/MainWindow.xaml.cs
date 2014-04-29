using Model;
using Model.Meta;
using Musicista.Sidebar;
using Musicista.UI;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Musicista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseWheel += Zoom;

            Sidebar.Content = new SidebarInformation();

            var page1 = UIHelper.CreatePage();
            var page2 = UIHelper.CreatePage();

            var pages = new StackPanel();
            pages.Children.Add(page1);
            pages.Children.Add(page2);
            pages.Children.Add(new Canvas { Height = 200 });

            CanvasScrollViewer.Content = pages;


            UIHelper.DrawTitle("7. Sinfonie", page1);
            UIHelper.DrawComposer("Ludwig v. Beethoven", page1);

            var Staff1 = UIHelper.DrawStaff(page1, 200);
            var Staff2 = UIHelper.DrawStaff(page1, 300);
            var Staff3 = UIHelper.DrawStaff(page1, 400);
            var Staff4 = UIHelper.DrawStaff(page1, 500);
            var Staff5 = UIHelper.DrawStaff(page1, 600);
            var Staff6 = UIHelper.DrawStaff(page1, 700);
            var Staff7 = UIHelper.DrawStaff(page1, 800);

            UIHelper.DrawTrebleClef(page1, Staff1);

            var m1 = new Measure
            {
                TimeSignature = new TimeSignature(4, 4),
                Parts = new List<Part>{
                    new Part{
                        ListOfSymbols = new List<Symbol>
                        {
                             new Note { Beat = 1, Step = Pitch.C, Octave = 4, Duration = Model.Duration.quarter },
                             new Note { Beat = 2, Step = Pitch.C, Octave = 4, Duration = Model.Duration.quarter },
                             new Note { Beat = 3, Step = Pitch.C, Octave = 4, Duration = Model.Duration.quarter },
                             new Note { Beat = 4, Step = Pitch.C, Octave = 4, Duration = Model.Duration.quarter }
                        }
                    }
                }
            };
            var m2 = new Measure
            {
                TimeSignature = new TimeSignature(4, 4),
                Parts = new List<Part>{
                    new Part{
                        ListOfSymbols = new List<Symbol>
                        {
                             new Note { Beat = 1, Step = Pitch.D, Octave = 4, Duration = Model.Duration.eigth },
                             new Note { Beat = 1.25, Step = Pitch.D, Octave = 4, Duration = Model.Duration.eigth },
                             new Note { Beat = 1.5, Step = Pitch.D, Octave = 4, Duration = Model.Duration.eigth },
                             new Note { Beat = 1.75, Step = Pitch.D, Octave = 4, Duration = Model.Duration.eigth },
                             new Rest { Beat = 2, Duration = Model.Duration.quarter},
                             new Rest { Beat = 2, Duration = Model.Duration.half}
                        }
                    }
                }
            };
            var m3 = new Measure
            {
                TimeSignature = new TimeSignature(4, 4),
                Parts = new List<Part>{
                    new Part{
                        ListOfSymbols = new List<Symbol>
                        {
                             new Rest { Beat = 1, Duration = Model.Duration.whole}
                        }
                    }
                }
            };





            UIMeasure uim1 = UIHelper.DrawMeasure(page1, Staff1, m1);
            UIMeasure uim2 = UIHelper.DrawMeasure(page1, Staff1, m2);
            UIMeasure uim3 = UIHelper.DrawMeasure(page1, Staff1, m3);
            UIMeasure uim4 = UIHelper.DrawMeasure(page1, Staff1, m3);
            UIMeasure uim5 = UIHelper.DrawMeasure(page1, Staff2, m3);
            UIMeasure uim6 = UIHelper.DrawMeasure(page1, Staff2, m3);

            Note note1 = new Note { Beat = 1.00, Step = Pitch.D, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note2 = new Note { Beat = 1.25, Step = Pitch.DSharp, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note3 = new Note { Beat = 1.50, Step = Pitch.E, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note4 = new Note { Beat = 1.75, Step = Pitch.F, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note5 = new Note { Beat = 2.00, Step = Pitch.G, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note6 = new Note { Beat = 2.25, Step = Pitch.A, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note7 = new Note { Beat = 2.50, Step = Pitch.ASharp, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note8 = new Note { Beat = 2.75, Step = Pitch.BFlat, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note9 = new Note { Beat = 3.00, Step = Pitch.B, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note10 = new Note { Beat = 3.25, Step = Pitch.D, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note11 = new Note { Beat = 3.50, Step = Pitch.D, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note12 = new Note { Beat = 3.75, Step = Pitch.D, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note13 = new Note { Beat = 4.00, Step = Pitch.D, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note14 = new Note { Beat = 4.25, Step = Pitch.D, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note15 = new Note { Beat = 4.50, Step = Pitch.D, Octave = 4, Duration = Model.Duration.sixteenth };
            Note note16 = new Note { Beat = 4.75, Step = Pitch.D, Octave = 4, Duration = Model.Duration.sixteenth };

            Note note20 = new Note { Beat = 1.00, Step = Pitch.C, Octave = 4, Duration = Model.Duration.eigth };
            Note note21 = new Note { Beat = 1.50, Step = Pitch.D, Octave = 3, Duration = Model.Duration.eigth };
            Note note22 = new Note { Beat = 2.00, Step = Pitch.E, Octave = 5, Duration = Model.Duration.eigth };
            Note note23 = new Note { Beat = 2.50, Step = Pitch.F, Octave = 2, Duration = Model.Duration.eigth };
            Note note24 = new Note { Beat = 3.00, Step = Pitch.FSharp, Octave = 4, Duration = Model.Duration.eigth };
            Note note25 = new Note { Beat = 3.50, Step = Pitch.GFlat, Octave = 4, Duration = Model.Duration.eigth };
            Note note26 = new Note { Beat = 4.00, Step = Pitch.A, Octave = 6, Duration = Model.Duration.eigth };
            Note note27 = new Note { Beat = 4.50, Step = Pitch.B, Octave = 7, Duration = Model.Duration.eigth };

            Note note30 = new Note { Beat = 1, Step = Pitch.C, Octave = 5, Duration = Model.Duration.quarter };
            Note note31 = new Note { Beat = 2, Step = Pitch.D, Octave = 5, Duration = Model.Duration.quarter };
            Note note32 = new Note { Beat = 3, Step = Pitch.FSharp, Octave = 5, Duration = Model.Duration.quarter };
            Note note33 = new Note { Beat = 4, Step = Pitch.B, Octave = 5, Duration = Model.Duration.quarter };

            Note note40 = new Note { Beat = 1, Step = Pitch.D, Octave = 4, Duration = Model.Duration.half };
            Note note41 = new Note { Beat = 3, Step = Pitch.D, Octave = 5, Duration = Model.Duration.half };

            Note note50 = new Note { Beat = 1, Step = Pitch.D, Octave = 4, Duration = Model.Duration.whole };

            UIHelper.DrawNote(page1, note50, uim1);

            UIHelper.DrawNote(page1, note40, uim2);
            UIHelper.DrawNote(page1, note41, uim2);

            UIHelper.DrawNote(page1, note30, uim3);
            UIHelper.DrawNote(page1, note31, uim3);
            UIHelper.DrawNote(page1, note32, uim3);
            UIHelper.DrawNote(page1, note33, uim3);

            UIHelper.DrawNote(page1, note20, uim4);
            UIHelper.DrawNote(page1, note21, uim4);
            UIHelper.DrawNote(page1, note22, uim4);
            UIHelper.DrawNote(page1, note23, uim4);
            UIHelper.DrawNote(page1, note24, uim4);
            UIHelper.DrawNote(page1, note25, uim4);
            UIHelper.DrawNote(page1, note26, uim4);
            UIHelper.DrawNote(page1, note27, uim4);

            UIHelper.DrawNote(page1, note1, uim5);
            UIHelper.DrawNote(page1, note2, uim5);
            UIHelper.DrawNote(page1, note3, uim5);
            UIHelper.DrawNote(page1, note4, uim5);
            UIHelper.DrawNote(page1, note5, uim5);
            UIHelper.DrawNote(page1, note6, uim5);
            UIHelper.DrawNote(page1, note7, uim5);
            UIHelper.DrawNote(page1, note8, uim5);
            UIHelper.DrawNote(page1, note9, uim5);
            UIHelper.DrawNote(page1, note10, uim5);
            UIHelper.DrawNote(page1, note11, uim5);
            UIHelper.DrawNote(page1, note12, uim5);
            UIHelper.DrawNote(page1, note13, uim5);
            UIHelper.DrawNote(page1, note14, uim5);
            UIHelper.DrawNote(page1, note15, uim5);
            UIHelper.DrawNote(page1, note16, uim5);

        }

        private void ShowCollection(object sender, RoutedEventArgs e)
        {
        }
        private void SelectToolAdd(object sender, RoutedEventArgs e)
        {
        }
        private void SelectToolEdit(object sender, RoutedEventArgs e)
        {
        }
        private void SelectToolSelect(object sender, RoutedEventArgs e)
        {
        }
        private void ShowSidebarInformation(object sender, RoutedEventArgs e)
        {
            Sidebar.Content = new SidebarInformation();
        }

        private void ShowSidebarView(object sender, RoutedEventArgs e)
        {
            Sidebar.Content = new SidebarView();
        }

        private void ShowSidebarAlgorithms(object sender, RoutedEventArgs e)
        {
            Sidebar.Content = new SidebarAlgorithms();
        }

        public void Zoom(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Alt))
            {
                Point currentMousePosition = Mouse.GetPosition(CanvasScrollViewer);
                (CanvasScrollViewer.LayoutTransform as ScaleTransform).CenterX = currentMousePosition.X;
                (CanvasScrollViewer.LayoutTransform as ScaleTransform).CenterY = currentMousePosition.Y;
                (CanvasScrollViewer.LayoutTransform as ScaleTransform).ScaleX *= 1 + (e.Delta / 1000.0);
                (CanvasScrollViewer.LayoutTransform as ScaleTransform).ScaleY *= 1 + (e.Delta / 1000.0);
                e.Handled = true;

                if ((CanvasScrollViewer.LayoutTransform as ScaleTransform).ScaleX > 1.05)
                    CanvasScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                else
                    CanvasScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
        }

        private void Print(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDialog dialog = new PrintDialog();

                if (dialog.ShowDialog() != true)
                    return;
                dialog.PrintVisual(CanvasScrollViewer.Content as Canvas, "Drawing");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while printing", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
