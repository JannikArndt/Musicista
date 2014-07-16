using Ionic.Zip;
using Microsoft.Win32;
using Model;
using Musicista.Mappers;
using Musicista.Sidebar;
using Musicista.UI;
using Musicista.View;
using MusicXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Musicista
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static List<UIPage> PageList;
        public static Piece CurrentPiece;
        private string _fileName = "";
        public static ApplicationSettings ApplicationSettings = new ApplicationSettings();

        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseWheel += Zoom;
            SetUpKeyCommands();

            LoadAppilcationSettings();

            SidebarInformation = new SidebarInformation();
            SidebarView = new SidebarView();
            SidebarAlgorithms = new SidebarAlgorithms();
            Sidebar.Content = SidebarInformation;
            ButtonPathInformation.Fill = Brushes.DodgerBlue;
            ButtonPathSelect.Fill = Brushes.DodgerBlue;

            if (Application.Current.Properties["LoadFileOnStartup"] != null
                && (File.Exists(Application.Current.Properties["LoadFileOnStartup"].ToString())))
                OpenFile(Application.Current.Properties["LoadFileOnStartup"].ToString());
            else // Show start screen
            {
                var startScreen = new StartScreen();
                ShowMostRecentlyUsed(startScreen.RecentFilesStack);
                CanvasScrollViewer.Content = startScreen;
            }
            SidebarInformation.ShowPiece();
        }

        private static void LoadAppilcationSettings()
        {
            if (File.Exists(ApplicationSettings.FileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(ApplicationSettings));
                ApplicationSettings = (ApplicationSettings)xmlSerializer.Deserialize(XDocument.Load(ApplicationSettings.FileName).CreateReader());
            }
            else
                ApplicationSettings.Save();
        }

        private void ShowMostRecentlyUsed(StackPanel stack)
        {
            foreach (var documentReference in ApplicationSettings.MostRecentlyUsed.Take(4))
            {
                var mruTextBlock = new TextBlock
                {
                    FontSize = 12,
                    TextAlignment = TextAlignment.Left,
                    Margin = new Thickness(0, 8, 0, 0)
                };
                if (string.IsNullOrEmpty(documentReference.Name))
                    mruTextBlock.Inlines.Add(new Run(documentReference.Filepath));
                else
                {
                    mruTextBlock.Inlines.Add(new Run(documentReference.Name));
                    mruTextBlock.Inlines.Add(new Run(" (" + documentReference.Filepath + ")") { Foreground = Brushes.DarkGray });
                }
                mruTextBlock.MouseDown += (sender, args) => OpenFile(documentReference.Filepath);
                mruTextBlock.Cursor = Cursors.Hand;

                stack.Children.Add(mruTextBlock);
            }
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
            PageList = null;
            var startScreen = new StartScreen();
            ShowMostRecentlyUsed(startScreen.RecentFilesStack);
            CanvasScrollViewer.Content = startScreen;
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
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Supported Files|*.xml;*.musicista;*.mxl|Musicista (*.musicista)|*.musicista|MusicXML (*.xml)|*.xml|Compressed MusicXML (*.mxl)|*.mxl|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() != true)
                return;
            OpenFile(openFileDialog.FileName);
        }

        public void OpenFile(String filename)
        {
            try
            {
                switch (Path.GetExtension(filename))
                {
                    case ".mxl":
                        // find the correct xml-file, unzip it and try to open that one again
                        foreach (var zipEntry in ZipFile.Read(filename).Where(zipEntry => Path.GetExtension(zipEntry.FileName) == ".xml" && zipEntry.FileName != "META-INF/container.xml"))
                        {
                            zipEntry.Extract(ExtractExistingFileAction.OverwriteSilently);
                            OpenFile(zipEntry.FileName);
                            return;
                        }
                        break;
                    case ".xml":
                        // based upon http://stackoverflow.com/a/23663586/1507481
                        var xdoc = XDocument.Load(filename);
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
                                        // convert to partwise
                                        var xslCompiledTransform = new XslCompiledTransform(); // XSLT Transformation
                                        var stream = new MemoryStream(); // Temporary memorystream
                                        var outputXmlTextWriter = XmlWriter.Create(stream);
                                        xslCompiledTransform.Load("Properties/timepart.xsl"); // Load the XSLT 
                                        xslCompiledTransform.Transform(xdoc.CreateNavigator(), null, outputXmlTextWriter); // Transform the timewise-document into a partwise-document

                                        stream.Position = 0; // reset stream to beginning

                                        var xmlSerializer = new XmlSerializer(typeof(ScorePartwise));
                                        var result = (ScorePartwise)xmlSerializer.Deserialize(XmlReader.Create(stream)); // deserialize the transformed stream
                                        DrawPiece(MusicXMLMapper.MapMusicXMLToMusicista(result));
                                    }
                                    break;
                                default:
                                    MessageBox.Show(@"Cannot open file " + Path.GetExtension(filename) + " because it does not seem to be valid MusicXML.", "Error");
                                    break;
                            }
                        break;
                    case ".musicista":
                        using (var fileStream = new FileStream(filename, FileMode.Open))
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
                            // same for the Parts
                            foreach (var part in piece.Parts)
                                foreach (var measureGroup in part.Passage.ListOfMeasureGroups)
                                {
                                    measureGroup.ParentPassage = part.Passage;
                                    foreach (var measure in measureGroup.Measures)
                                    {
                                        measure.ParentMeasureGroup = measureGroup;
                                        foreach (var symbol in measure.Symbols)
                                            symbol.ParentMeasure = measure;
                                    }
                                }
                            DrawPiece(piece);
                            _fileName = filename;
                        }
                        break;
                    default:
                        MessageBox.Show(@"Cannot open filetype " + Path.GetExtension(filename), "Error");
                        return;
                }

                ApplicationSettings.AddToMostRecentlyUsedFiles(CurrentPiece.Title, filename);
                SidebarInformation.ShowPiece();
                Sidebar.Content = SidebarInformation;
                SetSidebarButtonPathFill(SidebarKind.Information);
                SidebarView.ShowPageSettings(PageList.First());
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
            ApplicationSettings.AddToMostRecentlyUsedFiles(CurrentPiece.Title, _fileName);
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
            ApplicationSettings.AddToMostRecentlyUsedFiles(CurrentPiece.Title, _fileName);
        }

        private void DrawPiece(Piece piece)
        {
            CurrentPiece = piece;
            PageList = UIHelper.DrawPiece(CurrentPiece);

            var pages = new StackPanel();
            foreach (var page in PageList)
                pages.Children.Add(page);
            pages.Children.Add(new Canvas { Height = 200 });
            CanvasScrollViewer.Content = pages;
        }
    }
}