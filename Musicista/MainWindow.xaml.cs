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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseWheel += Zoom;

            Sidebar.Content = new SidebarInformation();

            NoteViewer.Background = Brushes.LightGray;
            NoteViewer.Height = 3000;


            var UIPage = UIHelper.CreatePage(NoteViewer);
            UIHelper.CreateTitle("7. Sinfonie", NoteViewer, UIPage);

            TextBlock composer = new TextBlock
            {
                Text = "Ludwig v. Beethoven",
                FontSize = 16
            };
            Canvas.SetTop(composer, 150);
            Canvas.SetLeft(composer, 600);
            NoteViewer.Children.Add(composer);

            var Staff1 = UIHelper.DrawStaff(NoteViewer, UIPage, 200);
            var Staff2 = UIHelper.DrawStaff(NoteViewer, UIPage, 300);
            var Staff3 = UIHelper.DrawStaff(NoteViewer, UIPage, 400);
            var Staff4 = UIHelper.DrawStaff(NoteViewer, UIPage, 500);
            var Staff5 = UIHelper.DrawStaff(NoteViewer, UIPage, 600);
            var Staff6 = UIHelper.DrawStaff(NoteViewer, UIPage, 700);
            var Staff7 = UIHelper.DrawStaff(NoteViewer, UIPage, 800);

            UIHelper.DrawTrebleClef(NoteViewer, Staff1);

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





            UIMeasure uim1 = UIHelper.DrawMeasure(NoteViewer, Staff1, m1);
            UIMeasure uim2 = UIHelper.DrawMeasure(NoteViewer, Staff1, m2);
            UIMeasure uim3 = UIHelper.DrawMeasure(NoteViewer, Staff1, m3);
            UIMeasure uim4 = UIHelper.DrawMeasure(NoteViewer, Staff1, m3);
            UIMeasure uim5 = UIHelper.DrawMeasure(NoteViewer, Staff2, m3);
            UIMeasure uim6 = UIHelper.DrawMeasure(NoteViewer, Staff2, m3);

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
            Note note41 = new Note { Beat = 3, Step = Pitch.D, Octave = 4, Duration = Model.Duration.half };

            Note note50 = new Note { Beat = 1, Step = Pitch.D, Octave = 4, Duration = Model.Duration.whole };

            UIHelper.DrawNote(NoteViewer, note50, uim1);

            UIHelper.DrawNote(NoteViewer, note40, uim2);
            UIHelper.DrawNote(NoteViewer, note41, uim2);

            UIHelper.DrawNote(NoteViewer, note30, uim3);
            UIHelper.DrawNote(NoteViewer, note31, uim3);
            UIHelper.DrawNote(NoteViewer, note32, uim3);
            UIHelper.DrawNote(NoteViewer, note33, uim3);

            UIHelper.DrawNote(NoteViewer, note20, uim4);
            UIHelper.DrawNote(NoteViewer, note21, uim4);
            UIHelper.DrawNote(NoteViewer, note22, uim4);
            UIHelper.DrawNote(NoteViewer, note23, uim4);
            UIHelper.DrawNote(NoteViewer, note24, uim4);
            UIHelper.DrawNote(NoteViewer, note25, uim4);
            UIHelper.DrawNote(NoteViewer, note26, uim4);
            UIHelper.DrawNote(NoteViewer, note27, uim4);

            UIHelper.DrawNote(NoteViewer, note1, uim5);
            UIHelper.DrawNote(NoteViewer, note2, uim5);
            UIHelper.DrawNote(NoteViewer, note3, uim5);
            UIHelper.DrawNote(NoteViewer, note4, uim5);
            UIHelper.DrawNote(NoteViewer, note5, uim5);
            UIHelper.DrawNote(NoteViewer, note6, uim5);
            UIHelper.DrawNote(NoteViewer, note7, uim5);
            UIHelper.DrawNote(NoteViewer, note8, uim5);
            UIHelper.DrawNote(NoteViewer, note9, uim5);
            UIHelper.DrawNote(NoteViewer, note10, uim5);
            UIHelper.DrawNote(NoteViewer, note11, uim5);
            UIHelper.DrawNote(NoteViewer, note12, uim5);
            UIHelper.DrawNote(NoteViewer, note13, uim5);
            UIHelper.DrawNote(NoteViewer, note14, uim5);
            UIHelper.DrawNote(NoteViewer, note15, uim5);
            UIHelper.DrawNote(NoteViewer, note16, uim5);

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
                Point currentMousePosition = Mouse.GetPosition(NoteViewer);
                (NoteViewer.LayoutTransform as ScaleTransform).CenterX = currentMousePosition.X;
                (NoteViewer.LayoutTransform as ScaleTransform).CenterY = currentMousePosition.Y;
                (NoteViewer.LayoutTransform as ScaleTransform).ScaleX *= 1 + (e.Delta / 1000.0);
                (NoteViewer.LayoutTransform as ScaleTransform).ScaleY *= 1 + (e.Delta / 1000.0);
                e.Handled = true;

                if ((NoteViewer.LayoutTransform as ScaleTransform).ScaleX > 1.05)
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
                dialog.PrintVisual(NoteViewer, "Drawing");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while printing", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
