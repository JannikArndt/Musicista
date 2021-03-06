﻿using Collection;
using Mixpanel.NET.Events;
using Model;
using Musicista.Collection;
using Musicista.Properties;
using Musicista.Sidebar;
using Musicista.UI;
using Musicista.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;
using Path = System.Windows.Shapes.Path;

namespace Musicista
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static List<UIPage> PageList;
        public static Piece CurrentPiece;
        public static ApplicationSettings ApplicationSettings = new ApplicationSettings();
        public static CollectionBase CollectionBase = new CollectionBase();

        public static ScrollViewer UICanvasScrollViewer;
        public static ContentControl UISidebar;
        public static ContentControl UICollection;
        public static Path UIButtonPathInformation;
        public static Path UIButtonPathView;
        public static Path UIButtonPathAlgorithms;
        public static Path UIButtonPathCollection;

        public static TextBox TinyNotationTextBox;

        public static MixpanelTracker Tracker { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            if (Settings.Default.SendCrashReport)
                Dispatcher.UnhandledException += Application_ThreadException;

            // Make ui-elements accessible by static methods
            UICanvasScrollViewer = CanvasScrollViewer;
            UISidebar = Sidebar;
            UICollection = CollectionContentControl;
            UIButtonPathInformation = ButtonPathInformation;
            UIButtonPathView = ButtonPathView;
            UIButtonPathAlgorithms = ButtonPathAlgorithms;
            UIButtonPathCollection = ButtonPathCollection;
            TinyNotationTextBox = TinyNotationBox;

            PreviewMouseWheel += Zoom;
            SetUpKeyCommands();

            LoadApplicationSettings();
            LoadCollectionBase();

            SidebarInformation = new SidebarInformation();
            SidebarView = new SidebarView();
            SidebarAlgorithms = new SidebarAlgorithms();
            Sidebar.Content = SidebarInformation;
            ButtonPathInformation.Fill = Brushes.DodgerBlue;
            ButtonPathSelect.Fill = Brushes.DodgerBlue;

            CollectionWindow = new CollectionWindow();

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

            if (String.IsNullOrEmpty(Settings.Default.Username))
                Settings.Default.Username = Environment.UserName;

            if (IsConnectedToTheInternet())
            {
                Tracker = new MixpanelTracker("4b33ac9fe9a2f777e40b9b0a213669fe");
                Tracker.Track("Start Program", new Dictionary<string, object> { { "Username", Settings.Default.Username } });
            }
        }

        /// <summary>
        /// Ping Google to see if the app has internet access.
        /// </summary>
        /// <returns></returns>
        public static bool IsConnectedToTheInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// This method is called whenever an unhandled exception is thrown. It reports the exception to MixPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (Tracker != null)
                Tracker.Track("Crash", new Dictionary<string, object>
            {
                { "Username", Settings.Default.Username },
                { "Message", e.Exception.Message },
                { "Type", e.Exception.GetType() },
                { "Data", e.Exception.Data },
                { "StackTrace", e.Exception.StackTrace },
                { "Source", e.Exception.Source },
                { "OS", Environment.OSVersion.VersionString },
                { "Current Piece", CurrentPiece != null ? CurrentPiece.Meta.Title : "" },
                { "URL", CurrentPiece != null ? CurrentPiece.Meta.Weblink : "" }
            });
        }

        /// <summary>
        /// Load the RecentlyUsed.xml or create a new one if none exists.
        /// </summary>
        private static void LoadApplicationSettings()
        {
            if (File.Exists(ApplicationSettings.FileName))
            {
                try
                {
                    var xmlSerializer = new XmlSerializer(typeof(ApplicationSettings));
                    ApplicationSettings =
                        (ApplicationSettings)
                            xmlSerializer.Deserialize(XDocument.Load(ApplicationSettings.FileName).CreateReader());
                }
                catch (Exception)
                {
                    ApplicationSettings.Save();
                }
            }
            else
                ApplicationSettings.Save();
        }

        /// <summary>
        /// Load the collection.xml from the musicista server or create a local one if the app is not connected to the internet.
        /// </summary>
        private static void LoadCollectionBase()
        {
            var xmlSerializer = new XmlSerializer(typeof(CollectionBase));
            if (IsConnectedToTheInternet())
                CollectionBase = (CollectionBase)xmlSerializer.Deserialize(XDocument.Load("http://www.musicistaapp.de/download/Collection.xml").CreateReader());
            else
                CollectionBase = new CollectionBase();
        }

        /// <summary>
        /// Show a list of most recently used files in the given StackPanel.
        /// </summary>
        /// <param name="stack"></param>
        private static void ShowMostRecentlyUsed(Panel stack)
        {
            foreach (var documentReference in ApplicationSettings.MostRecentlyUsed.Take(4))
            {
                const int totalLength = 80;
                var titleLength = documentReference.Name.Length;
                var pathLength = documentReference.Filepath.Length;
                var filepath = documentReference.Filepath;
                if (totalLength < (titleLength + pathLength))
                {
                    var endCharacters = Math.Max(0, totalLength - titleLength - 19);
                    filepath = documentReference.Filepath.Substring(0, 16) + "..." +
                               documentReference.Filepath.Substring((pathLength - endCharacters), endCharacters);
                }

                var mruTextBlock = new TextBlock
                {
                    FontSize = 12,
                    TextAlignment = TextAlignment.Left,
                    Margin = new Thickness(0, 8, 0, 0)
                };
                if (string.IsNullOrEmpty(documentReference.Name))
                    mruTextBlock.Inlines.Add(new Run(filepath));
                else
                {
                    mruTextBlock.Inlines.Add(new Run(documentReference.Name));
                    mruTextBlock.Inlines.Add(new Run(" (" + filepath + ")") { Foreground = Brushes.DarkGray });
                }
                mruTextBlock.MouseDown += (sender, args) => OpenFile(documentReference.Filepath);
                mruTextBlock.Cursor = Cursors.Hand;

                stack.Children.Add(mruTextBlock);
            }
        }

        /// <summary>
        /// Interpret mouse events as zooming (when alt is pressed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Setup command bindings for menu items
        /// </summary>
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

            // export
            var exportCommandBinding = new CommandBinding(MediaCommands.DecreaseTreble, Export, (sender, e) => { e.CanExecute = CurrentPiece != null; });
            CommandBindings.Add(exportCommandBinding);

            var exportKeyGesture = new KeyGesture(Key.E, ModifierKeys.Control);
            var exportInputBinding = new InputBinding(MediaCommands.DecreaseTreble, exportKeyGesture);
            InputBindings.Add(exportInputBinding);

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
            var quitCommandBinding = new CommandBinding(MediaCommands.BoostBass, (s, e) => Application.Current.Shutdown(),
                (sender, e) => { e.CanExecute = true; });
            CommandBindings.Add(quitCommandBinding);

            var quitKeyGesture = new KeyGesture(Key.Q, ModifierKeys.Control);
            var quitInputBinding = new InputBinding(MediaCommands.BoostBass, quitKeyGesture);
            InputBindings.Add(quitInputBinding);

            // esc
            var escCommandBinding = new CommandBinding(MediaCommands.DecreaseBass, (s, e) =>
            {
                UICollection.Content = null;
                UIButtonPathCollection.Fill = Brushes.Black;
            },
                (sender, e) => { e.CanExecute = true; });
            CommandBindings.Add(escCommandBinding);

            var escKeyGesture = new KeyGesture(Key.Escape);
            var escInputBinding = new InputBinding(MediaCommands.DecreaseBass, escKeyGesture);
            InputBindings.Add(escInputBinding);
        }

        /// <summary>
        /// Create a new, empty piece and open it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentPiece = new Piece(true, Settings.Default.Username);
            DrawCurrentPiece();
            _fileName = "";

            SidebarInformation.ShowPiece();
            UISidebar.Content = SidebarInformation;
            SetSidebarButtonPathFill(SidebarKind.Information);
            SidebarView.ShowPageSettings(PageList.First());

            if (Tracker != null)
                Tracker.Track("New Document", new Dictionary<string, object> { { "Username", Settings.Default.Username } });
        }

        /// <summary>
        /// Sive and close the current piece
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFile(_fileName, CurrentPiece);
            CurrentPiece = null;
            PageList = null;
            Sidebar.Content = new SidebarInformation();
            SetToolbarButtonPathFill(ToolKind.Select);
            var startScreen = new StartScreen();
            ShowMostRecentlyUsed(startScreen.RecentFilesStack);
            CanvasScrollViewer.Content = startScreen;
            _fileName = "";

            if (Tracker != null)
                Tracker.Track("Close Document", new Dictionary<string, object> { { "Username", Settings.Default.Username } });
        }

        /// <summary>
        /// Print the current piece
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new PrintDialog
                {
                    PrintTicket = { PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4), PageBorderless = PageBorderless.Borderless }
                };

                if (dialog.ShowDialog() != true)
                    return;
                var stackPanel = CanvasScrollViewer.Content as StackPanel;
                if (stackPanel == null)
                    return;

                foreach (var canvas in stackPanel.Children.OfType<UIPage>())
                {
                    // Arrange parent canvas
                    //canvas.Measure(new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight));
                    //canvas.Arrange(new Rect(canvas.DesiredSize));
                    dialog.PrintVisual(canvas, CurrentPiece.Meta.Title);
                }

                if (Tracker != null)
                    Tracker.Track("Print", new Dictionary<string, object> { { "Username", Settings.Default.Username } });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while printing", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Turn the piece stored in CurrentPiece into a list of UIPage objects and display those
        /// </summary>
        private static void DrawCurrentPiece()
        {
            PageList = UIHelper.DrawPiece(CurrentPiece);

            var pages = new StackPanel();
            foreach (var page in PageList)
                pages.Children.Add(page);
            pages.Children.Add(new Canvas { Height = 200 });
            UICanvasScrollViewer.Content = pages;

            if (Tracker != null)
                Tracker.Track("Draw Piece", new Dictionary<string, object> { { "Username", Settings.Default.Username }, { "Piece", CurrentPiece.Meta.Title } });
        }

        /// <summary>
        /// Draw the CurrentPiece again, replace the old one
        /// </summary>
        public static void ReDrawPiece()
        {
            PageList = UIHelper.DrawPiece(CurrentPiece);

            var pages = new StackPanel();
            foreach (var page in PageList)
                pages.Children.Add(page);
            pages.Children.Add(new Canvas { Height = 200 });
            UICanvasScrollViewer.Content = pages;
        }

        /// <summary>
        /// This is called before the program is closed. It saves the document.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(_fileName) && CurrentPiece != null)
                SaveFile(_fileName, CurrentPiece);
            if (Tracker != null)
                Tracker.Track("Close Program", new Dictionary<string, object> { { "Username", Settings.Default.Username } });
        }
    }
}