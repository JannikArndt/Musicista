using Microsoft.Win32;
using Model;
using Musicista.Mappers;
using Musicista.Sidebar;
using Musicista.UI;
using MusicXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Musicista
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static List<Canvas> _pageList;
        public static Piece CurrentPiece;
        private string _fileName = "";

        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseWheel += Zoom;
            SetUpKeyCommands();

            SidebarInformation = new SidebarInformation();
            SidebarView = new SidebarView();
            SidebarAlgorithms = new SidebarAlgorithms();
            Sidebar.Content = SidebarInformation;
            ButtonPathInformation.Fill = Brushes.DodgerBlue;
            ButtonPathSelect.Fill = Brushes.DodgerBlue;

            /*
            using (var fileStream = new FileStream("exa.musicista", FileMode.Open))
            {
                var musicistaSerializer = new XmlSerializer(typeof(Piece));
                DrawPiece((Piece)musicistaSerializer.Deserialize(fileStream));
                _fileName = "exa.musicista";
            }
            /*
            var serializer = new XmlSerializer(typeof(ScorePartwise));
            using (var fileStream = new FileStream("example.xml", FileMode.Open))
            {
                var result = (ScorePartwise)serializer.Deserialize(fileStream);
                DrawPiece(MusicXMLMapper.MapMusicXMLToMusicista(result));
            }
            /*
            const string filePath = @"C:\Users\Jannik\test.mid";
            var file = File.OpenRead(filePath);
            DrawPiece(MidiMapper.MapMidiToPiece(FileParser.Parse(file)));
             */
            SidebarInformation.ShowPiece();
        }

        public void Zoom(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Alt))
            {
                var currentMousePosition = Mouse.GetPosition(CanvasScrollViewer);
                var scaleTransform = CanvasScrollViewer.LayoutTransform as ScaleTransform;
                if (scaleTransform != null)
                {
                    scaleTransform.CenterX = currentMousePosition.X;
                    scaleTransform.CenterY = currentMousePosition.Y;
                    scaleTransform.ScaleX *= 1 + (e.Delta / 1000.0);
                    scaleTransform.ScaleY *= 1 + (e.Delta / 1000.0);

                    e.Handled = true;

                    CanvasScrollViewer.HorizontalScrollBarVisibility = scaleTransform.ScaleX > 1.05 ? ScrollBarVisibility.Visible : ScrollBarVisibility.Hidden;
                }
            }
        }

        public void SetUpKeyCommands()
        {
            // new
            var newCommandBinding = new CommandBinding(ApplicationCommands.New, New, (sender, e) => { e.CanExecute = true; });
            CommandBindings.Add(newCommandBinding);

            // open
            var openCommandBinding = new CommandBinding(ApplicationCommands.Open, Open, (sender, e) => { e.CanExecute = true; });
            CommandBindings.Add(openCommandBinding);

            // save
            var saveCommandBinding = new CommandBinding(ApplicationCommands.Save, Save, (sender, e) => { e.CanExecute = CurrentPiece != null; });
            CommandBindings.Add(saveCommandBinding);

            // save as
            var saveAsCommandBinding = new CommandBinding(ApplicationCommands.SaveAs, SaveAs, (sender, e) => { e.CanExecute = CurrentPiece != null; });
            CommandBindings.Add(saveAsCommandBinding);

            var saveAsKeyGesture = new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift);
            var saveAsInputBinding = new InputBinding(ApplicationCommands.SaveAs, saveAsKeyGesture);
            InputBindings.Add(saveAsInputBinding);

            // print
            var printCommandBinding = new CommandBinding(ApplicationCommands.Print, Print, (sender, e) => { e.CanExecute = CurrentPiece != null; });
            CommandBindings.Add(printCommandBinding);

            // close
            var closeCommandBinding = new CommandBinding(ApplicationCommands.Close, Close, (sender, e) => { e.CanExecute = CurrentPiece != null; });
            CommandBindings.Add(closeCommandBinding);

            var closeKeyGesture = new KeyGesture(Key.W, ModifierKeys.Control);
            var closeInputBinding = new InputBinding(ApplicationCommands.Close, closeKeyGesture);
            InputBindings.Add(closeInputBinding);

            // quit
            var quitCommandBinding = new CommandBinding(MediaCommands.BoostBass, (s, e) => Application.Current.Shutdown(), (sender, e) => { e.CanExecute = true; });
            CommandBindings.Add(quitCommandBinding);

            var quitKeyGesture = new KeyGesture(Key.Q, ModifierKeys.Control);
            var quitInputBinding = new InputBinding(MediaCommands.BoostBass, quitKeyGesture);
            InputBindings.Add(quitInputBinding);
        }

        private void New(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentPiece = new Piece();
            DrawPiece(CurrentPiece);
            _fileName = "";
        }

        private void Close(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentPiece = null;
            _pageList = null;
            CanvasScrollViewer.Content = null;
            _fileName = "";
        }


        private void Print(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new PrintDialog();

                if (dialog.ShowDialog() != true)
                    return;
                var stackPanel = CanvasScrollViewer.Content as StackPanel;
                if (stackPanel == null)
                    return;
                var visual = stackPanel.Children[0] as Canvas;
                if (visual != null)
                    dialog.PrintVisual(visual, "Drawing");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while printing", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog { Filter = "Supported Files|*.xml;*.musicista|MusicXML (*.xml)|*.xml|Musicista (*.musicista)|*.musicista|All files (*.*)|*.*" };
            if (openFileDialog.ShowDialog() != true)
                return;

            try
            {
                switch (Path.GetExtension(openFileDialog.FileName))
                {
                    case ".xml":
                        // based upon http://stackoverflow.com/a/23663586/1507481
                        var xdoc = XDocument.Load(openFileDialog.FileName);
                        if (xdoc.Root != null)
                            switch (xdoc.Root.Name.LocalName)
                            {
                                case "score-partwise":
                                    {
                                        var xmlSerializer = new XmlSerializer(typeof(ScorePartwise));
                                        var result = (ScorePartwise)xmlSerializer.Deserialize(xdoc.CreateReader());
                                        DrawPiece(MusicXMLMapper.MapMusicXMLToMusicista(result));
                                    }
                                    break;
                                case "score-timewise":
                                    {
                                        var xmlSerializer = new XmlSerializer(typeof(ScoreTimewise));
                                        var result = (ScoreTimewise)xmlSerializer.Deserialize(xdoc.CreateReader());
                                        DrawPiece(MusicXMLMapper.MapMusicXMLToMusicista(result));
                                    }
                                    break;
                                default:
                                    MessageBox.Show(@"Cannot open file " + Path.GetExtension(openFileDialog.FileName) + " because it does not seem to be valid MusicXML.", "Error");
                                    break;
                            }
                        break;
                    case ".musicista":
                        using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                        {
                            var musicistaSerializer = new XmlSerializer(typeof(Piece));
                            var piece = (Piece)musicistaSerializer.Deserialize(fileStream);
                            // correct parent-relations
                            foreach (var passage in piece.ListOfAllPassages)
                                foreach (var measureGroup in passage.ListOfMeasureGroups)
                                {
                                    measureGroup.ParentPassage = passage;
                                    foreach (var measure in measureGroup.Measures)
                                    {
                                        measure.ParentMeasureGroup = measureGroup;
                                        foreach (var symbol in measure.Symbols)
                                            symbol.ParentMeasure = measure;
                                    }
                                }
                            DrawPiece(piece);
                            _fileName = openFileDialog.FileName;
                        }
                        break;
                    default:
                        MessageBox.Show(@"Cannot open filetype " + Path.GetExtension(openFileDialog.FileName), "Error");
                        break;

                }
                SidebarInformation.ShowPiece();
                Sidebar.Content = SidebarInformation;
                SetSidebarButtonPathFill(SidebarKind.Information);
            }
            catch (IOException exception)
            {
                MessageBox.Show("Error while loading file: " + exception.Message, "Error");
            }
        }

        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_fileName))
                SaveAs(sender, e);
            else
            {
                var serializer = new XmlSerializer(typeof(Piece));
                using (TextWriter writer = new StreamWriter(_fileName))
                {
                    serializer.Serialize(writer, CurrentPiece);
                }
            }
        }

        private void SaveAs(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { DefaultExt = ".musicista", Filter = "Musicista (*.musicista)|*.musicista", OverwritePrompt = true, FileName = CurrentPiece.Title };
            if (saveFileDialog.ShowDialog() != true)
                return;

            _fileName = saveFileDialog.FileName;
            var serializer = new XmlSerializer(typeof(Piece));
            using (TextWriter writer = new StreamWriter(_fileName))
            {
                serializer.Serialize(writer, CurrentPiece);
            }
        }

        private void DrawPiece(Piece piece)
        {
            CurrentPiece = piece;
            _pageList = UIHelper.DrawPiece(CurrentPiece);

            var pages = new StackPanel();
            foreach (var page in _pageList)
                pages.Children.Add(page);
            pages.Children.Add(new Canvas { Height = 200 });
            CanvasScrollViewer.Content = pages;
        }
    }
}